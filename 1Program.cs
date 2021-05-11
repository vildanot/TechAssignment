using System;

public class Program
{
    static int maxPathSum(int[,] tri, int m)
    {
        removePrimeNumbers(ref tri);

        for (int i = m - 1; i >= 0; i--)
        {

            for (int j = 0; j <= i; j++)
            {



                if (tri[i + 1, j] >
                       tri[i + 1, j + 1])
                    tri[i, j] +=
                           tri[i + 1, j];
                else
                    tri[i, j] +=
                       tri[i + 1, j + 1];
            }
        }


        return tri[0, 0];
    }

    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }

    private static void removePrimeNumbers(ref int[,] matrixOfTriangle)
    {
        int length = matrixOfTriangle.GetLength(0);
        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < length; j++)
            {
                if (matrixOfTriangle[i, j] == 0)
                {
                    continue;
                }
                else if (IsPrime(matrixOfTriangle[i, j]))
                {
                    matrixOfTriangle[i, j] = 0;
                }
            }
        }
    }

    public static void Main()
    {
        int[,] tri = { {1, 0, 0 , 0},
                            {8, 4, 0 , 0},
                            {2, 6, 9 , 0},
                            {8 , 5 , 9 , 3}};

        Console.Write(maxPathSum(tri, 3));
    }
}