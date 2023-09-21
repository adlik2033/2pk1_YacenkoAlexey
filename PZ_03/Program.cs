namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите нужное значение k (1-99): ");
            int k = int.Parse(Console.ReadLine());
            // Вводим переменную - возраст

            switch (k) // Используем "проваливающиеся ветви", как сказано в условии задачи

            {
                case 1:
                case 21:
                case 31:
                case 41:
                case 51:
                case 61:
                case 71:
                case 81:
                case 91:
                    Console.WriteLine($"Мне {k} год");
                    break;


                case 2:
                case 3:
                case 4:
                case 22:
                case 23:
                case 24:
                case 32:
                case 33:
                case 34:
                case 42:
                case 43:
                case 44:
                case 52:
                case 53:
                case 54:
                case 62:
                case 63:
                case 64:
                case 72:
                case 73:
                case 74:
                case 82:
                case 83:
                case 84:
                case 92:
                case 93:
                case 94:
                    Console.WriteLine($"Мне {k} года ");
                    break;
                   
                default:
                    Console.WriteLine($"Мне {k} лет");
                    break;
            }

        }


    }
}
 