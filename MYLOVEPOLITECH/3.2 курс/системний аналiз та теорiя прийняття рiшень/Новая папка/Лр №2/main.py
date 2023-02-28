import numpy as np
import matplotlib.pyplot as plt
import math
from time import time


# Number of steps for trajectory
step_size = 5

# A coefficients
A = []

# Search limits
X1min = 0
X1max = 0
X2min = 0
X2max = 0

# Search initial coordinates
X1start = 0
X2start = 0

# ExtremumType
extremumType = ''

# Eps
eps = 0.01

# Delta X
deltaX = 0.001

# Constatnt
h = 0

# Axes arrays
X1s = []
X2s = []
Qs = []

# Search Trajectory Arrays
X1t = []
X2t = []
Qt = []

# Extremum approximate coordinates
X1opt = 0
X2opt = 0
Qopt = 0

# Extremum point
extr = []

# Benchmark
benchFlag = False
bench = []
hs = []
calcs = []


def Q_function(X1, X2):
    return A[0] + A[1] * X1 + A[2] * X2 + A[3] * X1 * X2 + A[4] * X1 * X1 + A[5] * X2 * X2


def G_function():
    global X1opt, X2opt, Qopt
    global X1s, X2s, Qs
    global X1t, X2t, Qt
    global extr, bench, benchFlag, calcs

    Qs.clear()
    X1s.clear()
    X2s.clear()

    Qt.clear()
    X1t.clear()
    X2t.clear()

    x1 = X1start
    x2 = X2start
    i = 0
    q = float("inf")
    modG = float("inf")

    if benchFlag:
        benchStart = time()

    while modG > eps and q != Q_function(x1, x2):
        q = Q_function(x1, x2)
        grad = (
            (Q_function(x1 + deltaX, x2) - q) / deltaX,
            (Q_function(x1, x2 + deltaX) - q) / deltaX
        )
        switch = 1 if extremumType == 'max' else -1
        modG = math.sqrt(grad[0] ** 2 + grad[1] ** 2)

        if i < step_size:
            X1t.append(x1)
            X2t.append(x2)
            Qt.append(q)

        X1s.append(x1)
        X2s.append(x2)
        Qs.append(q)

        i += 1

        x1 = x1 + h * switch * grad[0]
        x2 = x2 + h * switch * grad[1]

    if modG <= eps:
        extr = [x1, x2, q]
        X1opt = (A[2] * A[3] - 2 * A[1] * A[5]) / (4 * A[4] * A[5] - A[3] * A[3])
        X2opt = (A[1] * A[3] - 2 * A[2] * A[4]) / (4 * A[4] * A[5] - A[3] * A[3])
        Qopt = Q_function(X1opt, X2opt)

        if benchFlag:
            benchFinish = time()
            bench.append(benchFinish - benchStart)
            calcs.append(i * 3)

        return (min(X1s), max(X1s)), (min(X2s), max(X2s))


def plotBuild(visual=False):
    (X1min, X1max), (X2min, X2max) = G_function()

    X1axis = np.linspace(X1min, X1max, len(X1s) + 1, endpoint=True)
    X2axis = np.linspace(X2min, X2max, len(X2s) + 1, endpoint=True)

    X1, X2 = np.meshgrid(X1axis, X2axis)
    Q = Q_function(X1, X2)

    print(f"Extremum", *extr)
    print(f"Approximate extremum", X1opt, X2opt, Qopt)

    if visual:
        fig = plt.figure(num='Оптимізація цільової функції градієнтним методом')
        ax = fig.add_subplot(111, projection="3d")
        ax.set_xlabel('Параметр системи Х1')
        ax.set_ylabel('Параметр системи Х2')
        ax.set_zlabel('Значення цільової функцій Q sys')
        ax.set_title('Пошук оптимального значення цільової функції')

        plt.scatter(X1s, X2s, Qs)
        trajectory, = ax.plot(X1t, X2t, Qt, color='red', zorder=5)
        trajectory.set_label(f"Траекторія пошуку (перші {step_size} кроки(-ів))")
        surf = ax.plot_surface(X1, X2, Q, cstride=1, rstride=1, cmap='winter')
        extremum, = ax.plot(X1opt, X2opt, Qopt, markerfacecolor='r', markeredgecolor='b', marker='o', markersize=10,
                            alpha=0.9, zorder=6)
        extremum.set_label("Точка екстремуму")
        ax.legend()
        plt.ticklabel_format(useOffset=False)
        plt.colorbar(surf)
        plt.show()


# Task 1
def Task1(val=0.2, vis=True):
    global A, extremumType, h, X1start, X2start
    A = [0.5, 1.0, 2.2, 0.5, 0.3, 1.3]
    X1start, X2start = 1, 0
    h = val
    extremumType = 'min'
    plotBuild(vis)


# Task 2
def Task2():
    global hs, benchFlag
    benchFlag = True
    calcs.clear()
    bench.clear()
    hs.clear()
    h, i = 0.2, 0
    while h <= 1.0:
        hs.append(h)
        print("h :", h)
        Task1(h, False)
        h += 0.2
        h = round(h, 1)
        print("Calculation time :", bench[i])
        print("Number of calculations :", calcs[i])
        i += 1

    fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(8, 5))
    fig.canvas.set_window_title('Графік залежності затрат на пошук екстремуму від значення h')

    ax1.plot(hs, bench)
    ax1.set_xlabel("Коефіцієнт h")
    ax1.set_ylabel("Час пошуку S, с")

    ax2.plot(hs, calcs)
    ax2.set_xlabel("Коефіцієнт h")
    ax2.set_ylabel("Кількість обчислень C")

    for h, c in zip(hs, calcs):
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
