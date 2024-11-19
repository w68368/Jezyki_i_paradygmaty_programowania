class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"Pracownik: {self.name}, Wiek: {self.age}, Wynagrodzenie: {self.salary} PLN"

    def update_salary(self, new_salary):
        self.salary = new_salary


class EmployeesManager:
    def __init__(self):
        self.employees = []

    def add_employee(self, employee):
        self.employees.append(employee)
        print(f"Dodano pracownika: {employee.name}")

    def display_employees(self):
        if self.employees:
            print("Lista pracowników:")
            for emp in self.employees:
                print(emp)
        else:
            print("Brak pracowników.")

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
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
            employee.update_salary(new_salary)
            print(f"Zaktualizowano wynagrodzenie dla {name} na {new_salary} PLN.")


class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def add_employee(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        age = int(input("Podaj wiek pracownika: "))
        salary = float(input("Podaj wynagrodzenie pracownika: "))
        employee = Employee(name, age, salary)
        self.manager.add_employee(employee)

    def display_employees(self):
        self.manager.display_employees()

    def remove_employees_by_age_range(self):
        min_age = int(input("Podaj minimalny wiek: "))
        max_age = int(input("Podaj maksymalny wiek: "))
        self.manager.remove_employees_by_age_range(min_age, max_age)

    def update_employee_salary(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        new_salary = float(input("Podaj nowe wynagrodzenie: "))
        self.manager.update_employee_salary(name, new_salary)

    def main_menu(self):
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
