/* Write code for below problem. The input below is just an example and you should implement independent from the input. Please paste the link to the answer shared using pastebin, dotnetfiddle, jsfiddle, or any other similar web-site.
You will have an orthogonal triangle input from a file and you need to find the maximum sum of the numbers according to given rules below;

1. You will start from the top and move downwards to an adjacent number as in below.
2. You are only allowed to walk downwards and diagonally.
3. You can only walk over NON PRIME NUMBERS.
4. You have to reach at the end of the pyramid as much as possible.
5. You have to treat your input as pyramid.

According to above rules the maximum sum of the numbers from top to bottom in below example is 24.

      *1
     *8 4
    2 *6 9
   8 5 *9 3

As you can see this has several paths that fits the rule of NOT PRIME NUMBERS; 1>8>6>9, 1>4>6>9, 1>4>9>9
1 + 8 + 6 + 9 = 24.  As you see 1, 8, 6, 9 are all NOT PRIME NUMBERS and walking over these yields the maximum sum.

You can implement by using any programming language except Mathlab. Please paste the link to your code.*/





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
