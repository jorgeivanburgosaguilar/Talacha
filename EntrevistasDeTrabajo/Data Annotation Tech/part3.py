def next_row(current_row: int) -> int:
    """Function that calculates the next index from last item position in the pyramid"""
    # The calculation is done on the basis that 1+2 = 3, 1+2+3 = 6 and so on
    # so it calculates what will be the next index based on the pyramid row
    return ((current_row * (current_row + 1)) // 2) + current_row + 1


def decode(message_file: str) -> str:
    """Function that takes the filename and decode the hidden message"""
    # Variable initialization
    decoded_message: list[str] = []
    max_value: int = 0
    pyramid: dict = {}

    # Open utf-8 file, split line by line to process the flat pyramid
    with open(message_file, 'r', encoding='utf-8') as file:
        for line in file:
            parts = line.split()
            key: int = int(parts[0])
            # calculates the max possible key value while processing the pyramid
            max_value = max(key, max_value)
            pyramid[key] = parts[1]

    # Loop to get all the last pyramid values based on what the max key value could be
    # starting from 0 so that it can start at index 1 like in the example
    for row in range(0, max_value + 1):
        value: str = dict(pyramid).get(next_row(row), -1)
        if value == -1:
            break
        decoded_message.append(value)

    # Joins the list of strings as a single string with a space between them
    return ' '.join(decoded_message)

# prints the decoded message
print(decode('example.txt'))
print(decode('coding_qual_input.txt'))
