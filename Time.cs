using System;

namespace Lab4;

public class Time
{
    private byte hours;
    private byte minutes;

    // Конструктор
    public Time(byte hours, byte minutes)
    {
        if (hours > 23 || minutes > 59)
        {
            throw new ArgumentException("Некорректное время.");
        }

        this.hours = hours;
        this.minutes = minutes;
    }
    
    public static Time operator +(Time time, uint minutesToAdd)
    {
        ulong totalMinutes = (ulong)time.hours * 60 + time.minutes + minutesToAdd;

        totalMinutes = totalMinutes % 1440;

        byte newHours = (byte)(totalMinutes / 60);
        byte newMinutes = (byte)(totalMinutes % 60);

        return new Time(newHours, newMinutes);
    }
    
    public override string ToString()
    {
        return hours.ToString("D2") + ":" + minutes.ToString("D2");
    }
}