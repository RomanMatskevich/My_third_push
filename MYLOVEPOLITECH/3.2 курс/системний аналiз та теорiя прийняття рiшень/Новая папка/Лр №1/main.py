import numpy as np
import matplotlib.pyplot as plt
import sys
import time
import operator
# A coefficients
A = []

# Search limits
X1min = 0
X1max = 0
X2min = 0
X2max = 0

# Q_opt equals maximum float number
Q_opt = 0
X1_opt = 0
X2_opt = 0

# Number of sections on axes X1 and X2
N = 0

# Number of nodes to be tested
M = N + 1

# Steps
X1_step = 0
X2_step = 0

# ExtremumType
extremumType = ''

# Search Trajectory Arrays
X1s = []
X2s = []
Qs = []
Ns = []

# Benchmark
bench = []


def Q_function(X1, X2, benchFlag):
    global Q_opt, X1_opt, X2_opt, bench, X1s, X2s, Qs
    Q_opt = sys.float_info.max if extremumType == 'min' else sys.float_info.min
    compare = operator.lt if extremumType == 'min' else operator.gt
    Qs.clear()
    X1s.clear()
    X2s.clear()
    if benchFlag:
        benchStart = time.time()
    x1 = X1min
    while x1 <= X1max:
        x2 = X2min
        while x2 <= X2max:
            q = A[0] + A[1]*x1 + A[2]*x2 + A[3]*x1*x2 + A[4]*x1**2 + A[5]*x2**2
            if compare(q, Q_opt):
                Q_opt = q
                X1_opt = x1
                X2_opt = x2
            X1s.append(x1)
            X2s.append(x2)
            Qs.append(q)
            x2 += X2_step
        x1 += X1_step
    if benchFlag:
        benchFinish = time.time()
        bench.append(benchFinish - benchStart)
    else:
        print(f"Extremum point is [{X1_opt}; {X2_opt}; {Q_opt}]")
        return A[0] + A[1]*X1 + A[2]*X2 + A[3]*X1*X2 + A[4]*X1**2 + A[5]*X2**2


def plotBuild():
    X1axis = np.linspace(X1min, X1max, N + 1, endpoint=True)
    X2axis = np.linspace(X2min, X2max, N + 1, endpoint=True)

    X1, X2 = np.meshgrid(X1axis, X2axis)
    Q = Q_function(X1, X2, False)

    fig = plt.figure(num='Оптимізація цільової функції методом прямого перебору')
    ax = fig.add_subplot(111, projection="3d")
    ax.set_xlabel('Параметр системи Х1')
    ax.set_ylabel('Параметр системи Х2')
    ax.set_zlabel('Значення цільової функцій Q sys')
    ax.set_title('Пошук оптимального значення цільової функції')

    plt.scatter(X1s, X2s, Qs)
    trajectory, = ax.plot(X1s, X2s, Qs, color='red', zorder=5)
    trajectory.set_label("Траекторія пошуку")

    surf = ax.plot_surface(X1, X2, Q, rstride=1, cstride=1, cmap='Greys', edgecolor='none')
    extremum, = ax.plot(X1_opt, X2_opt, Q_opt, markerfacecolor='r', markeredgecolor='b', marker='o', markersize=10,
                        alpha=0.9, zorder=6)
    extremum.set_label("Точка екстремуму")
    ax.legend()
    plt.ticklabel_format(useOffset=False)
    plt.colorbar(surf)
    plt.show()


# Task 1
def Task1():
    global A, X1min, X1max, X2min, X2max, N, X1_step, X2_step, extremumType
    A = [1, 1, 1, 1, 1, 1]
    X1min = 0
    X1max = 1
    X2min = 0
    X2max = 1
    N = 3
    extremumType = 'min'
    X1_step = (X1max - X1min) / N
    X2_step = (X2max - X2min) / N
    plotBuild()


# Task 2
def Task2():
    global A, X1min, X1max, X2min, X2max, N, X1_step, X2_step, extremumType
    A = [0.5, 1.0, 2.2, 0.5, 0.3, 1.3]
    X1min = 1
    X1max = 2
    X2min = 0
    X2max = 1
    N = 5
    extremumType = 'min'
    X1_step = (X1max - X1min) / N
    X2_step = (X2max - X2min) / N
    plotBuild()

    N = 1
    bench_opt = 0
    f = plt.figure(num='Оптимізація цільової функції методом прямого перебору')
    ax = f.add_subplot(111)
    for x in range(101):
        X1_step = (X1max - X1min) / N
        X2_step = (X2max - X2min) / N
        Q_function([], [], True)
        Ns.append(N)
        if bench[-1] <= bench_opt:
            bench_opt = bench[-1]
            print(f"Optimal number of segments {N} for best time of {bench_opt} seconds")
            ax.plot(N, bench[-1], 's:k')
        N += 1
    ax.plot(Ns, bench)
    ax.set_xlabel("Число відрізків N")
    ax.set_ylabel("Час пошуку S, с")
    plt.show()


# Lab menu
def menu(argument):
    switcher = {
        0: exit,
        1: Task1,
        2: Task2
    }
    func = switcher.get(argument, lambda: print("No such option!\n"))
    func()


# Entry point
while True:
    print("Lab 1 menu:")
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
