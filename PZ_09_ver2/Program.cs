namespace PZ_09_ver2

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите любой текст: ");
            string inputString = Console.ReadLine();
            string[] words = inputString.Split(' ');
            // Разделяем строку на слова

            Array.Sort(words, (x, y) => y.Length.CompareTo(x.Length));
            // Сортируем слова по убыванию длины

            string outputString = string.Join(" ", words.Select(word => new string(word.Reverse().ToArray())));
            // Переворачиваем каждое слово и объединяем их обратно в строку

            Console.WriteLine($"Итоговый текст: {outputString}");
        }

    }
}