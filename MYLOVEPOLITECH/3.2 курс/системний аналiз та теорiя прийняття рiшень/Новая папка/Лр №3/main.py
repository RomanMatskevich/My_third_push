import numpy as np
import matplotlib.pyplot as plt
import sys
from time import time, sleep
import operator

# Needed accuracy
EPS = 0.00001

# A coefficients
A = []

# Number of steps for trajectory
step_size = 5

# Search limits
X1min = 0
X1max = 0
X2min = 0
X2max = 0

# Q_opt equals maximum float number
Q_opt = 0
X1_opt = 0
X2_opt = 0

# Relative error values
X1eps = 0
X2eps = 0

# Number of sections on axes X1 and X2
N = 0

# Steps
X1_step = 0
X2_step = 0
SX1 = 0
SX2 = 0

# ExtremumType
extremumType = ''

# Axes Arrays
X1s = []
X2s = []
Qs = []

# Search Trajectory Arrays
X1t = []
X2t = []
Qt = []
i = 0

# Extremum approximate coordinates
X1opt = 0
X2opt = 0
Qopt = 0

# Benchmark
benchFlag = False
bench = []
Ns = []
calcs = []


def Q_(X1, X2):
    return A[0] + A[1] * X1 + A[2] * X2 + A[3] * X1 * X2 + A[4] * X1 * X1 + A[5] * X2 * X2


def Search():
    global X1_opt, X2_opt, Q_opt, i
    Q_opt = sys.float_info.max if extremumType == 'min' else sys.float_info.min
    compare = operator.lt if extremumType == 'min' else operator.gt
    x1 = X1min
    while x1 <= X1max + EPS:
        x2 = X2min
        while x2 <= X2max + EPS:
            q = Q_(x1, x2)
            if compare(q, Q_opt):
                Q_opt = q
                X1_opt = x1
                X2_opt = x2
            if i < step_size:
                X1t.append(x1)
                X2t.append(x2)
                Qt.append(q)
            X1s.append(x1)
            X2s.append(x2)
            Qs.append(q)
            i += 1
            x2 += X2_step
        x1 += X1_step
    return i


def Q_function(vis=False):
    global Q_opt, X1_opt, X2_opt
    global Qopt, X1opt, X2opt
    global X1s, X2s, Qs
    global X1min, X1max, X2min, X2max
    global X1_step, X2_step, SX1, SX2

    benchStart = 0

    Qs.clear()
    X1s.clear()
    X2s.clear()
    Qt.clear()
    X1t.clear()
    X2t.clear()

    if benchFlag:
        benchStart = time()

    while True:
        SX1 = X1max - X1min
        SX2 = X2max - X2min
        X1_step, X2_step = (X1max - X1min) / N, (X2max - X2min) / N
        i = Search()
        if vis:
            print(f"Analysis of calculated result", end="")
            [print('.', end="") and sleep(0.5) for _ in range(3)]
            print()
        if X1_opt < X1min + EPS or X1_opt > X1max - EPS or X2_opt < X2min + EPS or X2_opt > X2max - EPS:
            if X1_opt > X1max - EPS:
                vis and print("\tResult is on the right limit of search area X1max")
                X1min, X1max = X1max - X1_step, X1min + SX1
            elif X1_opt < X1min + EPS:
                vis and print("\tResult is on the left limit of search area X1min")
                X1max, X1min = X1max + X1_step, X1min - SX1
            elif X2_opt > X2max - EPS:
                vis and print("\tResult is on the top limit of search area X2max")
                X2min, X2max = X2max - X2_step, X2min + SX2
            elif X2_opt < X2min + EPS:
                vis and print("\tResult is on the bottom limit of search area X2min")
                X2max, X2min = X2max + X2_step, X2min - SX2
            vis and print(f"\tSearch continues in new limits: "
                          f"X1: [{round(X1min, 3)}; {round(X1max, 3)}] X2: [{round(X2min, 3)}; {round(X2max, 3)}]")
            continue
        else:
            vis and print(f"\tExtremum lies within search area\n Extremum point: [{X1_opt}, {X2_opt}, {Q_opt}]")
            vis and print(f"\tAbsolute error for X1opt is less than {X1_step} and for X2opt is less than {X2_step}")

            X1eps_, X2eps_ = abs(X1_step/X1_opt), abs(X2_step/X2_opt)
            vis and print(f"\tRelative error for X1opt is {X1eps_} and for X2opt {X2eps_}")

            if X1eps_ > X1eps or X2eps_ > X2eps_:
                X1min, X1max = X1_opt - X1_step, X1_opt + X1_step
                X2min, X2max = X2_opt - X2_step, X2_opt + X2_step
                SX1, SX2 = X1max - X1min, X2max - X2min
                vis and print(f"\tSearch area is narrowed\n"
                              f"Search continues in new limits: "
                              f"X1: [{round(X1min, 3)}; {round(X1max, 3)}] X2: [{round(X2min, 3)}; {round(X2max, 3)}]")
                vis and print(f"New grid step for X1 {X1_step} and for X2 {X2_step}")
                continue
            break
    X1opt = (A[2] * A[3] - 2 * A[1] * A[5]) / (4 * A[4] * A[5] - A[3] * A[3])
    X2opt = (A[1] * A[3] - 2 * A[2] * A[4]) / (4 * A[4] * A[5] - A[3] * A[3])
    Qopt = Q_(X1opt, X2opt)
    vis and print(f"Solution Found!\n"
                  f"Analitical Extremum point is "
                  f"[{round(X1opt, 3)}; {round(X2opt, 3)}; {round(Qopt, 3)}]\n"
                  f"Calculated extremum point is "
                  f"[{round(X1_opt, 3)}; {round(X2_opt, 3)}; {round(Q_opt, 3)}]")

    if benchFlag:
        benchFinish = time()
        bench.append(benchFinish - benchStart)
        calcs.append(i*2)


