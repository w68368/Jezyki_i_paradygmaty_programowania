import numpy as np
from functools import reduce

def combine_matrices(matrices, operation):
    if not matrices:
        return None

    # Funkcja, która wykonuje operację na dwóch macierzach
    def perform_operation(a, b):
        try:
            # Eval z podstawionymi macierzami jako `a` i `b`
            return eval(operation)
        except Exception as e:
            print(f"Błąd w operacji: {e}")
            return None

    # Używamy reduce do łączenia macierzy przy użyciu zdefiniowanej operacji
    return reduce(perform_operation, matrices)

# Przykładowe macierze
matrix1 = np.array([[1, 2], [3, 4]])
matrix2 = np.array([[5, 6], [7, 8]])
matrix3 = np.array([[9, 10], [11, 12]])

# Lista macierzy
matrices = [matrix1, matrix2, matrix3]

# Operacja sumowania macierzy
result_sum = combine_matrices(matrices, 'a + b')
print("Wynik sumowania macierzy:\n", result_sum)

# Operacja mnożenia macierzy
result_product = combine_matrices(matrices, 'np.dot(a, b)')
print("Wynik mnożenia macierzy:\n", result_product)
