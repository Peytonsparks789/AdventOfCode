NUMBER_MAP = {
    'one':   1, 'two':   2,
    'three': 3, 'four':  4,
    'five':  5, 'six':   6,
    'seven': 7, 'eight': 8,
    'nine':  9
}

with open('input.txt', 'r') as file:
    LINE_VALUES = {}
    for line in file:
        line = line.strip()
        LINE_VALUES[line] = []

        TOTAL = 0
        BUFFER = ''

        for char in line:
            BUFFER += char
            if char.isdigit():
                LINE_VALUES[line].append(int(char))
            else:
                for num in NUMBER_MAP:
                    if num in BUFFER[-len(BUFFER):]:
                        LINE_VALUES[line].append(NUMBER_MAP[num])
                        BUFFER = BUFFER[-(len(BUFFER)-(len(BUFFER)-2)):]

for key, values in LINE_VALUES.items():
    TOTAL += int(str(values[0]) + str(values[-1]))
    print()

print(TOTAL)

# 53389