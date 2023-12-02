namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вводим нужные нам переменные и делаем красивый ввод
            double a;
            double b;
            double c;
            double x = 0;
            double y = 0;
            Console.WriteLine("Решение уравнения ax+bx+c=0, но a != 0");
            Console.WriteLine("Введите значение A:");
            Console.WriteLine("A ---> ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение B:");
            Console.WriteLine("B ---> ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение C:");
            Console.WriteLine("C ---> ");
            c = Convert.ToDouble(Console.ReadLine());

            GetResult(a, b, c, out x, out y);
            Console.WriteLine("Ответ: ");
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        // сам метод без возрата значений void
        static void GetResult(double a, double b, double c, out double x, out double y)
        {
            // вычмсление x1 и x2, для удобства обозначил x и y
            double d = 0;
            double z = 0;
            d = ((b * b) - 4 * a * c);
            z = Math.Sqrt(d);
            x = ((-b) + z) / 2 * a;
            y = ((-b) - z) / 2 * a;

        }
    }
}