namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ввод числа
            Console.WriteLine("Введите число");
            int x = Convert.ToInt32(Console.ReadLine());
            // вывод массива
            for (int z = 0; z < x; z++)
            {
                Console.Write(Pow(x)[z] + " ");
            }
        }
        // создание нужного массива, возращаем его
        static int[] Pow(int x)
        {
            int[] ans = new int[5];
            for (int i = 0; i < 4; i++)
            {
                int v = (int)Math.Pow(x, i + 2);
                ans[i] = v;
            }
            return ans;
        }
    }
}