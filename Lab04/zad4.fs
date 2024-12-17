module zad4

open System

// Definicja rekordu reprezentującego konto bankowe
type Account = {
    AccountNumber: string
    Balance: float
}

// Funkcja do tworzenia nowego konta
let createAccount accountNumber initialBalance (accounts: Map<string, Account>) =
    if accounts.ContainsKey(accountNumber) then
        printfn "Błąd: Konto o numerze %s już istnieje." accountNumber
        accounts
    else
        let newAccount = { AccountNumber = accountNumber; Balance = initialBalance }
        printfn "Konto o numerze %s zostało utworzone z saldem %.2f." accountNumber initialBalance
        accounts.Add(accountNumber, newAccount)

// Funkcja do depozytowania środków na konto
let deposit accountNumber amount (accounts: Map<string, Account>) =
    match accounts.TryFind(accountNumber) with
    | Some account ->
        let updatedAccount = { account with Balance = account.Balance + amount }
        printfn "Wpłacono %.2f na konto %s. Nowe saldo: %.2f." amount accountNumber updatedAccount.Balance
        accounts.Add(accountNumber, updatedAccount)
    | None ->
        printfn "Błąd: Konto o numerze %s nie istnieje." accountNumber
        accounts

// Funkcja do wypłacania środków z konta
let withdraw accountNumber amount (accounts: Map<string, Account>) =
    match accounts.TryFind(accountNumber) with
    | Some account when account.Balance >= amount ->
        let updatedAccount = { account with Balance = account.Balance - amount }
        printfn "Wypłacono %.2f z konta %s. Nowe saldo: %.2f." amount accountNumber updatedAccount.Balance
        accounts.Add(accountNumber, updatedAccount)
    | Some _ ->
        printfn "Błąd: Brak wystarczających środków na koncie %s." accountNumber
        accounts
    | None ->
        printfn "Błąd: Konto o numerze %s nie istnieje." accountNumber
        accounts

// Funkcja do wyświetlania salda konta
let showBalance accountNumber (accounts: Map<string, Account>) =
    match accounts.TryFind(accountNumber) with
    | Some account -> printfn "Saldo konta %s wynosi: %.2f." accountNumber account.Balance
    | None -> printfn "Błąd: Konto o numerze %s nie istnieje." accountNumber

// Funkcja główna programu
let rec main (accounts: Map<string, Account>) =
    printfn "\n--- Symulacja Operacji Bankowych ---"
    printfn "Wybierz opcję:"
    printfn "1. Stwórz nowe konto"
    printfn "2. Wpłać środki na konto"
    printfn "3. Wypłać środki z konta"
    printfn "4. Wyświetl saldo konta"
    printfn "5. Zakończ program"
    printf "Twój wybór: "

    match Console.ReadLine() with
    | "1" ->
        printf "Podaj numer nowego konta: "
        let accountNumber = Console.ReadLine()
        printf "Podaj początkowe saldo: "
        let balance = float (Console.ReadLine())
        main (createAccount accountNumber balance accounts)
    | "2" ->
        printf "Podaj numer konta: "
        let accountNumber = Console.ReadLine()
        printf "Podaj kwotę do wpłaty: "
        let amount = float (Console.ReadLine())
        main (deposit accountNumber amount accounts)
    | "3" ->
        printf "Podaj numer konta: "
        let accountNumber = Console.ReadLine()
        printf "Podaj kwotę do wypłaty: "
        let amount = float (Console.ReadLine())
        main (withdraw accountNumber amount accounts)
    | "4" ->
        printf "Podaj numer konta: "
        let accountNumber = Console.ReadLine()
        showBalance accountNumber accounts
        main accounts
    | "5" ->
        printfn "Dziękujemy za korzystanie z aplikacji bankowej. Do widzenia!"
    | _ ->
        printfn "Błąd: Nieprawidłowa opcja. Spróbuj ponownie."
        main accounts

// Uruchomienie programu
main Map.empty
