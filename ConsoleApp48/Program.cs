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
        {                                    //                                                                                                                                \\
                                             //                                                Settings                                                                        \\
                                             //                                           __|__________________________________________________________________________        \\
            double alpha = 1.1;              //    Prey's natural growth rate               |    Recommended:       1 - 2     Min:           1     Max:           5            \\
            double beta = 0.1;               //    Predator efficiency                      |    Recommended:  0.01 - 0.6     Min:        0.01     Max:           1            \\
            double gamma = 0.4;              //    Predator's death rate                    |    Recommended:   0.3 - 0.6     Min:         0.1     Max:           1            \\
            double delta = 0.1;              //    How many prey are converted              |    Recommended:  0.05 - 0.4     Min:        0.01     Max:           1            \\
                                             //    into predator births.                    |                                                                                  \\
                                             //                                             |                                                                                  \\
            double prey_population = 100;    //    Inital prey population.                  |    Recommended:    10 - 150     Min:           2     Max:       10000            \\
            double predator_population = 10; //    Inital predator population.              |    Recommended:      1 - 15     Min:           2     Max:       10000            \\
            double time_step = 0.1;          //    Increments in time.                      |    Recommended:  0.05 - 0.2     Min:        0.01     Max:           5            \\
            double total_time = 24;          //    Total time to run simulation.            |    Recommended:     5 - 100     Min:           1     Max:        1000            \\
                                             //                                             |                                                                                  \\
                                             //                                                                                                                                \\

            // Store the peaks and mins with a time
            string peak_prey = $"{prey_population}, 0", peak_predators = $"{predator_population}, 0", min_prey = $"{prey_population}, 0", min_predators = $"{predator_population}, 0";

            Console.WriteLine("\n                                    Population");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Initial Prey Population:            {prey_population}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Initial Predator Population:        {predator_population}");

            Console.ForegroundColor = ConsoleColor.White;

            // Main loop
            for (double time = 0; time < total_time; time += time_step)
            {
                double prey_growth = alpha * prey_population;
                double predator_consumption = beta * prey_population * predator_population;
                double prey_change = prey_growth - predator_consumption;

                double predator_growth = delta * predator_consumption;
                double predator_death = gamma * predator_population;
                double predator_change = predator_growth - predator_death;

                prey_population = prey_population + (prey_change * time_step);
                predator_population = predator_population + (predator_change * time_step);

                // Checks for peak and min populations
                if ( prey_population < double.Parse(min_prey.Split(',')[0]) ) // Minimum number of prey
                {
                    min_prey = $"{prey_population}, {time}";
                }
                if ( predator_population < double.Parse(min_predators.Split(',')[0])) // Minimum number of predators
                {
                    min_predators = $"{predator_population}, {time}";
                }
                if ( prey_population > double.Parse(peak_prey.Split(',')[0])) // Peak number of prey
                {
                    peak_prey = $"{prey_population}, {time}";
                }
                if ( predator_population > double.Parse(peak_predators.Split(',')[0]) ) // Peak number of predators
                {
                    peak_predators = $"{predator_population}, {time}";
                }

                if ( prey_population <= 1 || predator_population <= 1 ) // Break loop if population is too low
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"Time:                               {time}/{total_time}");
                Console.WriteLine($"Prey Population:                    {prey_population}");
                Console.WriteLine($"Predator Population:                {predator_population}");
            }

            Console.WriteLine("\n                                    Population");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Final Prey Population:              {prey_population}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Final Predator Population:          {predator_population}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n                                    Population,       Time");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Peak Prey:                          {peak_prey}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Peak Predators:                     {peak_predators}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Minimum Prey:                       {min_prey}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Minimum Predators:                  {min_predators}");

            Console.ReadKey();

        }
    }
}
