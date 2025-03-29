using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nikitin_Exam.Model;

namespace Nikitin_Exam
{
    class Program
    {
        static void Main()
        {
            WeatherControl weatherControl = new WeatherControl();

            int n = GetValidReadingCount();

            for (int i = 0; i < n; i++)
            {
                double temperature = GetValidInput("Температуру (в град. цельсия)", -89.2, 56.7); //Допустимый ввод чисел ограничен рекордным минимумом и максимумом
                double humidity = GetValidInput("Влажность (в процентах)", 0, 100);
                double pressure = GetValidInput("Давление (в мм. рт. ст.)", 650, 800); //Допустимый ввод чисел ограничен рекордным минимумом и максимумом

                Indications indication = new Indications(temperature, humidity, pressure);
                weatherControl.AddIndication(indication);
                Console.WriteLine();
            }

            weatherControl.SortIndications();
            weatherControl.SaveToFile("pogoda.txt");
            weatherControl.PrintIndications();
        }

        static int GetValidReadingCount()
        {
            int n;
            while (true)
            {
                Console.Write("Введите количество показаний: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Поле не может быть пустым. Пожалуйста, введите количество показаний.");
                    continue;
                }

                if (int.TryParse(input, out n) && n > 0)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное числовое значение больше нуля.");
                }
            }
        }

        static double GetValidInput(string fieldName, double minValue, double maxValue)
        {
            double value;
            while (true)
            {
                Console.Write($"Введите {fieldName}: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"Поле не может быть пустым. Пожалуйста, введите {fieldName}.");
                    continue;
                }

                if (double.TryParse(input, out value) && value >= minValue && value <= maxValue)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный ввод. Пожалуйста, введите числовое значение в диапазоне от {minValue} до {maxValue}.");
                }
            }
        }
    }
}
