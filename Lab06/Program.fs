open System

// Funkcja licząca liczbę słów i znaków (bez spacji) w podanym tekście
let countWordsAndCharacters (text: string) =
    let words = text.Split([|' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries)
    let wordCount = words.Length
    let charCount = text.ToCharArray() |> Array.filter (fun c -> not (Char.IsWhiteSpace(c))) |> Array.length
    wordCount, charCount

// Funkcja sprawdzająca, czy podany tekst jest palindromem
let isPalindrome (text: string) =
    let cleanedText = 
        text.ToLower() 
        |> Seq.filter (fun c -> Char.IsLetterOrDigit(c)) 
        |> Seq.toArray
    cleanedText = Array.rev cleanedText

// Funkcja usuwająca duplikaty z listy ciągów
let removeDuplicates (words: string list) =
    words |> List.distinct

// Funkcja przekształcająca format "imię; nazwisko; wiek" na "Nazwisko, Imię (wiek lat)"
let reformatEntries (entries: string list) =
    entries 
    |> List.map (fun entry -> 
        let parts = entry.Split(';') |> Array.map (fun p -> p.Trim())
        if parts.Length = 3 then
            let firstName = parts.[0]
            let lastName = parts.[1]
            let age = parts.[2]
            sprintf "%s, %s (%s lat)" lastName firstName age
        else
            sprintf "Nieprawidłowy format: %s" entry
    )

// Funkcja znajdująca najdłuższe słowo w tekście
let findLongestWord (text: string) =
    let words = text.Split([|' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries)
    let longestWord = words |> Array.maxBy (fun word -> word.Length)
    longestWord, longestWord.Length

// Funkcja do wyszukiwania i zamiany słowa
let replaceWordInText (text: string) (oldWord: string) (newWord: string) =
    text.Replace(oldWord, newWord)

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    printfn "Podaj tekst:"
    let inputText = Console.ReadLine()
    match inputText with
    | null -> 
        printfn "Nie podano tekstu."
    | _ ->
        // Zadanie 1: Liczenie słów i znaków
        let wordCount, charCount = countWordsAndCharacters inputText
        printfn "Liczba słów: %d" wordCount
        printfn "Liczba znaków (bez spacji): %d" charCount

        // Zadanie 2: Sprawdzanie palindromu
        if isPalindrome inputText then
            printfn "Podany tekst jest palindromem."
        else
            printfn "Podany tekst nie jest palindromem."

        // Zadanie 3: Usuwanie duplikatów
        let words = inputText.Split([|' '; '\t'; '\n'; '\r'|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList
        let uniqueWords = removeDuplicates words
        printfn "Lista unikalnych słów: %A" uniqueWords

        // Zadanie 4: Zmiana formatu tekstu
        printfn "Podaj wpisy w formacie \"imię; nazwisko; wiek\" (oddzielone średnikiem, jeden wpis na linię)."
        printfn "Aby zakończyć wprowadzanie, pozostaw pustą linię."
        
        let rec readEntries entries =
            match Console.ReadLine() with
            | null | "" -> entries
            | line -> readEntries (line :: entries)

        let entries = readEntries [] |> List.rev
        let formattedEntries = reformatEntries entries
        printfn "Sformatowane wpisy:"
        formattedEntries |> List.iter (printfn "%s")

        // Zadanie 5: Znajdowanie najdłuższego słowa
        let longestWord, length = findLongestWord inputText
        printfn "Najdłuższe słowo: \"%s\" (długość: %d znaków)" longestWord length

        // Zadanie 6: Wyszukiwanie i zamiana
        printfn "Podaj słowo do wyszukania:"
        let wordToFind = Console.ReadLine()
        printfn "Podaj słowo, na które chcesz je zamienić:"
        let wordToReplace = Console.ReadLine()

        match wordToFind, wordToReplace with
        | null, _ | _, null -> printfn "Nie podano słów do zamiany."
        | _ -> 
            let modifiedText = replaceWordInText inputText wordToFind wordToReplace
            printfn "Zmodyfikowany tekst: %s" modifiedText
        
    0 // Zwrócenie kodu zakończenia
