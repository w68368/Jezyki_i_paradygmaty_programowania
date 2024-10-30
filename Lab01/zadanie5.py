def harmonogram_proceduralnie(zadania):
    zadania_sorted = sorted(zadania, key=lambda x: x[1])
    harmonogram = []
    maks_nagroda = 0
    koniec_poprzedniego = 0

    for start, koniec, nagroda in zadania_sorted:
        if start >= koniec_poprzedniego:
            harmonogram.append((start, koniec, nagroda))
            maks_nagroda += nagroda
            koniec_poprzedniego = koniec

    return maks_nagroda, harmonogram

zadania = [(1, 4, 50), (3, 5, 20), (0, 6, 60), (5, 7, 30), (5, 9, 25), (8, 9, 10)]
maks_nagroda, optymalny_harmonogram = harmonogram_proceduralnie(zadania)
print("Maksymalna nagroda:", maks_nagroda)
print("Optymalny harmonogram:", optymalny_harmonogram)


from functools import reduce

def harmonogram_funkcyjnie(zadania):
    zadania_sorted = sorted(zadania, key=lambda x: x[1])

    def wybierz_zadania(acc, zadanie):
        harmonogram, koniec_poprzedniego, maks_nagroda = acc
        start, koniec, nagroda = zadanie
        if start >= koniec_poprzedniego:
            harmonogram.append((start, koniec, nagroda))
            maks_nagroda += nagroda
            koniec_poprzedniego = koniec
        return harmonogram, koniec_poprzedniego, maks_nagroda

    harmonogram, _, maks_nagroda = reduce(wybierz_zadania, zadania_sorted, ([], 0, 0))

    return maks_nagroda, harmonogram

zadania = [(1, 4, 50), (3, 5, 20), (0, 6, 60), (5, 7, 30), (5, 9, 25), (8, 9, 10)]
maks_nagroda, optymalny_harmonogram = harmonogram_funkcyjnie(zadania)
print("Maksymalna nagroda:", maks_nagroda)
print("Optymalny harmonogram:", optymalny_harmonogram)
