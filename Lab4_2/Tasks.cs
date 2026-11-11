using System;

namespace Lab4;

internal class Tasks
{
    
    public static void Task6(Checked check)
    {
        // Ввод часов
        int hours;

        do
        {
            hours = check.ReadInt("Введите часы (0-23):");
        }
        while (hours < 0 || hours > 23);

        // Ввод минут
        int minutes;

        do
        {
            minutes = check.ReadInt("Введите минуты (0-59):");
        }
        while (minutes < 0 || minutes > 59);

        // Создание объекта времени
        Time time = new Time((byte)hours, (byte)minutes);

        // Ввод количества минут для добавления
        int addMinutes;

        do
        {
            addMinutes = check.ReadInt("Сколько минут добавить?");
        }
        while (addMinutes < 0);

        // Добавление минут
        Time result = time + (uint)addMinutes;

        Console.WriteLine("Исходное время: " + time);
        Console.WriteLine("Результат: " + result);
    }


    public static void Task7(Checked check)
    {

    }
}
