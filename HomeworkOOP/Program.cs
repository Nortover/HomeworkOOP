
// ЗМІНЕНО ДЛЯ ДОМАШНЬОЇ РОБОТИ

﻿using System;

class StudentTable
{
    private List<string[]> students = new List<string[]>();
    private int nechaiCount = 0;

    // Індексатор для доступу до стовпців таблиці за іменем
    public string[] this[string column]
    {
        get
        {
            List<string> result = new List<string>();
            switch (column)
            {
                case "iм'я":      
                    foreach (var student in students)
                        result.Add(student[0]);
                    break;
                case "прiзвище":
                    foreach (var student in students)
                        result.Add(student[1]);
                    break;
                case "по батькові":
                    foreach (var student in students)
                        result.Add(student[2]);
                    break;

            }
            return result.ToArray();
        }
    }

    // Властивість для отримання кількості студентів з прізвищем "Нечай"
    public int NechaiCount
    {
        get { return nechaiCount; }
    }

    // Додавання студента до таблиці
    public void AddStudent(string firstName, string lastName, string patronymic)
    {
        students.Add(new string[] { firstName, lastName, patronymic });
        if (lastName == "Нечай")
            nechaiCount++;
    }

    // Видалення студента з таблиці
    public void RemoveStudent(int index)
    {

        if (students[index][1] == "Нечай")
            nechaiCount--;

        students.RemoveAt(index);
    }
}

class Program
{
    static void Main()
    {
        StudentTable table = new StudentTable();

        // Додаємо студентів
        table.AddStudent("Iван", "Петров", "Олексiйович");
        table.AddStudent("Марiя", "Нечай", "Iгорiвна");
        table.AddStudent("Олег", "Сидоров", "Васильович");
        table.AddStudent("Анна", "Нечай", "Петрiвна");
        table.AddStudent("Василь", "Коваль", "Миколайович");

        // Тестуємо індексатор
        Console.WriteLine("Список iмен:");
        foreach (var name in table["iм'я"])
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nСписок прiзвищ:");
        foreach (var lastName in table["прiзвище"])
        {
            Console.WriteLine(lastName);
        }

        Console.WriteLine("\nСписок по батьковi:");
        foreach (var patronymic in table["по батькові"])
        {
            Console.WriteLine(patronymic);
        }

        // Тестуємо властивість
        Console.WriteLine($"\nКiлькiсть студентiв з прiзвищем 'Нечай': {table.NechaiCount}");

        // Видаляємо студента
        table.RemoveStudent(1);
        Console.WriteLine($"\nПiсля видалення одного Нечая, кiлькiсть студентiв з прiзвищем 'Нечай': {table.NechaiCount}");
    }
}