def plotBuild(vis):
    Q_function(vis)
    if vis:
        X1axis = np.linspace(X1_opt if X1_opt < 0 else -X1_opt, -X1_opt if X1_opt < 0 else X1_opt, N + 1, endpoint=True)
        X2axis = np.linspace(X2_opt if X2_opt < 0 else -X2_opt, -X2_opt if X2_opt < 0 else X2_opt, N + 1, endpoint=True)

        X1, X2 = np.meshgrid(X1axis, X2axis)
        Q = Q_(X1, X2)
        fig = plt.figure(num="Лабораторна №3")
        ax = fig.add_subplot(1, 1, 1, projection='3d')
        ax.set_title('Пошук оптимального значення цільової функції')
        ax.set_xlabel('Параметр системи Х1')
        ax.set_ylabel('Параметр системи Х2')
        ax.set_zlabel('Значення цільової функцій Q sys')
        ax.set_title('Пошук оптимального значення цільової функції')

        trajectory, = ax.plot(X1t, X2t, Qt, color='red', zorder=5)
        trajectory.set_label(f"Траекторія пошуку (перші {step_size} кроки(-ів))")
        surf = ax.plot_surface(X1, X2, Q, cstride=1, rstride=1, cmap='winter')
        extremum, = ax.plot(X1_opt, X2_opt, Q_opt, markerfacecolor='r', markeredgecolor='b', marker='o',
                            markersize=10, alpha=0.9, zorder=6)
        extremum.set_label("Точка екстремуму")
        ax.legend()
        plt.ticklabel_format(useOffset=False)
        fig.colorbar(surf)
        mng = plt.get_current_fig_manager()
        mng.window.state('zoomed')
        plt.show()


# Task 1
def Task1(val=3, vis=True):
    global X1min, X1max, X2min, X2max
    global A, N, X1_step, X2_step, extremumType, X1eps, X2eps
    A = [1, 1, 1, 1, 1, 1]
    X1min, X1max, X2min, X2max = 0, 0.01, 0, 0.01
    X1eps, X2eps = 0.005, 0.005
    N = val
    extremumType = 'min'
    X1_step, X2_step = (X1max - X1min) / N, (X2max - X2min) / N
    plotBuild(vis)


# Task 2
def Task2(val=3, vis=True):
    global A, X1min, X1max, X2min, X2max, N, X1_step, X2_step, extremumType, X1eps, X2eps
    A = [0.5, 1.0, 2.2, 0.5, 0.3, 1.3]
    X1min, X1max, X2min, X2max = 0.01, 0.02, 0, 0.01
    X1eps, X2eps = 0.005, 0.005
    N = val
    extremumType = 'min'
    X1_step = (X1max - X1min) / N
    X2_step = (X2max - X2min) / N
    plotBuild(vis)


# Task 3
def Task3():
    global Ns, benchFlag
    benchFlag = True
    calcs.clear()
    bench.clear()
    Ns.clear()
    for i, n in enumerate(np.arange(3, 13, 1)):
        Ns.append(n)
        Task2(n, False)
        print("Steps:", n)
        print("\tCalculation time :", bench[i])
        print("\tNumber of calculations :", calcs[i])

    fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(8, 5))
    fig.suptitle('Графік залежності затрат на пошук екстремуму від значення N')
    fig.canvas.manager.set_window_title("Лабораторна №3")

    ax1.plot(Ns, bench)
    ax1.set_xlabel("Крок N")
    ax1.set_ylabel("Час пошуку S, с")

    ax2.plot(Ns, calcs)
    ax2.set_xlabel("Крок N")
    ax2.set_ylabel("Кількість обчислень C")

    for h, c in zip(Ns, calcs):
        label = "{:d}".format(c)
        ax2.annotate(
            label,
            (h, c),
            textcoords="offset points",
            xytext=(-5, 5),
            ha="center"
        )

    fig.tight_layout()
    plt.show()


# Lab menu
def menu(argument):
    switcher = {
        0: exit,
        1: Task1,
        2: Task2,
        3: Task3
    }
    func = switcher.get(argument, lambda: print("No such option!\n"))
    func()


# Entry point
while True:
    print("Lab 3 menu:")
    print("""
1.  Task 1
2.  Task 2
3.  Task 3
0. Exit
    """)
    try:
        task = int(input("Enter task number: "))
        menu(task)
    except ValueError:
        print("That was no valid number. Try again...\n")
