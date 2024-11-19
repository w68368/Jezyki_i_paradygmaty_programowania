import json
import getpass


class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def to_dict(self):
        return {"name": self.name, "age": self.age, "salary": self.salary}

    @staticmethod
    def from_dict(data):
        return Employee(data["name"], data["age"], data["salary"])

    def __str__(self):
        return f"Pracownik: {self.name}, Wiek: {self.age}, Wynagrodzenie: {self.salary} PLN"


class EmployeesManager:
    def __init__(self, filename='employees.json'):
        self.filename = filename
        self.employees = self.load_employees_from_file()

    def load_employees_from_file(self):
        try:
            with open(self.filename, 'r') as file:
                data = json.load(file)
                return [Employee.from_dict(emp) for emp in data]
        except (FileNotFoundError, json.JSONDecodeError):
            return []

    def save_employees_to_file(self):
        with open(self.filename, 'w') as file:
            json.dump([emp.to_dict() for emp in self.employees], file)

    def add_employee(self, employee):
        if self.validate_employee(employee):
            self.employees.append(employee)
            self.save_employees_to_file()
            print(f"Dodano pracownika: {employee.name}")
        else:
            print("Błąd: nieprawidłowe dane pracownika.")

    def display_employees(self):
        if self.employees:
            print("Lista pracowników:")
            for emp in self.employees:
                print(emp)
        else:
            print("Brak pracowników.")

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        self.save_employees_to_file()
        print(f"Usunięto pracowników w przedziale wiekowym {min_age}-{max_age} lat.")

    def find_employee_by_name(self, name):
        for emp in self.employees:
            if emp.name == name:
                return emp
        print(f"Nie znaleziono pracownika o imieniu {name}.")
        return None

    def update_employee_salary(self, name, new_salary):
        employee = self.find_employee_by_name(name)
        if employee:
            employee.salary = new_salary
            self.save_employees_to_file()
            print(f"Zaktualizowano wynagrodzenie dla {name} na {new_salary} PLN.")

    @staticmethod
    def validate_employee(employee):
        return (
                isinstance(employee.name, str) and len(employee.name) > 0 and
                isinstance(employee.age, int) and employee.age > 0 and
                isinstance(employee.salary, (int, float)) and employee.salary > 0
        )


class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def login(self):
        print("Logowanie do systemu:")
        username = input("Nazwa użytkownika: ")
        password = getpass.getpass("Hasło: ")
        return username == "admin" and password == "admin"

    def add_employee(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        age = input("Podaj wiek pracownika: ")
        salary = input("Podaj wynagrodzenie pracownika: ")

        try:
            age = int(age)
            salary = float(salary)
            employee = Employee(name, age, salary)
            self.manager.add_employee(employee)
        except ValueError:
            print("Błąd: nieprawidłowy format wieku lub wynagrodzenia.")

    def display_employees(self):
        self.manager.display_employees()

    def remove_employees_by_age_range(self):
        min_age = input("Podaj minimalny wiek: ")
        max_age = input("Podaj maksymalny wiek: ")

        try:
            min_age = int(min_age)
            max_age = int(max_age)
            self.manager.remove_employees_by_age_range(min_age, max_age)
        except ValueError:
            print("Błąd: nieprawidłowy format dla wieku.")

    def update_employee_salary(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        new_salary = input("Podaj nowe wynagrodzenie: ")

        try:
            new_salary = float(new_salary)
            self.manager.update_employee_salary(name, new_salary)
        except ValueError:
            print("Błąd: nieprawidłowy format wynagrodzenia.")

    def main_menu(self):
        if not self.login():
            print("Niepoprawna nazwa użytkownika lub hasło.")
            return

        while True:
            print("\nMENU:")
            print("1. Dodaj pracownika")
            print("2. Wyświetl pracowników")
            print("3. Usuń pracowników w przedziale wiekowym")
            print("4. Aktualizuj wynagrodzenie pracownika")
            print("5. Wyjście")
            choice = input("Wybierz opcję: ")
            if choice == '1':
                self.add_employee()
            elif choice == '2':
                self.display_employees()
            elif choice == '3':
                self.remove_employees_by_age_range()
            elif choice == '4':
                self.update_employee_salary()
            elif choice == '5':
                print("Zakończono program.")
                break
            else:
                print("Nieprawidłowa opcja. Spróbuj ponownie.")


# Uruchomienie programu
frontend_manager = FrontendManager()
frontend_manager.main_menu()
