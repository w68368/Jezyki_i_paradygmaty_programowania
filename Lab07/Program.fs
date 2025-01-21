// Zadanie 1: System do zarządzania biblioteką
// Klasa Book: Reprezentuje książkę
type Book(title: string, author: string, pages: int) =
    member this.Title = title
    member this.Author = author
    member this.Pages = pages
    // Metoda GetInfo zwracająca informacje o książce
    member this.GetInfo() =
        sprintf "Tytuł: %s, Autor: %s, Liczba stron: %d" this.Title this.Author this.Pages

// Klasa User: Reprezentuje użytkownika
type User(name: string) =
    let mutable borrowedBooks = []
    member this.Name = name
    // Metoda BorrowBook do wypożyczania książek
    member this.BorrowBook(book: Book) =
        borrowedBooks <- book :: borrowedBooks
        printfn "%s wypożyczył(a) książkę: %s" this.Name book.Title
    // Metoda ReturnBook do zwracania książek
    member this.ReturnBook(book: Book) =
        borrowedBooks <- borrowedBooks |> List.filter (fun b -> b.Title <> book.Title)
        printfn "%s zwrócił(a) książkę: %s" this.Name book.Title

// Klasa Library: Reprezentuje bibliotekę
type Library() =
    let mutable books = []
    // Metoda AddBook do dodawania książek do biblioteki
    member this.AddBook(book: Book) =
        books <- book :: books
        printfn "Dodano książkę: %s" book.Title
    // Metoda RemoveBook do usuwania książek z biblioteki
    member this.RemoveBook(book: Book) =
        books <- books |> List.filter (fun b -> b.Title <> book.Title)
        printfn "Usunięto książkę: %s" book.Title
    // Metoda ListBooks do listowania książek w bibliotece
    member this.ListBooks() =
        printfn "Książki w bibliotece:"
        books |> List.iter (fun book -> printfn "%s" (book.GetInfo()))

// Zadanie 2: System BankAccount
// Klasa BankAccount: Reprezentuje konto bankowe
type BankAccount(accountNumber: string, initialBalance: float) =
    let mutable balance = initialBalance
    member this.AccountNumber = accountNumber
    member this.Balance with get() = balance
    // Metoda Deposit do wpłaty
    member this.Deposit(amount: float) =
        if amount <= 0.0 then
            printfn "Kwota wpłaty musi być większa od 0."
        else
            balance <- balance + amount
            printfn "Wpłacono %.2f. Nowe saldo: %.2f" amount balance
    // Metoda Withdraw do wypłaty
    member this.Withdraw(amount: float) =
        if amount <= 0.0 then
            printfn "Kwota wypłaty musi być większa od 0."
        elif amount > balance then
            printfn "Niewystarczające środki na koncie."
        else
            balance <- balance - amount
            printfn "Wypłacono %.2f. Nowe saldo: %.2f" amount balance

// Klasa Bank: Zarządza kontami bankowymi
type Bank() =
    let mutable accounts = []
    // Metoda CreateAccount do tworzenia konta
    member this.CreateAccount(accountNumber: string, initialBalance: float) =
        let account = BankAccount(accountNumber, initialBalance)
        accounts <- account :: accounts
        printfn "Utworzono konto o numerze: %s" accountNumber
        account
    // Metoda GetAccount do odczytu konta
    member this.GetAccount(accountNumber: string) =
        accounts |> List.tryFind (fun account -> account.AccountNumber = accountNumber)
    // Metoda UpdateAccount do aktualizacji salda konta
    member this.UpdateAccount(accountNumber: string, newBalance: float) =
        match this.GetAccount(accountNumber) with
        | Some(account) -> 
            let currentBalance = account.Balance
            printfn "Aktualne saldo konta %s: %.2f" accountNumber currentBalance
            account.Deposit(newBalance - currentBalance)
        | None -> printfn "Nie znaleziono konta o numerze: %s" accountNumber
    // Metoda DeleteAccount do usuwania konta
    member this.DeleteAccount(accountNumber: string) =
        accounts <- accounts |> List.filter (fun account -> account.AccountNumber <> accountNumber)
        printfn "Usunięto konto o numerze: %s" accountNumber

// Program główny
[<EntryPoint>]
let main argv =
    // Zadanie 1: System do zarządzania biblioteką
    let library = Library()
    let user = User("Jan")
    
    let book1 = Book("Wiedźmin", "Andrzej Sapkowski", 400)
    let book2 = Book("Hobbit", "J.R.R. Tolkien", 300)
    
    library.AddBook(book1)
    library.AddBook(book2)
    
    user.BorrowBook(book1)
    user.ReturnBook(book1)
    
    library.ListBooks()
    library.RemoveBook(book2)
    library.ListBooks()

    // Zadanie 2: System BankAccount
    let bank = Bank()

    let account1 = bank.CreateAccount("12345", 1000.0)
    let account2 = bank.CreateAccount("67890", 500.0)
    
    account1.Deposit(500.0)
    account1.Withdraw(200.0)
    account2.Deposit(300.0)
    account2.Withdraw(100.0)
    
    bank.UpdateAccount("12345", 1500.0)
    bank.DeleteAccount("67890")
    
    match bank.GetAccount("67890") with
    | Some(account) -> printfn "Znaleziono konto: %s" account.AccountNumber
    | None -> printfn "Nie znaleziono konta o numerze: 67890"
    
    0
