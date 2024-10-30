def optymalizuj_zadania_proceduralnie(zadania):
    for czas, nagroda in zadania:
        if czas < 0 or nagroda < 0:
            raise ValueError(f"Zadanie z czasem {czas} i nagrodą {nagroda} jest nieprawidłowe.")

    zadania_sorted = sorted(zadania, key=lambda x: x[0])

    calkowity_czas_oczekiwania = 0
    czas_trwania = 0
    zysk = 0
    optymalna_kolejnosc = []

    for czas, nagroda in zadania_sorted:
        czas_trwania += czas
        calkowity_czas_oczekiwania += czas_trwania
        zysk += nagroda
        optymalna_kolejnosc.append((czas, nagroda))

    return optymalna_kolejnosc, calkowity_czas_oczekiwania, zysk


zadania = [(3, 50), (2, 60), (1, 20), (4, 30)]
optymalna_kolejnosc, calkowity_czas_oczekiwania, zysk = optymalizuj_zadania_proceduralnie(zadania)
print("Kolejność zadań:", optymalna_kolejnosc)
print("Całkowity czas oczekiwania:", calkowity_czas_oczekiwania)
print("Zysk:", zysk)

from functools import reduce


def optymalizuj_zadania_funkcyjnie(zadania):
    zadania_sorted = sorted(zadania, key=lambda x: x[0])

    def akumuluj_czas_oczekiwania(acc, zadanie):
        czas_trwania, calkowity_czas_oczekiwania, zysk, kolejnosc = acc
        czas, nagroda = zadanie
        czas_trwania += czas
        calkowity_czas_oczekiwania += czas_trwania
        zysk += nagroda
        kolejnosc.append(zadanie)
        return czas_trwania, calkowity_czas_oczekiwania, zysk, kolejnosc

    _, calkowity_czas_oczekiwania, zysk, optymalna_kolejnosc = reduce(
        akumuluj_czas_oczekiwania, zadania_sorted, (0, 0, 0, [])
    )

    return optymalna_kolejnosc, calkowity_czas_oczekiwania, zysk


zadania = [(3, 50), (2, 60), (1, 20), (4, 30)]
optymalna_kolejnosc, calkowity_czas_oczekiwania, zysk = optymalizuj_zadania_funkcyjnie(zadania)
print("Kolejność zadań:", optymalna_kolejnosc)
print("Całkowity czas oczekiwania:", calkowity_czas_oczekiwania)
print("Zysk:", zysk)
