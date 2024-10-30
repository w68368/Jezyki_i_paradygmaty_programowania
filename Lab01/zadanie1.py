def podziel_paczki(wagi, max_waga):
    for waga in wagi:
        if waga > max_waga:
            raise ValueError(f"Paczka o wadze {waga} przekracza maksymalną dozwoloną wagę kursu ({max_waga} kg).")

    wagi_sorted = sorted(wagi, reverse=True)
    kursy = []

    for waga in wagi_sorted:
        dodano = False
        for kurs in kursy:
            if sum(kurs) + waga <= max_waga:
                kurs.append(waga)
                dodano = True
                break
        if not dodano:
            kursy.append([waga])

    return len(kursy), kursy


wagi = [20, 15, 10, 10, 8, 7, 5]
max_waga = 25

liczba_kursow, kursy = podziel_paczki(wagi, max_waga)
for i, kurs in enumerate(kursy, 1):
    print(f"Kurs {i}: {kurs} \t suma wagi: {sum(kurs)} kg")
