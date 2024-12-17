module zad5

open System

// Definicja typu dla planszy
type Board = char list

// Funkcja wyświetlająca planszę gry
let printBoard (board: Board) =
    printfn "\n %c | %c | %c " board.[0] board.[1] board.[2]
    printfn "---+---+---"
    printfn " %c | %c | %c " board.[3] board.[4] board.[5]
    printfn "---+---+---"
    printfn " %c | %c | %c \n" board.[6] board.[7] board.[8]

// Funkcja sprawdzająca, czy ruch jest poprawny
let isValidMove (board: Board) position =
    position >= 0 && position < 9 && board.[position] = ' '

// Funkcja wykonująca ruch gracza
let rec playerMove (board: Board) =
    printf "Wybierz pozycję (0-8): "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, position) when isValidMove board position ->
        board |> List.mapi (fun i x -> if i = position then 'X' else x)
    | _ ->
        printfn "Błąd: Nieprawidłowy ruch. Spróbuj ponownie."
        playerMove board

// Funkcja wykonująca ruch komputera (losowy ruch)
let computerMove (board: Board) =
    let random = Random()
    let emptyPositions = board |> List.mapi (fun i x -> i, x) |> List.filter (fun (_, x) -> x = ' ') |> List.map fst
    let position = emptyPositions.[random.Next(emptyPositions.Length)]
    printfn "Komputer wybiera pozycję %d" position
    board |> List.mapi (fun i x -> if i = position then 'O' else x)

// Funkcja sprawdzająca wygraną
let checkWin (board: Board) (symbol: char) =
    let winningCombos = [[0;1;2]; [3;4;5]; [6;7;8]; [0;3;6]; [1;4;7]; [2;5;8]; [0;4;8]; [2;4;6]]
    winningCombos |> List.exists (fun combo -> combo |> List.forall (fun i -> board.[i] = symbol))

// Funkcja sprawdzająca remis
let isDraw (board: Board) =
    board |> List.forall (fun x -> x <> ' ')

// Funkcja zarządzająca grą
let rec gameLoop (board: Board) =
    printBoard board

    // Ruch gracza
    let boardAfterPlayer = playerMove board
    if checkWin boardAfterPlayer 'X' then
        printBoard boardAfterPlayer
        printfn "Gratulacje! Wygrałeś!"
    elif isDraw boardAfterPlayer then
        printBoard boardAfterPlayer
        printfn "Remis!"
    else
        // Ruch komputera
        let boardAfterComputer = computerMove boardAfterPlayer
        if checkWin boardAfterComputer 'O' then
            printBoard boardAfterComputer
            printfn "Komputer wygrał. Spróbuj ponownie!"
        elif isDraw boardAfterComputer then
            printBoard boardAfterComputer
            printfn "Remis!"
        else
            gameLoop boardAfterComputer

// Funkcja główna
let main () =
    printfn "Witaj w grze Kółko i Krzyżyk!"
    let initialBoard = [' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' ']
    gameLoop initialBoard

// Uruchomienie programu
main ()
