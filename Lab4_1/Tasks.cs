using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    internal class Tasks
    {
        
        // Задание 1
        public static List<T> Task1<T>(Checked check)
            where T : IParsable<T>
        {
            List<T> numbers = new List<T>();

            int n = check.NaturalReadInt(
                "Введите количество элементов списка:");
            
            for (int i = 0; i < n; i++)
            {
                T number = check.ReadElement<T>(
                    "Введите элемент списка:");

                numbers.Add(number);
            }
            
            T e = check.ReadElement<T>("Введите элемент E:");

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (EqualityComparer<T>.Default.Equals(numbers[i], e))
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

            return numbers;
        }


        // Задание 2
        public static List<T> Task2<T>(Checked check)
            where T : IParsable<T>
        {
            LinkedList<T> numbers = new LinkedList<T>();

            int n = check.NaturalReadInt(
                "Введите количество элементов списка:");
            
            for (int i = 0; i < n; i++)
            {
                T number = check.ReadElement<T>(
                    "Введите элемент списка:");

                numbers.AddLast(number);
            }

            List<T> result = new List<T>();

            Console.WriteLine("Список в обратном порядке:");
            LinkedListNode<T>? current = numbers.Last;
            
            while (current != null)
            {
                Console.Write(current.Value + " ");
                result.Add(current.Value);

                current = current.Previous;
            }

            Console.WriteLine();

            return result;
        }


        // Задание 3

        public static List<string> Task3(Checked check)
        {
            HashSet<string> allFirms = new HashSet<string>();

            int n = check.NaturalReadInt
                ("Введите количество компьютерных фирм:");

            for (int i = 0; i < n; i++)
            {
                string firm = check.ReadString
                    ("Введите название фирмы:");
                allFirms.Add(firm);
            }

            int schoolCount = check.NaturalReadInt
                ("Введите количество школ:");

            HashSet<string> oneSchoolFirms = new HashSet<string>();
            HashSet<string> commonFirms = new HashSet<string>
                (allFirms);

            for (int i = 0; i < schoolCount; i++)
            {
                Console.WriteLine("Школа №" + (i + 1));

                int firmCount = check.ReadInt
                    ("Сколько фирм выбрала школа?");

                while (firmCount < 0)
                {
                    Console.WriteLine
                        ("Количество не может" +
                         " быть отрицательным.");
                    firmCount = check.ReadInt
                        ("Введите количество фирм:");
                }

                HashSet<string> schoolFirms = 
                    new HashSet<string>();

                for (int j = 0; j < firmCount; j++)
                {
                    string firm = check.ReadString
                        ("Введите название фирмы:");

                    while (oneSchoolFirms.Contains(firm) == false)
                    {
                        Console.WriteLine
                            ("Такой фирмы нет в общем списке.");
                        firm = check.ReadString
                            ("Введите название фирмы:");
                    }
                    schoolFirms.Add(firm);
                }

                oneSchoolFirms.UnionWith(schoolFirms);
                commonFirms.IntersectWith(schoolFirms);
            }

            HashSet<string> noSchools = 
                new HashSet<string>(allFirms);
            noSchools.ExceptWith(oneSchoolFirms);
            
            List<string> result = new List<string>();

            Console.WriteLine
                ("\nФирмы, в которых закупались все школы:");
            foreach (string firm in commonFirms)
            {
                Console.WriteLine(firm);
                result.Add("Все школы: " + firm);
            }
            Console.WriteLine
                
                ("\nФирмы, в которых закупалась хотя бы одна школа:");
            foreach (string firm in oneSchoolFirms)
            {
                Console.WriteLine(firm);
                result.Add("Хотя бы одна школа: " + firm);
            }
            Console.WriteLine

                ("\nФирмы, в которых не закупалась ни одна школа:");
            foreach (string firm in noSchools)
            {
                Console.WriteLine(firm);
                result.Add("Ни одна школа: " + firm);
            }

            return result;
        }

        // Задание 4

        public static List<char> Task4(Checked check)
        {
            List<char> result = new List<char>();

            if (!File.Exists("Files/lab4.txt"))
            {
                Console.WriteLine("Ошибка!Файл не найден");
                return result;
            }
            
            string text = File.ReadAllText
                ("Files/lab4.txt");

            HashSet<char> letters = new HashSet<char>();

            string voiced = "бвгджзйлмнр";

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
                result.Add(sortedLetters[i]);
            }

            Console.WriteLine();
            return result;
        }
        
        // 5 задание (файл)
        
        public static void FillStudentsFile(Checked check)
        {
            int n = check.NaturalReadInt
                ("Введите количество учеников " +
                 "(не более 100):");

            while (n > 100)
            {
                Console.WriteLine
                    ("Количество не должно превышать 100.");
                n = check.NaturalReadInt
                    ("Введите количество учеников:");
            }

            using (StreamWriter writer = new StreamWriter
                       ("Files/students.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nУченик №" + (i + 1));

                    string surname = check.ReadString
                        ("Введите фамилию:");

                    while (Checked.IsValidName(surname, 
                               20) == false)
                    {
                        Console.WriteLine
                            ("Некорректная фамилия. Введите " +
                             "только буквы (до 20 символов).");
                        surname = check.ReadString
                            ("Введите фамилию:");
                    }

                    string name = check.ReadString
                        ("Введите имя:");

                    while (Checked.IsValidName(name, 
                               15) == false)
                    {
                        Console.WriteLine
                            ("Некорректное имя. Введите только " +
                             "буквы (до 15 символов).");
                        name = check.ReadString
                            ("Введите имя:");
                    }

                    writer.WriteLine(surname + ";" + name);
                }
            }

            Console.WriteLine("\nДанные сохранены в файл.");
        }

        // Задание 5
        public static List<string> Task5(Checked check)
        {
            FillStudentsFile(check);

            string[] students = File.ReadAllLines
                ("Files/students.txt");

            Dictionary<string, int> surnameCounts
                = new Dictionary<string, int>();

            List<string> result = new List<string>();

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

                Console.WriteLine
                    (name + " " + surname + " — логин: " + login);
                result.Add(login);
            }
            return result;
        }
    }
}
