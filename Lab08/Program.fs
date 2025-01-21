open System

// Definicja listy łączonej
type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

// Definicja wyniku dla funkcji findIndex
type Result<'T> =
    | Found of int
    | NotFound

// 1. Funkcja tworząca listę łączoną na podstawie zwykłej listy
let rec createLinkedListFromList lst =
    match lst with
    | [] -> Empty
    | head :: tail -> Node(head, createLinkedListFromList tail)

// 2. Funkcja sumująca elementy listy zawierającej liczby całkowite
let rec sumList list =
    match list with
    | Empty -> 0
    | Node(value, next) -> value + sumList next

// 3. Funkcja znajdująca maksymalny i minimalny element w liście liczbowej
let rec findMinMax list =
    let rec loop minVal maxVal = function
        | Empty -> (minVal, maxVal)
        | Node(value, next) ->
            loop (min value minVal) (max value maxVal) next
    match list with
    | Empty -> failwith "Lista jest pusta"
    | Node(value, next) -> loop value value next

// 4. Funkcja odwracająca kolejność elementów listy
let rec reverseList list =
    let rec loop acc = function
        | Empty -> acc
        | Node(value, next) -> loop (Node(value, acc)) next
    loop Empty list

// 5. Funkcja sprawdzająca, czy dany element znajduje się w liście
let rec containsElement element list =
    match list with
    | Empty -> false
    | Node(value, next) -> value = element || containsElement element next

// 6. Funkcja określająca indeks podanego elementu
let rec findIndex element list index =
    match list with
    | Empty -> NotFound
    | Node(value, next) ->
        if value = element then Found index
        else findIndex element next (index + 1)

let findElementIndex element list =
    findIndex element list 0

// 7. Funkcja zliczająca ile razy dany element występuje w liście
let rec countOccurrences element list =
    match list with
    | Empty -> 0
    | Node(value, next) ->
        if value = element then 1 + countOccurrences element next
        else countOccurrences element next

// 8. Funkcja łącząca dwie listy łączone w jedną
let rec append list1 list2 =
    match list1 with
    | Empty -> list2
    | Node(value, next) -> Node(value, append next list2)

// 9. Funkcja porównująca dwie listy liczb całkowitych i zwracająca listę wartości logicznych
exception ListsHaveDifferentLengths

let rec compareLists list1 list2 =
    match list1, list2 with
    | Empty, Empty -> []
    | Node(x, xs), Node(y, ys) ->
        let result = if x > y then true else false
        result :: compareLists xs ys
    | _, _ -> raise ListsHaveDifferentLengths

// 10. Funkcja zwracająca listę zawierającą tylko elementy spełniające określony warunek
let rec filterList predicate list =
    match list with
    | Empty -> Empty
    | Node(value, next) ->
        if predicate value then
            Node(value, filterList predicate next)
        else
            filterList predicate next

// Funkcja wyświetlająca elementy listy
let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next

// Przykład użycia
[<EntryPoint>]
let main argv =
    let lst1 = [1; 2; 3; 4; 5]
    let lst2 = [2; 3; 4; 5; 6]

    let linkedList1 = createLinkedListFromList lst1
    let linkedList2 = createLinkedListFromList lst2
    
    // 6. Indeks elementu
    match findElementIndex 3 linkedList1 with
    | Found index -> printfn "Indeks elementu: %d" index
    | NotFound -> printfn "Element nie znaleziony"
    
    // 7. Zliczanie wystąpień
    let count = countOccurrences 3 linkedList1
    printfn "Element 3 występuje %d razy" count
    
    // 8. Łączenie dwóch list
    let combinedList = append linkedList1 linkedList2
    printfn "Połączona lista: "
    printList combinedList
    printfn ""
    
    // 9. Porównanie dwóch list
    try
        let comparison = compareLists linkedList1 linkedList2
        printfn "Porównanie list: %A" comparison
    with
    | ListsHaveDifferentLengths -> printfn "Listy mają różne długości"
    
    // 10. Filtrowanie listy
    let filteredList = filterList (fun x -> x % 2 = 0) linkedList1
    printfn "Przefiltrowana lista (parzyste liczby): "
    printList filteredList
    printfn ""

    0 // Zwraca kod wyjścia
