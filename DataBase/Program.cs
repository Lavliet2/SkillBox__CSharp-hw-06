// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static string filePath = "DataBase.txt";

    static void Main()
    {
        // Создаем файл, если он не существует
        CreateFileIfNotExists();

        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Вывести данные на экран");
            Console.WriteLine("2 - Заполнить данные и добавить новую запись");
            Console.WriteLine("3 - Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayData();
                    break;

                case "2":
                    AddNewEmployee();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }

    static void CreateFileIfNotExists()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }

    static void DisplayData()
    {
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            Console.WriteLine("Файл пуст.");
        }
        else
        {
            Console.WriteLine("Данные сотрудников:");
            foreach (string line in lines)
            {
                Console.WriteLine(line.Replace('#', ' '));
            }
        }
    }

    static void AddNewEmployee()
    {
        Console.WriteLine("Введите данные нового сотрудника:");

        string[] lines = File.ReadAllLines(filePath);
        int id = lines.Length + 1;

        DateTime currentTime = DateTime.Now;
        string dateTime = currentTime.ToString("dd.MM.yyyy HH:mm");

        Console.Write("Ф. И. О.: ");
        string fullName = Console.ReadLine();

        int age;
        bool isOk = false;
        do
        {
            Console.Write("Возраст: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out age))
            {
                isOk = true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }
        } while (!isOk);

        double height;
        isOk = false;
        do
        {
            Console.Write("Рост: ");
            string userInput = Console.ReadLine();

            if (double.TryParse(userInput, out height))
            {
                isOk = true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }
        } while (!isOk);

        Console.Write("Дата рождения: ");
        string birthDate = Console.ReadLine();

        Console.Write("Место рождения: ");
        string birthPlace = Console.ReadLine();

        // Формируем строку с данными сотрудника
        string employeeData = $"{id}#{dateTime}#{fullName}#{age}#{height}#{birthDate}#{birthPlace}";

        // Добавляем данные в файл
        File.AppendAllText(filePath, employeeData + Environment.NewLine);

        Console.WriteLine("Данные успешно добавлены.");
    }


}
