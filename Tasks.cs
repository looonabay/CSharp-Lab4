using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    internal class Tasks
    {
        // задание 1 

        public static void Task1(Checked check)
        {
            List<int> numbers = new List<int>();

            int n = check.NaturalReadInt(
                    "Введите количество" +
                    " элементов списка:");

            for (int i = 0; i < n; i++)
            {
                int number =
                    check.ReadInt
                        ("Введите элемент списка:");
                numbers.Add(number);
            }

            int e = check.ReadInt("Введите число E:");

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] == e)
                {
                    numbers.RemoveAt(i);
                }
            }

            Console.WriteLine("Получившийся список:");

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }

        // Задание 2

        public static void Task2(Checked check)
        {
            LinkedList<int> numbers = new LinkedList<int>();

            int n = check.NaturalReadInt("Введите количество элементов списка:");

            for (int i = 0; i < n; i++)
            {
                int number = check.ReadInt("Введите элемент списка:");
                numbers.AddLast(number);
            }

            Console.WriteLine("Список в обратном порядке:");

            LinkedListNode<int> current = numbers.Last;

            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Previous;
            }

            Console.WriteLine();
        }

        // Задание 3

        public static void Task3(Checked check)
        {
            HashSet<string> allFirms = new HashSet<string>();

            int n = check.NaturalReadInt("Введите количество компьютерных фирм:");

            for (int i = 0; i < n; i++)
            {
                string firm = check.ReadString("Введите название фирмы:");
                allFirms.Add(firm);
            }

            int schoolCount = check.NaturalReadInt("Введите количество школ:");

            HashSet<string> allSchools = new HashSet<string>();
            HashSet<string> commonFirms = new HashSet<string>(allFirms);

            for (int i = 0; i < schoolCount; i++)
            {
                Console.WriteLine("Школа №" + (i + 1));

                int firmCount = check.ReadInt("Сколько фирм выбрала школа?");

                while (firmCount < 0)
                {
                    Console.WriteLine("Количество не может быть отрицательным.");
                    firmCount = check.ReadInt("Введите количество фирм:");
                }

                HashSet<string> schoolFirms = new HashSet<string>();

                for (int j = 0; j < firmCount; j++)
                {
                    string firm = check.ReadString("Введите название фирмы:");

                    while (allFirms.Contains(firm) == false)
                    {
                        Console.WriteLine("Такой фирмы нет в общем списке.");
                        firm = check.ReadString("Введите название фирмы:");
                    }
                    schoolFirms.Add(firm);
                }

                allSchools.UnionWith(schoolFirms);
                commonFirms.IntersectWith(schoolFirms);
            }

            HashSet<string> noSchools = new HashSet<string>(allFirms);
            noSchools.ExceptWith(allSchools);

            Console.WriteLine("\nФирмы, в которых закупались все школы:");
            foreach (string firm in commonFirms)
            {
                Console.WriteLine(firm);
            }

            Console.WriteLine("\nФирмы, в которых закупалась хотя бы одна школа:");
            foreach (string firm in allSchools)
            {
                Console.WriteLine(firm);
            }

            Console.WriteLine("\nФирмы, в которых не закупалась ни одна школа:");
            foreach (string firm in noSchools)
            {
                Console.WriteLine(firm);
            }
        }

        // Задание 4

        public static void Task4(Checked check)
        {
            string text = File.ReadAllText("Files/lab4.txt");

            HashSet<char> letters = new HashSet<char>();

            string voiced = "бвгджзйклмнр";

            for (int i = 0; i < text.Length; i++)
            {
                char letter = char.ToLower(text[i]);

                if (voiced.Contains(letter))
                {
                    letters.Add(letter);
                }
            }

            List<char> sortedLetters = new List<char>(letters);
            sortedLetters.Sort();

            Console.WriteLine("Звонкие согласные буквы:");

            for (int i = 0; i < sortedLetters.Count; i++)
            {
                Console.Write(sortedLetters[i] + " ");
            }

            Console.WriteLine();
        }

        // Проверка имени и фамилии
        private static bool IsValidName(string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > maxLength)
            {
                return false;
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLetter(value[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }

        // Заполнение файла данными об учениках
        public static void FillStudentsFile(Checked check)
        {
            int n = check.NaturalReadInt("Введите количество учеников (не более 100):");

            while (n > 100)
            {
                Console.WriteLine("Количество не должно превышать 100.");
                n = check.NaturalReadInt("Введите количество учеников:");
            }

            using (StreamWriter writer = new StreamWriter("Files/students.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nУченик №" + (i + 1));

                    string surname = check.ReadString("Введите фамилию:");

                    while (IsValidName(surname, 20) == false)
                    {
                        Console.WriteLine("Некорректная фамилия. Введите только буквы (до 20 символов).");
                        surname = check.ReadString("Введите фамилию:");
                    }

                    string name = check.ReadString("Введите имя:");

                    while (IsValidName(name, 15) == false)
                    {
                        Console.WriteLine("Некорректное имя. Введите только буквы (до 15 символов).");
                        name = check.ReadString("Введите имя:");
                    }

                    writer.WriteLine(surname + ";" + name);
                }
            }

            Console.WriteLine("\nДанные сохранены в файл.");
        }

        // Задание 5
        public static void Task5(Checked check)
        {
            FillStudentsFile(check);

            string[] students = File.ReadAllLines("Files/students.txt");

            Dictionary<string, int> surnameCounts = new Dictionary<string, int>();

            Console.WriteLine("\nСписок учеников и их логинов:");

            for (int i = 0; i < students.Length; i++)
            {
                string[] parts = students[i].Split(';');

                string surname = parts[0];
                string name = parts[1];

                if (surnameCounts.ContainsKey(surname))
                {
                    surnameCounts[surname]++;
                }
                else
                {
                    surnameCounts.Add(surname, 1);
                }

                string login = surname;

                if (surnameCounts[surname] > 1)
                {
                    login = login + surnameCounts[surname];
                }

                Console.WriteLine(name + " " + surname + " — логин: " + login);
            }
        }
    }
}