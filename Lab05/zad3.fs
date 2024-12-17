module zad3

// Funkcja pomocnicza do wstawiania elementu na wszystkie pozycje w liście
let rec insertAtAllPositions x lst =
    match lst with
    | [] -> [[x]]
    | head :: tail ->
        (x :: lst) :: (List.map (fun l -> head :: l) (insertAtAllPositions x tail))

// Funkcja rekurencyjna do generowania permutacji listy
let rec permutations lst =
    match lst with
    | [] -> [[]]
    | head :: tail ->
        let tailPerms = permutations tail
        List.collect (insertAtAllPositions head) tailPerms

// Test
let inputList = [1; 2; 3]
let result = permutations inputList

printfn "Permutacje listy %A to:" inputList
result |> List.iter (printfn "%A")
