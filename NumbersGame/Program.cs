using System;

namespace NumbersGame
{
    class Program
    {
        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            try
            {   
                Console.Write("Please enter a number greater than zero ");
                int number = Convert.ToInt32(Console.ReadLine());
                bool flag = true;
                if (number > 0) flag = false;
                while (flag)
                {
                    Console.Write("Please enter a number greater than zero ");
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number > 0) flag = false;

                }
                int[] arr = new int[number];
            
                try
                {
                    Populate(arr);
                }
                catch(FormatException) {
                    Console.WriteLine("Sorry, Wrong foramt!");
                    Console.WriteLine("Please, enter the numbers again");
                    Populate(arr);
                }

                int sum = GetSum(arr);
                int product = GetProduct(arr, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine($"Your array is size: {number}");
                Console.Write("The numbers in the array are ");
                Console.WriteLine("{0}", string.Join(", ", arr));
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {product/sum} = {product}");
                Console.WriteLine($"{product} / {product/quotient} = {quotient}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, Wrong foramt!");
            }
            
            // Update Catch new throw.
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
            
        }

        static int[] Populate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string input;
                int newInput;
                Console.WriteLine($"Please enter a number: {i + 1} of {arr.Length}");
                input = Console.ReadLine();
                newInput = Convert.ToInt32(input);
                arr[i] = newInput;
            }
            return arr;
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            // Update throw.
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }

        static int GetProduct(int[] arr, int sum)
        {       
                Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
                int random = Convert.ToInt32(Console.ReadLine());
                int product = sum * arr[random - 1];
                return product;
        }

        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide your product {product} by");
                int divisor = Convert.ToInt32(Console.ReadLine());
                decimal quotient = decimal.Divide(product, divisor);
                return quotient;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division of {0} by zero.", product);
                return 0;
            }
        }

        public static void Main(string[] args)
        {
            // Update throw for index out of range.
            try
            {
            StartSequence();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of bounds!");
            }
        }
    }
}