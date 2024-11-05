import numpy as np


def validate_addition(matrix_a, matrix_b):
    """Sprawdza, czy macierze mają ten sam wymiar dla dodawania."""
    return matrix_a.shape == matrix_b.shape


def validate_multiplication(matrix_a, matrix_b):
    """Sprawdza, czy liczba kolumn w macierzy A równa się liczbie wierszy w macierzy B dla mnożenia."""
    return matrix_a.shape[1] == matrix_b.shape[0]


def validate_transpose(matrix):
    """Transponowanie zawsze jest poprawne, więc tutaj po prostu zwracamy True."""
    return True


def perform_operation(operation, matrix_a, matrix_b=None):
    """Wykonuje operację na macierzach po sprawdzeniu poprawności."""
    result = None
    try:
        if operation == "add":
            if validate_addition(matrix_a, matrix_b):
                result = eval("matrix_a + matrix_b")
            else:
                raise ValueError("Macierze muszą mieć te same wymiary dla dodawania.")

        elif operation == "multiply":
            if validate_multiplication(matrix_a, matrix_b):
                result = eval("np.dot(matrix_a, matrix_b)")
            else:
                raise ValueError("Liczba kolumn macierzy A musi się zgadzać z liczbą wierszy macierzy B dla mnożenia.")

        elif operation == "transpose":
            if validate_transpose(matrix_a):
                result = eval("matrix_a.T")
            else:
                raise ValueError("Transponowanie jest niepoprawne.")

        else:
            raise ValueError("Nieznana operacja. Dozwolone operacje to: add, multiply, transpose.")

    except Exception as e:
        print(f"Błąd: {e}")

    return result


# Przykład użycia
matrix_a = np.array([[1, 2, 3], [4, 5, 6]])
matrix_b = np.array([[7, 8, 9], [10, 11, 12]])

# Dodawanie
result_add = perform_operation("add", matrix_a, matrix_b)
print("Wynik dodawania:\n", result_add)

# Mnożenie (zmiana wymiarów, aby było możliwe)
matrix_c = np.array([[1, 2], [3, 4], [5, 6]])
result_multiply = perform_operation("multiply", matrix_a, matrix_c)
print("Wynik mnożenia:\n", result_multiply)

# Transponowanie
result_transpose = perform_operation("transpose", matrix_a)
print("Wynik transponowania:\n", result_transpose)
