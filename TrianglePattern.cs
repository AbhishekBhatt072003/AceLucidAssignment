using System;

namespace TrianglePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter the height of the triangle
            Console.Write("Enter the height of the triangle: ");
            
            // Try to parse the user input as an integer and ensure it is a positive number
            if (int.TryParse(Console.ReadLine(), out int triangleHeight) && triangleHeight > 0)
            {
                // Call the method to draw the triangle with the specified height
                DrawTriangle(triangleHeight);
            }
            else
            {
                // Inform the user if the input is invalid
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }

        static void DrawTriangle(int height)
        {
            // Loop through each level of the triangle
            for (int level = 1; level <= height; level++)
            {
                // Print leading spaces for alignment
                for (int space = 0; space < height - level; space++)
                {
                    Console.Write(" ");
                }
                // Print the stars for the current level
                for (int star = 0; star < (2 * level - 1); star++)
                {
                    Console.Write("*");
                }
                // Move to the next line after printing stars for the current level
                Console.WriteLine();
            }
        }
    }
}
