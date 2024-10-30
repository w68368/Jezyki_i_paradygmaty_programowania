def plecak_proceduralnie(przedmioty, pojemnosc):
    n = len(przedmioty)
    dp = [[0] * (pojemnosc + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        waga, wartosc = przedmioty[i - 1]
        for j in range(pojemnosc + 1):
            if waga <= j:
                dp[i][j] = max(dp[i - 1][j], dp[i - 1][j - waga] + wartosc)
            else:
                dp[i][j] = dp[i - 1][j]

    wynik = []
    j = pojemnosc
    for i in range(n, 0, -1):
        if dp[i][j] != dp[i - 1][j]:
            waga, wartosc = przedmioty[i - 1]
            wynik.append((waga, wartosc))
            j -= waga

    maks_wartosc = dp[n][pojemnosc]
    return maks_wartosc, wynik

przedmioty = [(3, 50), (2, 60), (1, 20), (4, 30)]
pojemnosc = 5
maks_wartosc, wybrane_przedmioty = plecak_proceduralnie(przedmioty, pojemnosc)
print("Maksymalna wartość:", maks_wartosc)
print("Wybrane przedmioty:", wybrane_przedmioty)

from functools import lru_cache


def plecak_funkcyjnie(przedmioty, pojemnosc):
    @lru_cache(maxsize=None)
    def knapsack(n, cap):
        if n == 0 or cap == 0:
            return 0
        waga, wartosc = przedmioty[n - 1]
        if waga > cap:
            return knapsack(n - 1, cap)
        else:
            return max(knapsack(n - 1, cap), wartosc + knapsack(n - 1, cap - waga))

    maks_wartosc = knapsack(len(przedmioty), pojemnosc)

    def wybierz_przedmioty(n, cap):
        if n == 0 or cap == 0:
            return []
        waga, wartosc = przedmioty[n - 1]
        if waga <= cap and knapsack(n, cap) == wartosc + knapsack(n - 1, cap - waga):
            return wybierz_przedmioty(n - 1, cap - waga) + [(waga, wartosc)]
        else:
            return wybierz_przedmioty(n - 1, cap)

    wybrane_przedmioty = wybierz_przedmioty(len(przedmioty), pojemnosc)
    return maks_wartosc, wybrane_przedmioty

przedmioty = [(3, 50), (2, 60), (1, 20), (4, 30)]
pojemnosc = 5
maks_wartosc, wybrane_przedmioty = plecak_funkcyjnie(przedmioty, pojemnosc)
print("Maksymalna wartość:", maks_wartosc)
print("Wybrane przedmioty:", wybrane_przedmioty)

