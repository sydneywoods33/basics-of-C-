namespace basics
{
    internal class Program
    {
        static void Main()
        {
            double lowNumber = GetPositiveNumber("Enter a low number: ");
            double highNumber = GetNumberGreaterThan("Enter a high number: ", lowNumber);

            List<double> numbers = Enumerable.Range((int)lowNumber, (int)(highNumber - lowNumber + 1)).Select(i => (double)i).ToList();
            numbers.Reverse();

            using (StreamWriter file = new StreamWriter("numbers.txt"))
            {
                foreach (double number in numbers)
                {
                    file.WriteLine(number);
                }
            }

            Console.WriteLine("Numbers written to numbers.txt in reverse order.");

            double sum = 0;
            using (StreamReader file = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    sum += double.Parse(line);
                }
            }

            Console.WriteLine("The sum of the numbers in the file is: " + sum);

            Console.WriteLine("Prime numbers between low and high are: ");
            for (int i = (int)lowNumber; i <= (int)highNumber; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }

            double difference = highNumber - lowNumber;
            Console.WriteLine("The difference between the high and low number is: " + difference);
        }

        static double GetPositiveNumber(string prompt)
        {
            double number;
            do
            {
                Console.Write(prompt);
                number = double.Parse(Console.ReadLine());
            } while (number <= 0);

            return number;
        }

        static double GetNumberGreaterThan(string prompt, double minValue)
        {
            double number;
            do
            {
                Console.Write(prompt);
                number = double.Parse(Console.ReadLine());
            } while (number <= minValue);

            return number;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
