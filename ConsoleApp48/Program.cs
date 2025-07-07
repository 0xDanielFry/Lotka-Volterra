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
                                             //                                                Settings                                                                        \\
                                             //                                           __|___________________________________________________________________________       \\
            double alpha = 1.1;              //    Prey's natural growth rate               |       Recommended:       1 - 2     Min:           1     Max:           5         \\
            double beta = 0.1;               //    Preditor efficiency                      |       Recommended:  0.01 - 0.6     Min:        0.01     Max:           1         \\
            double gamma = 0.4;              //    Preditor's death rate                    |       Recommended:   0.3 - 0.6     Min:         0.1     Max:           1         \\
            double delta = 0.1;              //    How many prey are converted              |       Recommended:  0.05 - 0.4     Min:        0.01     Max:           1         \\
                                             //    into preditor births.                    |                                                                                  \\
                                             //                                             |                                                                                  \\
            double prey_population = 100;    //    Inital prey population.                  |       Recommended:    10 - 150     Min:           2     Max:       10000         \\
            double preditor_population = 10; //    Inital preditor population.              |       Recommended:      1 - 15     Min:           2     Max:       10000         \\
            double time_step = 0.1;          //    Increments in time.                      |       Recommended:  0.05 - 0.2     Min:        0.01     Max:           5         \\
            double total_time = 24;          //    Total time to run simulation.            |       Recommended:     5 - 100     Min:           1     Max:        1000         \\
                                             //                                             |                                                                                  \\

            string peak_prey = $"{prey_population}, 0", peak_preditors = $"{preditor_population}, 0", min_prey = $"{prey_population}, 0", min_preditors = $"{preditor_population}, 0";

            Console.WriteLine($"Initial Prey Population:            {prey_population}");
            Console.WriteLine($"Initial Preditor Population:        {preditor_population}");

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

                if ( prey_population < double.Parse(min_prey.Split(',')[0]) ) // Mininum number of prey
                {
                    min_prey = $"{prey_population}, {time}";
                }
                if ( preditor_population < double.Parse(min_preditors.Split(',')[0])) // Mininum number of preditors
                {
                    min_preditors = $"{preditor_population}, {time}";
                }
                if ( prey_population > double.Parse(peak_prey.Split(',')[0])) // Peak number of prey
                {
                    peak_prey = $"{prey_population}, {time}";
                }
                if ( preditor_population > double.Parse(peak_preditors.Split(',')[0]) ) // Peak number of preditors
                {
                    peak_preditors = $"{preditor_population}, {time}";
                }

                if ( prey_population <= 1 || preditor_population <= 1 ) // Break loop if population is too low
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"Time:                               {time}/{total_time}");
                Console.WriteLine($"Prey Population:                    {prey_population}");
                Console.WriteLine($"Preditor Population:                {preditor_population}");
            }

            Console.WriteLine();
            Console.WriteLine($"Final Prey Population:              {prey_population}");
            Console.WriteLine($"Final Preditor Population:          {preditor_population}");

            Console.WriteLine();
            Console.WriteLine("                                    Population,       Time");
            Console.WriteLine($"Peak Prey:                          {peak_prey}");
            Console.WriteLine($"Peak Preditors:                     {peak_preditors}");
            Console.WriteLine($"Mininum Prey:                       {min_prey}");
            Console.WriteLine($"Mininum Preditors:                  {min_preditors}");

            Console.ReadKey();

        }
    }
}
