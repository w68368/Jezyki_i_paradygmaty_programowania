module zad5

// Rekurencyjna wersja QuickSort
let rec quickSort list =
    match list with
    | [] -> [] // Lista pusta
    | [x] -> [x] // Lista jednoelementowa
    | pivot :: tail ->
        let smaller = List.filter (fun x -> x < pivot) tail
        let greater = List.filter (fun x -> x >= pivot) tail
        quickSort smaller @ [pivot] @ quickSort greater

// Test
let inputList = [3; 6; 8; 10; 1; 2; 1]
let sortedList = quickSort inputList

printfn "Rekurencyjny QuickSort: %A -> %A" inputList sortedList


