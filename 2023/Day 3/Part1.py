class Parser:
    def __init__(self):
        self._array = []
        self._total = 0
        self._file = 'input.txt'

    @property
    def total(self):
        return self._total

    def get_array(self):
        with open(self._file, 'r') as f:
            for line in f:
                row = [char for char in line.strip()]
                self._array.append(row)

    def find_num_end(self, row_num, pos):
        row = self._array[row_num]
        for i in range(pos + 1, len(row)):
            if not row[i].isdigit():
                return i - 1
        return len(row) - 1

    @staticmethod
    def get_num(row_data, pos, end_pos):
        num_str = ''.join(row_data[pos:end_pos + 1])
        return int(num_str)

    def check_current_row(self, row_num, pos, end_pos):
        row = self._array[row_num]
        if pos > 0 and row[pos - 1] != '.':
            return True
        if end_pos + 1 < len(row) and row[end_pos + 1] != '.':
            return True
        return False

    def check_lower_row(self, row_num, pos, end_pos):
        if row_num + 1 < len(self._array):  # Ensure the lower row exists
            for i in range(max(0, pos - 1), min(end_pos + 2, len(self._array[row_num + 1]))):
                if self._array[row_num + 1][i] != '.' and not self._array[row_num + 1][i].isdigit():
                    return True
        return False

    def check_upper_row(self, row_num, pos, end_pos):
        if row_num - 1 >= 0:  # Ensure the upper row exists
            for i in range(max(0, pos - 1), min(end_pos + 2, len(self._array[row_num - 1]))):
                if self._array[row_num - 1][i] != '.' and not self._array[row_num - 1][i].isdigit():
                    return True
        return False

    def parse_array(self, row_num, pos, end_pos):
        row_data = self._array[row_num]
        if (self.check_current_row(row_num, pos, end_pos) or
                self.check_lower_row(row_num, pos, end_pos) or
                self.check_upper_row(row_num, pos, end_pos)):
            self._total += self.get_num(row_data, pos, end_pos)

    def read_row(self):
        for row_num, row_data in enumerate(self._array):  # Scan over each row in the array
            pos = 0
            while pos < len(row_data):  # Scan over each character in the row
                if row_data[pos].isdigit():
                    end_pos = self.find_num_end(row_num, pos)
                    self.parse_array(row_num, pos, end_pos)
                    pos = end_pos + 1
                else:
                    pos += 1


if __name__ == '__main__':
    parser = Parser()
    parser.get_array()
    parser.read_row()
    print(parser.total)

#  517021
