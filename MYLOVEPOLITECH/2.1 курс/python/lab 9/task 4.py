import matplotlib.pyplot as plt
import re


class KmrCsv:
    def __init__(self, ref, num):
        self._ref = ref
        self._num = num
        self._cached = False
        self._cache_info()

    def _cache_info(self):
        if self._cached:
            return

        with open(self._ref, encoding='utf-8') as file:
            self.data = file.read()
            self._num_of_students = len(self.data.split('\n')[:-1])

        id_regex = r'^([^,]+),'
        time_regex = r'(\d{1,2}) хв[, ](\d{1,2})?'
        mark_regex = r'(?:(\d),(\d\d))|\n'
        self.id_matches = re.findall(id_regex, self.data, re.MULTILINE)
        self.time_matches = re.findall(time_regex, self.data, re.IGNORECASE & re.MULTILINE)
        self._mark_matches = re.findall(mark_regex, self.data, re.MULTILINE)[:-1]

        mark_matches = list(self._mark_matches)
        self.marks = [0]
        mark_index = 0
        mark_match_index = 0
        # Користуючись списком оцінок за принципом черги (FIFO - queue)
        while mark_match_index != len(mark_matches):
            # Якщо наступний збіг - пуста стрічка, то далі починається новий тест
            if mark_matches[mark_match_index][0] == '':
                self.marks.append(0)
                mark_index += 1
                mark_matches.pop(0)
                continue
            # Отримуємо бал за питання, додаємо 1 до відповідного масиву та саму оцінку до суми оцінок за тест
            result = round(int(mark_matches[mark_match_index][0]) + int(mark_matches[mark_match_index][1]) / 100, 2)
            if result != 0:
                self.marks[mark_index] += result
            mark_matches.pop(0)

        for m in range(len(self.marks)):
            # print(self.marks[m])
            self.marks[m] = round(self.marks[m], 2)
        self._cached = True

    def set_ref(self, new_ref):
        self._ref = new_ref
        self._cached = False

    def get_ref(self):
        return self._ref

    def set_num(self, new_num):
        self._num = new_num
        self._cached = False

    def get_num(self):
        return self._num

    def print_info(self):
        if not self._cached:
            self._cache_info()
        print(f"Kmr #{self._num}. Number of students: {self._num_of_students}")


class Statistic:
    def avg_stat(self):
        if not isinstance(self, KmrWork):
            return

        mark_matches = list(self._mark_matches)
        mark_match_index = 0
        task_stats = [[0, 0]]
        task_index = 0
        # Користуючись списком оцінок за принципом черги (FIFO - queue)
        while mark_match_index != len(mark_matches):
            # Якщо наступний збіг - пуста стрічка, то далі починається новий тест
            if mark_matches[mark_match_index][0] == '':
                mark_matches.pop(0)
                task_index = 0
                continue
            # Отримуємо бал за питання, додаємо 1 до відповідного масиву
            result = round(int(mark_matches[mark_match_index][0]) + int(mark_matches[mark_match_index][1]) / 100, 2)
            if len(task_stats) == task_index:
                task_stats.append([0, 0])
            if result != 0:
                task_stats[task_index][0] += 1
            else:
                task_stats[task_index][1] += 1
            task_index += 1
            mark_matches.pop(0)

        conv_list = []
        for stat in task_stats:
            conv_list.append(round(stat[0] / (stat[0] + stat[1]), 2) * 100)

        return tuple(conv_list)

    def marks_stat(self):
        if not isinstance(self, KmrWork):
            return

        mark_dict = {}
        for mark in self.marks:
            if mark not in mark_dict:
                mark_dict[mark] = 1
            mark_dict[mark] += 1

        return mark_dict

    def marks_per_time(self):
        if not isinstance(self, KmrWork):
            return

        mark_matches = list(self._mark_matches)
        time_matches = list(self.time_matches)
        marks = list(self.marks)
        ids = self.id_matches

        mark_per_min = {}

        for id_index in range(len(ids)):
            mark_per_min[ids[id_index]] = round(marks[id_index] / int(time_matches[id_index][0]), 2)

        return mark_per_min

    def best_marks_per_time(self, bottom_margin, top_margin):
        if not isinstance(self, KmrWork):
            return

        marks_per_time = list(self.marks_per_time().values())

        indexes = []
        marks = self.marks
        for mark_index in range(len(marks)):
            if bottom_margin <= marks[mark_index] <= top_margin:
                indexes.append(mark_index)

        conv_list = []
        ids = self.id_matches
        for index in indexes:
            conv_list.append((ids[index], marks[index], marks_per_time[index]))

        conv_list.sort(key=lambda x: x[2], reverse=True)

        return tuple(conv_list[:5])


