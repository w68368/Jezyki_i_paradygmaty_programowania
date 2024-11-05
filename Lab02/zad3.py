def analyze_data(data):
    # Filtracja i znalezienie największej liczby
    numbers = list(filter(lambda x: isinstance(x, (int, float)), data))
    max_number = max(numbers) if numbers else None

    # Filtracja i znalezienie najdłuższego napisu
    strings = list(filter(lambda x: isinstance(x, str), data))
    longest_string = max(strings, key=len) if strings else None

    # Filtracja i znalezienie krotki z największą liczbą elementów
    tuples = list(filter(lambda x: isinstance(x, tuple), data))
    largest_tuple = max(tuples, key=len) if tuples else None

    return {
        "największa liczba": max_number,
        "najdłuższy napis": longest_string,
        "krotka z największą liczbą elementów": largest_tuple
    }

# Przykładowe dane
data = [3, "hello", (1, 2), 45.6, "Python", (5, 6, 7), {"key": "value"}, 100, "world", (8, 9, 10, 11)]
result = analyze_data(data)

print("Największa liczba:", result["największa liczba"])
print("Najdłuższy napis:", result["najdłuższy napis"])
print("Krotka z największą liczbą elementów:", result["krotka z największą liczbą elementów"])
