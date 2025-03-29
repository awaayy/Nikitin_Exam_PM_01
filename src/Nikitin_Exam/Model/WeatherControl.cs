using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikitin_Exam.Model
{
    public class WeatherControl
    {
        private List<Indications> indicationsList;

        public WeatherControl()
        {
            indicationsList = new List<Indications>();
        }

        public void AddIndication(Indications indication)
        {
            indicationsList.Add(indication);
        }

        public void SortIndications()
        {
            indicationsList = indicationsList.OrderBy(x => x.Temperature).ThenBy(x => x.Humidity).ToList();
        }

        public void SaveToFile(string filename)
        {
            string baseName = Path.GetFileNameWithoutExtension(filename); // Название файла
            string extension = Path.GetExtension(filename); // расширение файла
            string directory = Path.GetDirectoryName(filename); // путь к директории

            // Возможность создавать несколько файлов с данными о погоде
            int counter = 1;
            string newFilename = filename;

            // Проверка на существование файла с данными погоды и добавление порядкового номера
            while (File.Exists(newFilename))
            {
                newFilename = Path.Combine(directory, $"{baseName}_{counter}{extension}");
                counter++;
            }

            // Запись данных в файл
            using (StreamWriter writer = new StreamWriter(newFilename))
            {
                writer.WriteLine("Показатели погоды".PadRight(30));
                writer.WriteLine("=".PadRight(30, '='));
                writer.WriteLine("Температура/Влажность/Давление".PadRight(30));
                writer.WriteLine("-".PadRight(30, '-'));

                foreach (var indication in indicationsList)
                {
                    writer.WriteLine($"{indication.Temperature,10} {indication.Humidity,8} {indication.Pressure,8}");
                }
            }
            Console.WriteLine($"Данные успешно сохранены в файл '{newFilename}' в подкаталоге Debug директории bin данного проекта.");
            Console.WriteLine();
        }

        public void PrintIndications()
        {
            Console.WriteLine("Показатели погоды, введенные в файл".PadRight(30));
            Console.WriteLine("=".PadRight(30, '='));
            Console.WriteLine("Температура/Влажность/Давление".PadRight(30));
            Console.WriteLine("-".PadRight(30, '-'));

            foreach (var indication in indicationsList)
            {
                Console.WriteLine($"{indication.Temperature,10} {indication.Humidity,8} {indication.Pressure,8}");
            }
        }
    }
}

