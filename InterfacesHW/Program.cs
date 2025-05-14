namespace InterfacesHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            ICalculator calculator = new Calculator(logger);

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
                    logger.LogError("Введено не число. Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    logger.LogError("Произошла ошибка: " + ex.Message);
                }
            }
            
            Console.WriteLine($"Результат: {x} + {y} = {calculator.Add(x, y)}");
            logger.LogEvent("Программа завершена");
        }
    }

    public interface ICalculator
    {
        double Add(double FirstNumber, double SecondNumber);
    }

    public class Calculator : ICalculator
    {
        private readonly ILogger _logger;
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public Calculator(ILogger logger)
        {
            _logger = logger;
            _logger.LogEvent("Калькулятор запущен");
        }

        public double Add(double FirstNumber, double SecondNumber) 
        {
            _logger.LogEvent($"Выполняется сложение: {FirstNumber} + {SecondNumber}");
            double result = FirstNumber + SecondNumber;
            _logger.LogEvent($"Результат сложения: {result}");
            return result;
        }
    }
}

public interface ILogger
{
    void LogEvent(string message);
    void LogError(string message);
}

public class Logger : ILogger
{
    public void LogEvent(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[СОБЫТИЕ] {DateTime.Now}: {message}");
        Console.ResetColor();
    }
    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ОШИБКА] {DateTime.Now}: {message}");
        Console.ResetColor();
    }
}
