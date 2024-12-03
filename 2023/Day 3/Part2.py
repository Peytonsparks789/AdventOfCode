class Parser:
    def __init__(self):
        self._array = []
        self._total = 0
        self._file = 'input.txt'

    @property
    def total(self):
        return self._total

    @total.setter
    def total(self, value):
        self._total += value

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

    def search_adjacent(self, pos, row_num):
        num_bank = []
        # Check the row above
        if row_num - 1 >= 0:
            for i in range(max(0, pos - 1), min(pos + 2, len(self._array[row_num - 1]))):
                if self._array[row_num - 1][i].isdigit():
                    num_bank.append([row_num - 1, i])
        # Check the row below
        if row_num + 1 < len(self._array):  # Ensure the lower row exists
            for i in range(max(0, pos - 1), min(pos + 2, len(self._array[row_num + 1]))):
                if self._array[row_num + 1][i].isdigit():
                    num_bank.append([row_num + 1, i])
        # Check the left cell in the same row
        if pos > 0 and self._array[row_num][pos - 1].isdigit():
            num_bank.append([row_num, pos - 1])
        # Check the right cell in the same row
        if pos + 1 < len(self._array[row_num]) and self._array[row_num][pos + 1].isdigit():
            num_bank.append([row_num, pos + 1])

        unique_num_bank = []
        for i in range(len(num_bank)):
            if i == 0 or num_bank[i][0] != num_bank[i - 1][0] or num_bank[i][1] != num_bank[i - 1][1] + 1:
                unique_num_bank.append(num_bank[i])

        return unique_num_bank

    def find_num_start(self, adjacent_numbers):
        new_list = []
        for gear in adjacent_numbers:
            while gear[1] >= 0:
                if self._array[gear[0]][gear[1]-1].isdigit():
                    gear[1] -= 1
                else:
                    new_list.append([gear[0], gear[1]])
                    break
        return new_list

    def read_row(self):
        for row_num, row_data in enumerate(self._array):  # Scan over each row in the array
            pos = 0
            while pos < len(row_data):  # Scan over each character in the row
                if row_data[pos] == '*':
                    adjacent_numbers = self.search_adjacent(pos, row_num)
                    if len(adjacent_numbers) == 2:
                        num1, num2 = 0, 0
                        adjacent_numbers = self.find_num_start(adjacent_numbers)

                        end_pos = self.find_num_end(adjacent_numbers[0][0], adjacent_numbers[0][1])
                        num1 = self.get_num(self._array[adjacent_numbers[0][0]], adjacent_numbers[0][1], end_pos)

                        end_pos = self.find_num_end(adjacent_numbers[1][0], adjacent_numbers[1][1])
                        num2 = self.get_num(self._array[adjacent_numbers[1][0]], adjacent_numbers[1][1], end_pos)

                        self.total = num1 * num2
                    pos += 1
                else:
                    pos += 1


if __name__ == '__main__':
    parser = Parser()
    parser.get_array()
    parser.read_row()
    print(parser.total)

#  81296995
