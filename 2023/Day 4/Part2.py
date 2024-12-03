import re


def add_hits(winning_numbers, scratched_numbers):
    hits = sum(1 for number in scratched_numbers if number in winning_numbers)
    points = 1 * (2 ** (hits - 1)) if hits > 0 else 0
    return hits, points


def get_cards(file):
    copies, card_list = {}, {}
    with open(file, 'r') as f:
        for line in f:
            # Split our card. Normalize spacing between characters
            card = re.split('[:|]', line.strip().replace('   ', ' 00').replace('  ', ' 0').replace('Card ', ''))
            winning_numbers = card[1].strip().split(' ')
            scratched_numbers = card[2].strip().split(' ')

            card_list[int(card[0])] = [winning_numbers, scratched_numbers]
            copies[int(card[0])] = 1

    return card_list, copies


def parse_cards(file):
    total, total_cards, line_num, hits, points, pos = 1, 0, 0, 0, 0, 1
    card_list, copies = get_cards(file)

    while pos < len(card_list) + 1:
        if copies[pos] > 0:
            for i in range(1, copies[pos] + 1):
                # Find total for current card
                hits, points = add_hits(card_list[pos][0], card_list[pos][1])
                for x in range(1, hits + 1):
                    copies[pos + x] += 1

                total += points

        print(f'Card {pos}: {hits} hits; {points} points; {copies[pos]} copies')
        print(f'    {card_list[pos][0]}')
        print(f'    {card_list[pos][1]}')

        total_cards += copies[pos]
        pos += 1

    print(total)
    print(total_cards)


parse_cards('input.txt')

#  5554894
