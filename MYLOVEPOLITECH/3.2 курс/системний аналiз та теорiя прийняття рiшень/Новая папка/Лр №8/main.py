import numpy as np
from collections import namedtuple
from scipy.optimize import linprog
from math import fabs

task = 0


def pareto_set(A):
    n = A.shape[0]
    i = 0
    while i < n:
        for j in range(i + 1, n, 1):
            m = np.min(A[i] - A[j])
            q = np.min(A[j] - A[i])
            if m >= 0:
                A = np.delete(A, j, 0)
                i -= 1
                break
            elif q >= 0:
                A = np.delete(A, i, 0)
                i -= 1
                break
        i += 1
        n = A.shape[0]
    return A


def dsa(A: np.ndarray):
    return pareto_set(A)


def dsb(A: np.ndarray):
    return np.asmatrix(-pareto_set(-np.asmatrix(A).H)).H


def dominance_strategy(A: np.ndarray):
    while True:
        a = dsa(A)
        a = dsb(a)
        if np.array_equal(dsb(a), a):
            break
        else:
            continue
    if not np.array_equal(a, A):
        print('\033[92mDominance strategy detected!\033[0m')
        print('Game reduction result:\n', str(a)[1:-1])
        return a
    else:
        print("\033[91mThis game can't be reduced!\033[90m")
        return A


def pure_strategy(A: np.ndarray):
    Player = namedtuple('Player', ['p', 'a'])
    k, n = A.shape

    min1 = np.min(A, axis=1)
    i = np.argmax(min1)
    val1 = np.amax(min1)

    max2 = np.max(A, axis=0)
    j = np.argmin(max2)
    val2 = np.amin(max2)

    p1, p2 = Player(i, val1), Player(j, val2)
    if p1.a != p2.a:
        return False
    else:
        print('\033[92mPure strategy solution detected!\033[0m\n')
        print('Game value:', p1.a)
        p, q = np.zeros(k), np.zeros(n)
        p[i] = 1
        q[j] = 1
        for i_ in range(k):
            print(f'Strategy probability i = {i_ + 1}\tp = {p[i_]}')
        for j_ in range(k):
            print(f'Strategy probability j = {j_ + 1}\tq = {q[j_]}')
        return True


def mixed_strategy(A: np.ndarray):
    k, n = A.shape

    fx = np.ones(k)
    At = -np.asmatrix(A).H
    bx = -np.ones(n)
    opt = linprog(fx, A_ub=At, b_ub=bx)
    x, fval = opt['x'], opt['fun']
    vx = fabs(1 / fval)
    p = np.multiply(x, vx)

    print('Game value:', '{:.3f}'.format(vx))
    for i in range(k):
        print(f'Strategy probability i = {i + 1}\tp = {"{:.3f}".format(round(p[i], 3))}')

    fy = -np.ones(n)
    by = np.ones(k)
    opt = linprog(fy, A_ub=A, b_ub=by)
    y, fval = opt['x'], opt['fun']
    vy = fabs(1 / fval)
    q = np.multiply(y, vy)

    print('Game value:', '{:.3f}'.format(vy))
    for j in range(n):
        print(f'Strategy probability j = {j + 1}\tq = {"{:.3f}".format(round(q[j], 3))}')


def solve_game(A: np.ndarray, _):
    print('Game:\n', str(A)[1:-1])
    A = dominance_strategy(A)
    if not pure_strategy(A):
        print('\n\033[92mMixed strategy solution detected!\033[0m\n')
        mixed_strategy(A)


def properties_check(A: np.ndarray, var: int):
    A = dominance_strategy(A)
    print('\nOriginal mixed strategy solution:\n')
    mixed_strategy(A)
    print(f'\nAdding {var} to every element of payoff matrix:\n')
    mixed_strategy(A + var)
    print(f'\nMultiplying payoff matrix by {var}:\n')
    mixed_strategy(A * var)


A = np.array([
    [0, 1, 3, 6, 7, 4],
    [0, 9, 5, 2, 6, 8],
    [6, 4, 1, 1, 8, 7],
    [1, 3, 0, 8, 0, 6],
    [8, 3, 3, 2, 1, 3],
    [1, 3, 4, 6, 8, 4]
])
var = 5


# Lab menu
def menu(argument):
    switcher = {
        0: exit,
        1: solve_game,
        2: properties_check
    }
    func = switcher.get(argument, lambda: print("No such option!\n"))
    func(A, var)


# Entry point
while True:
    print("\nLab 8 menu:")
    print("""
1.  Task 1
2.  Task 2
0. Exit
    """)
    try:
        task = int(input("Enter task number: "))
        menu(task)
    except ValueError:
        print("That was no valid number. Try again...\n")
