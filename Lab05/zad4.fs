module zad4

// Rekurencyjne rozwiązanie problemu Wież Hanoi
let rec hanoi n source target auxiliary =
    if n = 1 then
        printfn "Przenieś krążek z %s na %s" source target
    else
        // Krok 1: Przenieś n-1 krążków ze źródła na pomocniczy pręt
        hanoi (n-1) source auxiliary target
        // Krok 2: Przenieś największy krążek ze źródła na docelowy pręt
        printfn "Przenieś krążek z %s na %s" source target
        // Krok 3: Przenieś n-1 krążków z pomocniczego pręta na docelowy
        hanoi (n-1) auxiliary target source

// Test dla 3 krążków
printfn "Rekurencyjne rozwiązanie problemu Wież Hanoi:"
hanoi 3 "A" "C" "B"

