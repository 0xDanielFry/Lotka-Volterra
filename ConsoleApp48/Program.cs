using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp48
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double alpha = 0.5; // Prey's natural growth rate
            double beta = 0.3; // Preditor efficiency
            double gamma = 0.6; // Preditor's death rate
            double delta = 0.7; // How many prey are converted into preditor births

            double prey_population = 10;
            double preditor_population = 10;
            double time_step = 1;
            double total_time = 24;

            for (double time = 0; time < total_time; time += time_step)
            {
                double prey_growth = alpha * prey_population;
                double preditor_consumption = beta * prey_population * preditor_population;
                double prey_change = prey_growth - preditor_consumption;

                double preditor_growth = delta * preditor_consumption;
                double preditor_death = gamma * preditor_population;
                double preditor_change = preditor_growth - preditor_death;

                prey_population = prey_population + (prey_change * time_step);
                preditor_population = preditor_population + (preditor_change * time_step);

                Console.WriteLine($"Prey Population: {prey_population}");
                Console.WriteLine($"Preditor Population: {preditor_population}");
            }

            Console.ReadKey();

        }
    }
}
