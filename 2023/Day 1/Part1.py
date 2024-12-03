line_values = {}
total = 0

with open('input.txt', 'r') as file:
    for line in file:
        line = line.strip()
        line_values[line] = []
        for char in line:
            if char.isdigit():
                line_values[line].append(int(char))

for key, values in line_values.items():
    total += int(str(values[0]) + str(values[-1]))

print(total)  # 54338
