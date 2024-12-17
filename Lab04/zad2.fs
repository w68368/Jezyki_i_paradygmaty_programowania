module zad2

open System

// Mapa kursów wymiany walut względem PLN (złoty polski)
let exchangeRates = 
    Map [
        ("USD", 4.0)   // 1 USD = 4 PLN
        ("EUR", 4.5)   // 1 EUR = 4.5 PLN
        ("GBP", 5.2)   // 1 GBP = 5.2 PLN
        ("PLN", 1.0)   // PLN jako wartość bazowa
    ]

// Funkcja konwertująca kwotę z jednej waluty na inną
let convertCurrency amount sourceCurrency targetCurrency =
    if exchangeRates.ContainsKey(sourceCurrency) && exchangeRates.ContainsKey(targetCurrency) then
        let sourceRate = exchangeRates.[sourceCurrency]
        let targetRate = exchangeRates.[targetCurrency]
        let amountInPLN = amount * sourceRate
        let convertedAmount = amountInPLN / targetRate
        Some convertedAmount
    else
        None

// Funkcja główna programu
let main () =
    try
        printfn "Kalkulator konwersji walut"

        // Pobieranie danych od użytkownika
        printf "Podaj kwotę do przeliczenia: "
        let amountInput = Console.ReadLine()
        let amount = float amountInput

        printf "Podaj walutę źródłową (USD, EUR, GBP, PLN): "
        let sourceCurrency = Console.ReadLine().ToUpper()

        printf "Podaj walutę docelową (USD, EUR, GBP, PLN): "
        let targetCurrency = Console.ReadLine().ToUpper()

        // Obliczenie konwersji
        match convertCurrency amount sourceCurrency targetCurrency with
        | Some result ->
            printfn "\n%.2f %s to %.2f %s" amount sourceCurrency result targetCurrency
        | None ->
            printfn "\nBłąd: Wprowadzono nieobsługiwaną walutę."

    with
    | :? System.FormatException ->
        printfn "Błąd: Wprowadzono nieprawidłową kwotę."

// Uruchomienie programu
main ()



