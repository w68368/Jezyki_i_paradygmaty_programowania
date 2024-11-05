def generate_and_execute_code(template, placeholders):
    """
    Generuje i uruchamia kod Python na podstawie szablonu i słownika z danymi wejściowymi.
    :param template: string z szablonem kodu.
    :param placeholders: słownik z nazwami zmiennych/funkcji i ich wartościami.
    :return: wynik wykonania kodu lub informacja o błędzie.
    """
    try:
        # Uzupełnianie szablonu o brakujące wartości z placeholders
        code = template.format(**placeholders)

        # Weryfikacja bezpieczeństwa i poprawności kodu
        safe_keywords = {'def', 'return', 'if', 'else', 'for', 'while', 'print', 'lambda'}
        if any(word in code and word not in safe_keywords for word in code.split()):
            raise ValueError("Kod zawiera potencjalnie niebezpieczne słowa kluczowe.")

        # Uruchamianie wygenerowanego kodu
        exec_locals = {}
        exec(code, {}, exec_locals)

        # Zwrot wyniku funkcji (jeśli jest zdefiniowana)
        result = exec_locals.get('result', None)
        return result

    except Exception as e:
        return f"Błąd w generowaniu lub wykonaniu kodu: {e}"


# Przykład użycia
template = """
def funkcja(x):
    return x + {increment}

result = funkcja({value})
"""

# Placeholders - dynamiczne wartości
placeholders = {
    'increment': 5,
    'value': 10
}

# Generowanie i uruchamianie kodu
result = generate_and_execute_code(template, placeholders)
print("Wynik wykonania:", result)
