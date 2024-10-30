def optymalizuj_zadania_proceduralnie(zadania):
    zadania.sort(key=lambda x: x[0])
    calkowity_czas_oczekiwania = 0
    czas_trwania = 0
    zysk = 0

    for czas, nagroda in zadania:
        czas_trwania += czas
        calkowity_czas_oczekiwania += czas_trwania
        zysk += nagroda

    return zadania, calkowity_czas_oczekiwania, zysk

zadania = [(3, 50), (2, 60), (1, 20), (4, 30)]
optymalna_kolejnosc, calkowity_czas_oczekiwania, zysk = optymalizuj_zadania_proceduralnie(zadania)
print("Kolejność zadań:", optymalna_kolejnosc)
print("Całkowity czas oczekiwania:", calkowity_czas_oczekiwania)
print("Zysk:", zysk)

from functools import reduce


def optymalizuj_zadania_funkcyjnie(zadania):
    zadania_sorted = sorted(zadania, key=lambda x: x[0])

    def akumuluj_czas_oczekiwania(acc, zadanie):
        czas_trwania, calkowity_czas_oczekiwania, zysk = acc
        czas, nagroda = zadanie
        czas_trwania += czas
        calkowity_czas_oczekiwania += czas_trwania
        zysk += nagroda
        return czas_trwania, calkowity_czas_oczekiwania, zysk

    _, calkowity_czas_oczekiwania, zysk = reduce(akumuluj_czas_oczekiwania, zadania_sorted, (0, 0, 0))

    return zadania_sorted, calkowity_czas_oczekiwania, zysk


zadania = [(3, 50), (2, 60), (1, 20), (4, 30)]
optymalna_kolejnosc, calkowity_czas_oczekiwania, zysk = optymalizuj_zadania_funkcyjnie(zadania)
print("Kolejność zadań:", optymalna_kolejnosc)
print("Całkowity czas oczekiwania:", calkowity_czas_oczekiwania)
print("Zysk:", zysk)
