open System

// Definicja rekordu do przechowywania danych użytkownika
type UserData = {
    Weight: float
    Height: float
}

// Funkcja obliczająca BMI
let calculateBMI (userData: UserData) : float =
    let heightInMeters = userData.Height / 100.0
    userData.Weight / (heightInMeters ** 2.0)

// Funkcja określająca kategorię BMI na podstawie wyniku
let getBMICategory (bmi: float) : string =
    if bmi < 16.0 then "Wygłodzenie"
    elif bmi < 17.0 then "Wychudzenie"
    elif bmi < 18.5 then "Niedowaga"
    elif bmi < 25.0 then "Prawidłowa waga"
    elif bmi < 30.0 then "Nadwaga"
    elif bmi < 35.0 then "Otyłość I stopnia"
    elif bmi < 40.0 then "Otyłość II stopnia"
    else "Otyłość III stopnia"

// Funkcja główna programu
let main () =
    try
        // Komunikacja z użytkownikiem
        printfn "Kalkulator BMI"
        printf "Podaj swoją wagę (kg): "
        let weightInput = Console.ReadLine()
        printf "Podaj swój wzrost (cm): "
        let heightInput = Console.ReadLine()

        // Konwersja wejścia na liczby typu float
        let weight = float weightInput
        let height = float heightInput

        // Utworzenie rekordu z danymi użytkownika
        let userData = { Weight = weight; Height = height }

        // Obliczenie BMI
        let bmi = calculateBMI userData
        let category = getBMICategory bmi

        // Wyświetlenie wyników
        printfn "\nTwoje BMI wynosi: %.2f" bmi
        printfn "Kategoria BMI: %s" category

    with
    | :? System.FormatException ->
        printfn "Błąd: Wprowadzono nieprawidłowe dane. Podaj liczby w odpowiednim formacie."

// Uruchomienie programu
main ()