class Plots:
    def __init__(self, cat):
        self.cat = cat

    def set_cat(self, cat):
        self.cat = cat

    def avg_plot(self, stat):
        plt.xticks(range(len(stat)))
        plt.ylabel('правильних відповідей, %')
        plt.xlabel('запитання, №')
        plt.bar(range(len(stat)), stat)
        plt.savefig(self.cat + "/avg_plot.png")

    def marks_plot(self, stat):
        plt.ylabel('кількість студентів')
        plt.xlabel('оцінка')
        plt.xticks(list(stat.keys()))
        plt.yticks(range(len(list(stat.keys()))))
        plt.bar(list(stat.keys()), list(stat.values()))
        plt.savefig(self.cat + "/marks_plot.png")

    def best_marks_plot(self):
        if not isinstance(self, KmrWork):
            return

        data = self.best_marks_per_time(0, 100)
        mark = [*map(lambda x: x[1], data)]
        avg_mark = [*map(lambda x: x[2], data)]

        plt.xlabel("середній бал")
        plt.ylabel("бал")
        plt.bar(avg_mark, mark, .1)
        plt.savefig(self.cat + "/best_marks_plot.png")


class KmrWork(KmrCsv, Statistic, Plots):
    kmrs = {}
    cat = "new folder"

    def __init__(self, ref, num):
        super().__init__(ref, num)
        self.set_cat(self.cat)
        KmrWork.kmrs[num] = ref

    @staticmethod
    def compare_csv(kmrA, kmrB):
        id_matches = list(kmrA.id_matches)
        id_matches.extend(kmrB.id_matches)
        id_matches = list(set(id_matches))
        kmr_performants = {}
        for identity in id_matches:
            kmr_performants[identity] = 0
            if identity in kmrA.id_matches:
                kmr_performants[identity] += 1
            if identity in kmrB.id_matches:
                kmr_performants[identity] += 1
        marksA, marksB, marks_r = kmrA.marks, kmrB.marks, []
        for mark in range(len(marksA)):
            marks_r.append((marksA[mark] + marksB[mark]) / 2)
        timesA, timesB, times_r = kmrA.time_matches, kmrB.time_matches, []
        for time in range(len(timesA)):
            times_r.append((int(timesA[time][0]) + int(timesB[time][0])) / 2)

        with open("csv_comparation.txt", mode='w', encoding="utf-8") as f:
            print(kmr_performants, marks_r, times_r, file=f, sep='\n')

    @staticmethod
    def compare_avg_plots(kmrA, kmrB):
        kmrA.avg_plot(kmrA.avg_stat())
        kmrB.avg_plot(kmrB.avg_stat())


# kmr1 = KmrWork("marks.2.csv", 1)
# kmr2 = KmrWork("marks.2.csv", 2)
# print(kmr1.avg_stat())
# print(kmr1.marks_stat())
# print(kmr1.marks_per_time())
# print(kmr1.best_marks_per_time(5, 15))

# kmr1.avg_plot(kmr1.avg_stat())
# kmr1.marks_plot(kmr1.marks_stat())
# kmr1.best_marks_plot()

# kmr1.compare_csv(kmr1, kmr2)
# kmr1.compare_avg_plots(kmr1, kmr2)

# # Tests
kmr1 = KmrWork("marks.1.csv", 1)
kmr2 = KmrWork('marks.2.csv', 2)

kmr2.avg_plot(kmr2.avg_stat())
kmr2.marks_plot(kmr2.marks_stat())

KmrWork.compare_csv(kmr1, kmr2)
KmrWork.compare_avg_plots(kmr1, kmr2)