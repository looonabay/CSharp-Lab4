using System;

namespace Lab4;

internal class Program
{
    private static void Main(string[] args)
    {
        Checked check = new Checked();

        Console.WriteLine("Введите номер задания 6 - 7:");
        int choice = check.ReadInt("Номер задания:");

        switch (choice)
        {
            case 6:
                Console.WriteLine("Задание 6");
                Tasks.Task6(check);
                break;

            case 7:
                Console.WriteLine("Задание 7");
                Tasks.Task7(check);
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