// using System;


//     static void Main()
//     {
//         int n = 10; // Number of unknown dice
//         int q = 3;  // Quantity of specific face value we are checking for

//         double probability = BinomialProbability(n, q);
//         Console.WriteLine($"Probability of exactly {q} dice showing the same face out of {n} unknown dice: {probability:P}");
//     }

//     static double BinomialProbability(int n, int q)
//     {
//         return BinomialCoefficient(n, q) * Math.Pow(1.0 / 6, q) * Math.Pow(5.0 / 6, n - q);
//     }

//     static double BinomialCoefficient(int n, int k)
//     {
//         if (k > n) return 0;
//         return Factorial(n) / (Factorial(k) * Factorial(n - k));
//     }

//     static double Factorial(int num)
//     {
//         if (num == 0) return 1;
//         double result = 1;
//         for (int i = 1; i <= num; i++)
//             result *= i;
//         return result;
//     }


// // modifications
// static double ProbabilityAtLeast(int n, int q)
// {
//     double sum = 0;
//     for (int k = q; k <= n; k++)
//     {
//         sum += BinomialProbability(n, k);
//     }
//     return sum;
// }


// int n = 10; // Number of unknown dice
// int q = 3;  // Quantity of specific face value we are checking for
// double probAtLeastQ = ProbabilityAtLeast(n, q);
// Console.WriteLine($"Probability of at least {q} dice showing the same face: {probAtLeastQ:P}");