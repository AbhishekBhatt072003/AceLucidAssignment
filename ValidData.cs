using System;
using System.Text.RegularExpressions;

namespace DateSeeker
{
    class Program
    {
        static string FindValidDate(string inputText)
        {
            // Define the regex pattrn for MMDDYYYY
            string pattern = @"\b(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])(\d{4})\b";
            Regex regex = new Regex(pattern); // Create a new regex objct
            Match match = regex.Match(inputText); // Find first match in the input text

            while (match.Success) // Loop while there are matches
            {
                string potentialDate = match.Value; // Extract the matched date string
                int mm = int.Parse(potentialDate.Substring(0, 2)); 
                int dd = int.Parse(potentialDate.Substring(2, 2)); 
                int yyyy = int.Parse(potentialDate.Substring(4, 4)); 

                // Check if the date is valid
                if (ValidateDate(mm, dd, yyyy))
                {
                    return potentialDate; // Return the valid date if found
                }

                match = match.NextMatch(); // Move to the next match
            }

            return null; 
        }

        static bool ValidateDate(int month, int day, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day); // Try to create a DateTime object
                return true; // Return true if date is valid
            }
            catch
            {
                return false; // Return false if DateTime creation fails
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to search for a valid date (MMDDYYYY):"); 
            string userString = Console.ReadLine(); // Read user input from the console.
            string validDate = FindValidDate(userString); // Call FindValidDate function with user input as output

            if (validDate != null) // Check if a valid date was found
            {
                Console.WriteLine("Valid date found: " + validDate); 
            }
            else
            {
                Console.WriteLine("No valid date found in the string."); 
            }
        }
    }
}
