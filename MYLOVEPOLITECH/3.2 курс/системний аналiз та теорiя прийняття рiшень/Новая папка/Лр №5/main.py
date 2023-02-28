import numpy as np


def pareto_set(X):
    print("\nPareto's optimal set of vectors:")
    n = X.shape[0]
    i = 0
    while i < n:
        for j in range(i + 1, n, 1):
            m = min(X[i] - X[j])
            q = min(X[j] - X[i])
            if m >= 0:
                X = np.delete(X, j, 0)
                i -= 1
                break
            elif q >= 0:
                X = np.delete(X, i, 0)
                i -= 1
                break
        i += 1
        n = X.shape[0]
    return np.around(X, 2)


def pareto_comperss(X):
    print("\nPareto's set compression with regard to criterias")
    i = int(input("Enter the most influental criteria index: ")) - 1
    ai, a = map(float, input("Enter the first criteria index and sacrifice value: ").split())
    bi, b = map(float, input("Enter the second criteria index and sacrifice value: ").split())
    a, b = a / (a + 1), b / (b + 1)
    ai, bi = int(ai - 1), int(bi - 1)
    X = X.astype(float)
    X[:, ai] = X[:, i] * a + (1 - a) * X[:, ai]
    X[:, bi] = X[:, i] * b + (1 - b) * X[:, bi]
    print("PY* =\n", np.round(X, 2))
    return pareto_set(X)


def main_criteria(X):
    print("\nMain criteria method")
    i = int(input("Enter an index of main criteria i = "))
    t = list(float(x) for x in input("Enter a vector m-1| bound values = ").split()[:X.shape[1]])
    n = X.shape[0]
    p = X.shape[1]
    tl = t[:i - 1]
    tr = t[i:p]
    ti = min(X[:, i - 1])
    tc = []
    tc.extend(tl)
    tc.append(ti)
    tc.extend(tr)
    P = X
    k = 0
    for v in range(1, n):
        m = min(X[v, :] - tc)
        j = v - k
        if m < 0:
            P = np.delete(P, j, 0)
            k += 1
    return P[np.argmax(P[:, i - 1])]


def linear_convolution(X):
    print("\nLinear Convolution method")
    a = float(input("Enter weighting factor a = "))
    b = X * a
    return X[np.argmax(b.sum(axis=1))]


def multiplicative_convolution(X):
    print("\nMultiplicative Convolution method")
    a = float(input("Enter weighting factor a = "))
    m = X.shape[0]
    a = np.array([a]*m).T.reshape(m, 1)
    b = np.asmatrix(np.multiply(X, a)).H
    return X[np.argmax(b.prod(axis=0))]


def maxmin_convolution(X):
    print("\nMaxmin Convolution method")
    a = float(input("Enter weighting factor a = "))
    m = X.shape[0]
    a = np.array([a] * m).T.reshape(m, 1)
    b = np.asmatrix(np.multiply(X, a)).H
    return X[np.argmax(np.amin(b, axis=0))]


Y = np.array([
    [9, 4, 9, 5, 5, 6],
    [1, 2, 7, 3, 5, 4],
    [1, 2, 5, 4, 4, 5],
    [1, 4, 5, 5, 5, 4],
    [1, 9, 8, 3, 3, 3],
    [8, 6, 5, 3, 5, 3],
    [7, 4, 9, 3, 4, 5]
])

print('Y =\n', Y)
PY = pareto_set(Y)
print('PY =\n', PY)
PY = pareto_comperss(PY)
print('PY’ =\n', PY)
Fo = main_criteria(PY)
print('Fo =', Fo)
Fo = linear_convolution(PY)
print('Fo =', Fo)
Fo = multiplicative_convolution(PY)
print('Fo =', Fo)
Fo = maxmin_convolution(PY)
print('Fo =', Fo)
