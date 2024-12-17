module zad3

open System

// Funkcja do podziału tekstu na słowa
let splitIntoWords (text: string) =
    text.Split([|' '; '\n'; '\t'; '.'; ','; ';'; ':'; '!'; '?'|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

// Funkcja do liczenia znaków (bez spacji)
let countCharactersWithoutSpaces (text: string) =
    text.ToCharArray()
    |> Array.filter (fun c -> not (Char.IsWhiteSpace(c)))
    |> Array.length

// Funkcja do znajdowania najczęściej występującego słowa
let findMostFrequentWord (words: string list) =
    words 
    |> List.groupBy id                 // Grupowanie słów
    |> List.map (fun (word, occurrences) -> (word, List.length occurrences)) // Zliczanie wystąpień
    |> List.sortByDescending snd       // Sortowanie malejąco po liczbie wystąpień
    |> List.tryHead                    // Pobranie pierwszego elementu (najczęstszego)

// Funkcja główna programu
let main () =
    printfn "Analizator Tekstu"
    printfn "Wprowadź dowolny tekst poniżej. Gdy skończysz, naciśnij Enter:"

    // Odczytanie tekstu od użytkownika
    let inputText = Console.ReadLine()

    // Analiza tekstu
    let words = splitIntoWords inputText
    let charCount = countCharactersWithoutSpaces inputText
    let wordCount = List.length words
    let mostFrequentWord = findMostFrequentWord words

    // Wyświetlenie wyników
    printfn "\nStatystyki tekstu:"
    printfn "Liczba słów: %d" wordCount
    printfn "Liczba znaków (bez spacji): %d" charCount

    match mostFrequentWord with
    | Some (word, count) -> printfn "Najczęściej występujące słowo: '%s' (wystąpień: %d)" word count
    | None -> printfn "Nie znaleziono słów w tekście."

// Uruchomienie programu
main ()
