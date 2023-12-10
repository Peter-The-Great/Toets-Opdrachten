namespace Async;
class Mijn
{
    public static async Task Hoofd()
    {
        int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] matrix2 = { { 7, 8 }, { 9, 10 }, { 11, 12 } };

        int[,] result = await MultiplyMatricesAsync(matrix1, matrix2);

        Console.WriteLine("Result of matrix multiplication:");
        PrintMatrix(result);
    }
    public static async Task<int[,]> MultiplyMatricesAsync(int[,] matrix1, int[,] matrix2)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            throw new ArgumentException("Invalid matrix dimensions for multiplication");

        int rowsA = matrix1.GetLength(0);
        int colsA = matrix1.GetLength(1);
        int colsB = matrix2.GetLength(1);

        int[,] result = new int[rowsA, colsB];

        // Parallelize the outer loop to partition the source array by rows.
        await Task.Run(() =>
        {
            Parallel.For(0, rowsA, i =>
            {
                for (int j = 0; j < colsB; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            });
        });

        return result;
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
