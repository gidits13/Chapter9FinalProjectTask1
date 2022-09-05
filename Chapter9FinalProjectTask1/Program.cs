using System.Runtime.Serialization;

namespace Chapter9FinalProjectTask1
{
    public class CustomException : Exception
    {
       public CustomException()
        { }
       public CustomException(string message) : base(message)
        {
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception[] excarray = new Exception[5] { new ArgumentException("Неверный аргумент"), new CustomException("Custom Exception"),
                new DivideByZeroException("Нельзя делить на 0") ,new DirectoryNotFoundException("Диретория не найдена"),new FormatException("Неверный формат") };
            foreach(var ex in excarray)
            {
                try
                {
                    throw ex;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Hello, World!");
        }
    }
}