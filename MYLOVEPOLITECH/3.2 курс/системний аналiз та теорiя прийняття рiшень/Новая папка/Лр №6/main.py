import numpy as np
import matplotlib.pyplot as plt


def minimax(D):
    eir = np.amin(D, axis=1)
    x = np.append(D, np.asmatrix(eir).H, axis=1)
    r = np.zeros(eir.shape[0])
    for _ in np.argwhere(eir == np.amax(eir)):
        r[_] = np.amax(eir)
    x = np.append(x, np.asmatrix(r).H, axis=1)
    return D[np.argwhere(eir == np.amax(eir)).flatten()], x.tolist()


def bayes_laplace(D):
    qj = np.asmatrix(
        list(float(x) for x in input("\nEnter a state probability vector qj = ").split()[:D.shape[1]])
    )
    eir = np.sum(np.multiply(D, qj), axis=1)
    x = np.append(D, np.asmatrix(eir), axis=1)
    r = np.zeros(eir.shape[0])
    for _ in np.argwhere(eir == np.amax(eir)).flatten()[:-1]:
        r[_] = np.amax(eir)
    x = np.append(x, np.asmatrix(r).H, axis=1)
    return D[np.argwhere(eir == np.amax(eir)).flatten()[:-1]], x.tolist()


def savage(D):
    a = np.amax(D, axis=0) - D
    eir = np.amax(a, axis=1)
    x = np.append(a, np.asmatrix(eir).H, axis=1)
    r = np.zeros(eir.shape[0])
    for _ in np.argwhere(eir == np.amin(eir)):
        r[_] = np.amin(eir)
    x = np.append(x, np.asmatrix(r).H, axis=1)
    return D[np.argwhere(eir == np.amin(eir)).flatten()], x.tolist()


D = np.array([
    [-12, -14, -25],
    [- 7, -15, -28],
    [- 3, -16, -32],
    [+ 0, -18, -38]
])

print("|| d_ij || = \n", D)
mmv, mma = minimax(D)
blv, bla = bayes_laplace(D)
svgv, svga = savage(D)
print("\nMinimax method Fo =", *mmv)
print("\nBayes-Laplace method Fo =", *blv)
print("\nSavage method Fo =", *svgv)

columns = [[f"T{x}" for x in range(1, 4)]] * 3
rows = list([f"D{x}" for x in range(1, 5)])
data = [mma, bla, svga]

headers = [
    ['e_ir = min e_ij', 'max e_ir'],
    ['e_ir = Σ(e_ij q_j)', 'max e_ir'],
    ['e_ir = max a_ij', 'min e_ir']
]
methods = ['Minimax method', 'Bayes-Laplace method', 'Savage method']

fig, ax = plt.subplots(3, 1, figsize=(10, 6))
for i, ax in enumerate(ax):
    ax.set_title(methods[i], fontweight='bold')
    cell_text = []
    ax.axis('tight')
    ax.axis('off')
    table = ax.table(
        cellText=data[i],
        rowLabels=rows,
        colLabels=columns[i] + headers[i],
        cellLoc='center',
        loc='upper center'
    )
    table.auto_set_font_size(False)
    table.set_fontsize(14)
    table.scale(1.5, 1.5)
fig.canvas.manager.set_window_title("Lab 6")
fig.tight_layout()
plt.show()
