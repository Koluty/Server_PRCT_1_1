using System;

namespace Server
{
    internal class Calculate
    {
        double result = 1;
        public double Calculate_formula(double a, double b, double c)
        {
            for (int i = 0; i <= 5; i++)
                result *= (Math.Pow(a, 2) * b * c - c * Math.Pow(b, 2)) / ((Factorial(i) * (a + b + c)));

            return result;
        }
        private int Factorial(int n)
        {
            // Перевірка на базовий випадок (якщо n дорівнює 0 або 1)
            if (n == 0 || n == 1)
            {
                return 1;
            }

            // Рекурсивний виклик функції для обчислення факторіала n-1
            return n * Factorial(n - 1);
        }
    }
}
