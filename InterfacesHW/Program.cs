namespace InterfacesHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор сложения");

            double x = 0;
            double y = 0;
            bool inputSuccess = false;

            while (!inputSuccess)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    x = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    y = Convert.ToDouble(Console.ReadLine());

                    inputSuccess = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введено не число. Попробуйте снова.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }
            
            Calculator calculator = new Calculator(x, y);
            Console.WriteLine($"{x} + {y} = {calculator.Add()}");
        }
    }

    public interface IAddition
    {
        double Add();
    }

    public class Calculator : IAddition
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public Calculator(double firstNumber, double secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public double Add() 
        {
            return FirstNumber + SecondNumber;
        }
    }
}
