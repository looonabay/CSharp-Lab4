using System;

namespace Lab4;

internal class Program
{
    private static void Main(string[] args)
    {
        Checked check = new Checked();

        Console.WriteLine("Введите номер задания 1 - 5:");
        int choice = check.ReadInt("Номер задания:");

        switch (choice)
        {
            case 1:
                Console.WriteLine("Задание 1");
                Console.WriteLine("Выберите тип элементов:");
                Console.WriteLine("1 — целые числа");
                Console.WriteLine("2 — вещественные числа");
                Console.WriteLine("3 — строки");

                int type1 = check.ReadInt("Ваш выбор:");

                if (type1 == 1)
                    Tasks.Task1<int>(check);
                else if (type1 == 2)
                    Tasks.Task1<double>(check);
                else if (type1 == 3)
                    Tasks.Task1<string>(check);
                else
                    Console.WriteLine("Такого типа нет.");

                break;

            case 2:
                Console.WriteLine("Задание 2");
                Console.WriteLine("Выберите тип элементов:");
                Console.WriteLine("1 — целые числа");
                Console.WriteLine("2 — вещественные числа");
                Console.WriteLine("3 — строки");

                int type2 = check.ReadInt("Ваш выбор:");

                if (type2 == 1)
                    Tasks.Task2<int>(check);
                else if (type2 == 2)
                    Tasks.Task2<double>(check);
                else if (type2 == 3)
                    Tasks.Task2<string>(check);
                else
                    Console.WriteLine("Такого типа нет.");

                break;

            case 3:
                Console.WriteLine("Задание 3");
                Tasks.Task3(check);
                break;

            case 4:
                Console.WriteLine("Задание 4");
                Tasks.Task4(check);
                break;

            case 5:
                Console.WriteLine("Задание 5");
                Tasks.Task5(check);
                break;

            case 0:
                Console.WriteLine("Выход из программы.");
                break;

            default:
                Console.WriteLine("Такого задания нет.");
                break;
        }
    }
}
