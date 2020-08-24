using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Oops! Something went wrong.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Program completed");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[input];

            try
            {
                int[] populated = Populate(array);

                int arraySum = GetSum(populated);

                int product = GetProduct(populated, arraySum);

                decimal quotient = GetQuotient(product);

                Console.WriteLine("Your array is size: {0}", array.Length);
                Console.WriteLine("The numbers in the array are " + String.Join(",", array));
                Console.WriteLine("The sum of the array is {0}", arraySum);
                Console.WriteLine("{0} * {1} = {2}", arraySum, product / arraySum, product);
                Console.WriteLine("{0} / {1} = {2}", product, product / quotient, quotient);
            }
            catch(FormatException fex)
            {
                Console.WriteLine(fex.Message);
            }
            catch(OverflowException oex)
            {
                Console.WriteLine(oex.Message);
            }
        }

        static int[] Populate(int[] array)
        {
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
            int sum = 0;
            foreach(int value in array)
            {
                sum += value;
            }
            if(sum >= 20)
            {
                return sum;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Value of " + sum + " is too low.");
            }
        }
        
        static int GetProduct(int[] array, int sum)
        {
            Console.WriteLine("Please select a random number between 1 and {0}: ", array.Length);
            string str = Console.ReadLine();
            int num = Convert.ToInt32(str);

            try
            {
                int product = sum * array[num];

                return product;
            }
            catch(IndexOutOfRangeException ioex)
            {
                Console.WriteLine(ioex.Message);
                throw;
            }
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine("Please enter a number to divide your product {0} by: ", product);
            string str = Console.ReadLine();

            try
            {
                decimal fixedProduct = Convert.ToDecimal(product);
                decimal num = Convert.ToDecimal(str);
                decimal quotient = Decimal.Divide(fixedProduct, num);
                return quotient;
            }
            catch(DivideByZeroException dzex)
            {
                Console.WriteLine(dzex);
                return 0;
            }
        }
    }
}
