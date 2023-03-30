using System;

class Program
{
    static void Main(string[] args)
    {
        int rows = 10; // Change this value to adjust the height of the pyramid
        int columns = rows * 2 - 1;

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= columns; j++)
            {
                if (j >= rows - i + 1 && j <= rows + i - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

