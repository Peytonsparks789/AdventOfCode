GAME_DICT = {}
TOTAL = 0


def split_string():
    with open('input.txt', 'r') as file:
        for line in file:
            red, blue, green = 0, 0, 0

            line = line.replace(';', ',')

            # Split our string where game values begin
            split_value = line.split(': ')

            for value in split_value[1].split(', '):
                if 'red' in value and int(value.split(' red')[0]) > red :
                    red = int(value.split(' red')[0])
                elif 'blue' in value and int(value.split(' blue')[0]) > blue:
                    blue = int(value.split(' blue')[0])
                elif 'green' in value and int(value.split(' green')[0]) > green:
                    green = int(value.split(' green')[0])

            GAME_DICT[split_value[0].replace('Game ', '')] = [red, blue, green]


def get_total():
    global TOTAL
    for key, values in GAME_DICT.items():
        TOTAL += values[0] * values[1] * values[2]


split_string()
get_total()

print(TOTAL)

# 67363
