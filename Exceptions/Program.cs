using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Starts sequence of running each and every method.
                StartSequence();
            }
            catch(Exception ex)
            {
                // Catch any errors happening and log the error.
                Console.WriteLine("Oops! Something went wrong.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // No matter pass or fail, log "Program completed".
                Console.WriteLine("Program completed");
            }
        }

        static void StartSequence()
        {
            // Gather input from the user, and using that input create an array.
            Console.WriteLine("Enter a number greater than zero: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[input];

            try
            {
                // Try to run each other method, given the initial array.

                int[] populated = Populate(array);

                int arraySum = GetSum(populated);

                int product = GetProduct(populated, arraySum);

                decimal quotient = GetQuotient(product);

                // Given that everything works, show the user what their numbers were used for.

                Console.WriteLine("Your array is size: {0}", array.Length);
                Console.WriteLine("The numbers in the array are " + String.Join(",", array));
                Console.WriteLine("The sum of the array is {0}", arraySum);
                Console.WriteLine("{0} * {1} = {2}", arraySum, product / arraySum, product);
                Console.WriteLine("{0} / {1} = {2}", product, product / quotient, quotient);
            }
            catch(FormatException fex)
            {
                // Catch any errors of improper input (can't turn to integer).
                Console.WriteLine(fex.Message);
            }
            catch(OverflowException oex)
            {
                // Catch any errors if input is too large or too small.
                Console.WriteLine(oex.Message);
            }
        }

        static int[] Populate(int[] array)
        {
            // For the length of the array that came from the original number they gave you, ask for a number to fill in each array slot.
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Please enter number: {0} of {1}", i + 1, array.Length);
                string value = Console.ReadLine();
                array[i] = Convert.ToInt32(value);
            }
            return array;
        }

        static int GetSum(int[] array)
        {
            // Create sum variable, and then iterate over the array, adding each value to the sum.
            int sum = 0;
            foreach(int value in array)
            {
                sum += value;
            }
            // Only return the sum if it's a large enough integer.
            if(sum >= 20)
            {
                return sum;
            }
            else
            {
                // If the final value is less than 20, throw custom exception saying the value is too low.
                throw new System.ArgumentOutOfRangeException("Value of " + sum + " is too low.");
            }
        }
        
        static int GetProduct(int[] array, int sum)
        {
            // Ask for a random number between 1 and their array length.
            Console.WriteLine("Please select a random number between 1 and {0}: ", array.Length);
            string str = Console.ReadLine();
            int num = Convert.ToInt32(str);

            try
            {
                // Try to multiply the given number by the sum of the array values.
                int product = sum * array[num];

                return product;
            }
            catch(IndexOutOfRangeException ioex)
            {
                // Catch if the value is too large or small, log the error.
                Console.WriteLine(ioex.Message);
                throw;
            }
        }

        static decimal GetQuotient(int product)
        {
            // Ask for a number to divide your product by.
            Console.WriteLine("Please enter a number to divide your product {0} by: ", product);
            string str = Console.ReadLine();

            try
            {
                // Try to change the product from integer to decimal, then use that to divide by the given number, and return the value.
                decimal fixedProduct = Convert.ToDecimal(product);
                decimal num = Convert.ToDecimal(str);
                decimal quotient = Decimal.Divide(fixedProduct, num);
                return quotient;
            }
            catch(DivideByZeroException dzex)
            {
                // Catch if the value is 0, then log DivideByZeroException message and return 0 to the user.
                Console.WriteLine(dzex);
                return 0;
            }
        }
    }
}
