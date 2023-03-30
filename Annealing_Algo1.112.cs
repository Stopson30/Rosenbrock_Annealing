static void Main(string[] args)
{
    // Define the Rosenbrock function
    Func<double, double, double> rosenbrock = (x, y) => Math.Pow(1 - x, 2) + 100 * Math.Pow(y - x * x, 2);

    // Define the temperature schedule
    Func<double, double> temperature = (t) => t * 0.99;

    // Initialize the starting point
    double x = 0, y = 0;
    double currentEnergy = rosenbrock(x, y);

    // Set the initial temperature
    double T = 1;

    // Perform the simulated annealing algorithm
    while (T > 0.0001)
    {
        // Generate a random new point
        double newX = x + (new Random().NextDouble() - 0.5) * T;
        double newY = y + (new Random().NextDouble() - 0.5) * T;

        // Compute the new energy
        double newEnergy = rosenbrock(newX, newY);

        // Check if the new point is better
        if (newEnergy < currentEnergy)
        {
            x = newX;
            y = newY;
            currentEnergy = newEnergy;
        }
        else
        {
            // Calculate the acceptance probability
            double deltaE = newEnergy - currentEnergy;
            double acceptanceProbability = Math.Exp(-deltaE / T);

            // Accept the new point with probability acceptanceProbability
            if (new Random().NextDouble() < acceptanceProbability)
            {
                x = newX;
                y = newY;
                currentEnergy = newEnergy;
            }
        }

        // Update the temperature
        T = temperature(T);
    }

    // Print the final result
    Console.WriteLine("The minimum value of the Rosenbrock function is " + currentEnergy + " at x = " + x + " and y = " + y);
}
