import numpy as np
import matplotlib.pyplot as plt
from math import sqrt

np.set_printoptions(suppress=True)


def OB(n, c1, c2, s, T):
    return round(n * (c1 * s + c2) / T, 1)


def ks_delta(n, c1, T, pt, pt2, ks=3):
    return round(((c1 / T) * sqrt(((n - 1) / n) * (pt - pt2))) * ks, 1)


def To(n, c1, c2, T_ind, T_val):
    s_pt = []
    ob_t = []
    table = np.asmatrix(np.zeros((len(T_ind), 4)))
    T_opt = {}

    for T in T_ind:
        s = round(sum(T_val[:T - 1]), 2)
        s_pt.append(s)
        ob_t.append(OB(n, c1, c2, s, T))

    for i, col in enumerate([T_ind, T_val, s_pt, ob_t]):
        table[:, i] = np.asarray(col).reshape(5, 1).tolist()

    ob_t.insert(0, 0)
    ob_t.append(0)

    for T in T_ind:
        if ob_t[T - 1] >= ob_t[T] <= ob_t[T + 1]:
            T_opt = {
                'OB(T)': ob_t[T],
                'T*': T
            }
    return T_opt, table.tolist()


def dispersion(n, c1, c2, T_ind, T_val):
    T_val2 = []
    s_pt = []
    s_pt2 = []
    ob_t = []
    s_dev = []
    table = np.asmatrix(np.zeros((len(T_ind), 6)))
    T_opt = {}
    for T in T_ind:
        T_val2.append(round(T_val[T - 1] ** 2, 4))
        s = round(sum(T_val[:T - 1]), 2)
        s2 = round(sum(T_val2[:T - 1]), 4)
        s_pt.append(s)
        s_pt2.append(s2)
        ob_t.append(OB(n, c1, c2, s, T))
        s_dev.append(ks_delta(n, c1, T, s, s2))

    ob_t_ks_delta = np.add(ob_t, s_dev).tolist()
    for i, col in enumerate([T_ind, T_val, T_val2, s_pt, s_pt2, ob_t_ks_delta]):
        table[:, i] = np.asarray(col).reshape(5, 1)

    ob_t_ks_delta.insert(0, 0)
    ob_t_ks_delta.append(0)

    for T in T_ind:
        if ob_t_ks_delta[T - 1] >= ob_t_ks_delta[T] <= ob_t_ks_delta[T + 1]:
            T_opt = {
                'OB(T) + ksσ(BT)': ob_t_ks_delta[T],
                'T*': T
            }
    return T_opt, table.tolist()


n = 40
c1, c2 = 150, 12
T_ind = range(1, 6)
T_val = [.06, .1, .13, .16, .2]

t1, table1 = To(n, c1, c2, T_ind, T_val)
t2, table2 = dispersion(n, c1, c2, T_ind, T_val)

print('Згідно критерію очікуваного значення, '
      'оптимальним періодом для виконання'
      ' профілактичного ремонту є', t1['T*'], 'період')
print('Згідно критерію очікуваного значення-дисперсії, '
      'оптимальним періодом для виконання'
      ' профілактичного ремонту є', t2['T*'], 'період')

data = [table1, table2]

columns = [
    ['T', 'p_t', 'Σp_t', 'OB(T)'],
    ['T', 'p_t', 'p_t^2', 'Σp_t', 'Σp_t^2', 'OB + ksσ(B_T)']
]

methods = ['Expected value criterion', 'Expected value-dispersion criterion']

fig, ax = plt.subplots(2, 1, figsize=(10, 6))
for i, ax in enumerate(ax):
    ax.set_title(methods[i], fontweight='bold')
    cell_text = []
    ax.axis('tight')
    ax.axis('off')
    table = ax.table(
        cellText=data[i],
        colLabels=columns[i],
        cellLoc='center',
        loc='upper center'
    )
    table.auto_set_font_size(False)
    table.set_fontsize(14)
    table.scale(1.5, 1.5)
fig.canvas.manager.set_window_title("Lab 7")
fig.tight_layout()
plt.show()
