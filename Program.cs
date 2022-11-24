namespace SkillFactoryInterfaces
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();
            try
            {
                Console.WriteLine("Введите первое число!");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите второе число!");
                int num2 = int.Parse(Console.ReadLine());
                Calculate cal = new Calculate(Logger);
                Console.BackgroundColor = ConsoleColor.Blue;
                Logger.Event("Калькулятор выполнил работу!\n");
                Console.WriteLine("Сумма чисел - " + cal.Calc(num1, num2));
                Console.ReadKey();
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Logger.Error("Оишбка в калькуляторе!");
            }
        }
    }
    public interface ICalculate
    {
        public int Calc(int number1, int number2);
    }
    public class Calculate : ICalculate
    {
        ILogger Logger { get; }
        public Calculate(ILogger logger)
        {
            Logger = logger;
        }
        public int Calc(int number1, int number2)
        {
            return number1 + number2;
        }
    }
    public interface ILogger
    {
        public void Event(string message);
        public void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.Write(message);
        }

        public void Event(string message)
        {
            Console.Write(message);
        }
    }
}
