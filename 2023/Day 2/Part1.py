GAME_DICT = {}
TOTAL = 0
MAX_VALUES = {
    'red': 12,
    'blue': 14,
    'green': 13
}


def split_string():
    with open('input.txt', 'r') as file:
        for line in file:
            valid_game = True

            line = line.replace(';', ',')

            # Split our string where game values begin
            split_value = line.split(': ')

            dice_values = split_value[1].split(', ')
            for value in dice_values:
                if 'red' in value and int(value.split(' red')[0]) > MAX_VALUES['red']:
                    valid_game = False
                elif 'blue' in value and int(value.split(' blue')[0]) > MAX_VALUES['blue']:
                    valid_game = False
                elif 'green' in value and int(value.split(' green')[0]) > MAX_VALUES['green']:
                    valid_game = False

            GAME_DICT[split_value[0].replace('Game ', '')] = [valid_game]


def add_valid_games():
    global TOTAL
    for key, value in GAME_DICT.items():
        if value[0]:
            TOTAL += int(key)


split_string()
add_valid_games()

print(TOTAL)

# 2528
