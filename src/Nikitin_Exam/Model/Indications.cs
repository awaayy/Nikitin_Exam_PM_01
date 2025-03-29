using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikitin_Exam.Model
{
    public class Indications
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }

        public Indications(double temperature, double humidity, double pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public override string ToString()
        {
            return $"Температура: {Temperature}, Влажность: {Humidity}, Давление: {Pressure}";
        }
    }
}