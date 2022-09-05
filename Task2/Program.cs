namespace Task2
{
    internal class Program
    {
        class CustomException : Exception
        {
            public CustomException()
            { }
            public CustomException(string message) : base(message)
            {

            }
        }
        public class Reader
        {
            public delegate void NumReader(int number, string[] lastNames);
            public event NumReader OnNumReader;

            public void NumberReader(string[] lastNames)
            {
                Console.WriteLine("Для сортировки А-Я нажмите 1. Для сортировки Я-А нажмите 2");

                int number = Convert.ToInt32(Console.ReadLine());
                if ((number != 1) && (number != 2))
                { throw new CustomException("Введены неверные данные! Принимается только 1 или 2"); }

                numberEntered(number, lastNames);
            }
            public void numberEntered(int number, string[] lastNames)
            {
                OnNumReader?.Invoke(number, lastNames);
            }
        }

        static void SortArray(int number, string[] lastNames)
        {
            switch (number)
            {
                case 1:
                    Array.Sort(lastNames);
                    foreach(string name in lastNames)
                    {
                        Console.WriteLine(name);
                    }
                    break;
                    
                case 2:
                    Array.Sort(lastNames);
                    Array.Reverse(lastNames);
                    foreach (string name in lastNames)
                    {
                        Console.WriteLine(name);
                    }
                    break;   
            }      
        }
        static void Main(string[] args)
        {
            string[] lastNames = new string[5] { "Борисов", "Васильев", "Абрамов", "Григорьев", "Дмитриев" };
            Reader reader = new Reader();
            reader.OnNumReader += SortArray;
            try
            {
                reader.NumberReader(lastNames);
            }
            catch(FormatException e)
            { Console.WriteLine(e.Message); }
            catch(CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}