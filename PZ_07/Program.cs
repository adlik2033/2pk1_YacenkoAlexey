namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = new int[,]
            {

            { 11, 41, 35 },
            { 43, 44, 123 },
            { 7, 555, 21 },
            { 11, 41, 12 }

            };




            int minSumRowIndex = 0;
            int minSum = GetRowSum(matrix, 0);

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int sum = GetRowSum(matrix, i);
                if (sum < minSum)
                {
                    minSum = sum;
                    minSumRowIndex = i;
                }
            }

            Console.WriteLine("Строка с минимальной суммой элементов: " + minSumRowIndex);
        }

        static int GetRowSum(int[,] matrix, int rowIndex)
        {
            int sum = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[rowIndex, j];
            }

            return sum;
        }
    }
}

