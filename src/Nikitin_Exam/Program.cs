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

            Console.Write("Введите количество показаний: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите температуру (в град. цельсия): ");
                double temperature = double.Parse(Console.ReadLine());

                Console.Write("Введите влажность (в процентах): ");
                double humidity = double.Parse(Console.ReadLine());

                Console.Write("Введите давление (в мм. рт. ст.): ");
                double pressure = double.Parse(Console.ReadLine());

                Indications indication = new Indications(temperature, humidity, pressure);
                weatherControl.AddIndication(indication);
            }

            weatherControl.SortIndications();
            weatherControl.SaveToFile("pogoda.txt");
        }
    }
}



