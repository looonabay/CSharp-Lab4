using System;

namespace Lab4;

internal class Program
{
    private static void Main(string[] args)
    {
        Checked check = new Checked();
        Tasks tasks = new Tasks();

        Console.WriteLine("Введите номер задания 1 - 5:");
        int choice = check.ReadInt("Номер задания:");

        switch (choice)
        {
            case 1:
                Console.WriteLine("Задание 1");
                Tasks.Task1(check);
                break;

            case 2:
                Console.WriteLine("Задание 2");
                Tasks.Task2(check);
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
