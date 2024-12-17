module zad2

// Definicja drzewa binarnego
type Tree<'T> =
    | Empty
    | Node of 'T * Tree<'T> * Tree<'T>


    // Rekurencyjne wyszukiwanie elementu w drzewie binarnym
let rec searchTreeRecursive tree value =
    match tree with
    | Empty -> false
    | Node(v, left, right) ->
        if v = value then true
        else searchTreeRecursive left value || searchTreeRecursive right value

// Przykładowe drzewo
let tree =
    Node(10, 
         Node(5, Node(3, Empty, Empty), Node(7, Empty, Empty)),
         Node(15, Node(12, Empty, Empty), Node(18, Empty, Empty)))

// Test
printfn "Rekurencyjne wyszukiwanie: Czy 7 istnieje? %b" (searchTreeRecursive tree 7)
printfn "Rekurencyjne wyszukiwanie: Czy 13 istnieje? %b" (searchTreeRecursive tree 13)

// Iteracyjne wyszukiwanie elementu w drzewie binarnym za pomocą stosu
let searchTreeIterative tree value =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: rest -> loop rest
        | Node(v, left, right) :: rest ->
            if v = value then true
            else loop (left :: right :: rest)
    loop [tree]

// Test
printfn "Iteracyjne wyszukiwanie: Czy 7 istnieje? %b" (searchTreeIterative tree 7)
printfn "Iteracyjne wyszukiwanie: Czy 13 istnieje? %b" (searchTreeIterative tree 13)
