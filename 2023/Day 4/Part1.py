import re


def get_cards(file):
    total = 0
    with open(file, 'r') as f:
        for line in f:
            hits, points = 0, 0

            # Split our card. Normalize spacing between characters
            card = re.split('[:|]', line.strip().replace('  ', ' 0').replace('Card ', ''))
            winning_numbers = card[1].strip().split(' ')
            scratched_numbers = card[2].strip().split(' ')

            for number in scratched_numbers:
                if number in winning_numbers:
                    hits += 1

            if hits == 1:
                points = 1
            elif hits > 1:
                points = 1 * (2 ** (hits - 1))

            print(f'Card {card[0]}: {hits} hits; {points} points')
            print(f'    {winning_numbers}')
            print(f'    {scratched_numbers}')

            total += points
    print(total)


get_cards('input.txt')
