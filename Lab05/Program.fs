let rec fib n =
    if n <= 0 then 0
    elif n = 1 then 1
    else fib (n - 1) + fib (n - 2)

// Test
printfn "Prosta rekurencja: Fib(10) = %d" (fib 10)


let fibTail n =
    let rec aux n a b =
        if n = 0 then a
        elif n = 1 then b
        else aux (n - 1) b (a + b)
    aux n 0 1

// Test
printfn "Ogonowa rekurencja: Fib(10) = %d" (fibTail 10)
