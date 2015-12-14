namespace Gu.Units.Generator.Tests.Sandbox
{
    using System;
    using NUnit.Framework;

    public class DoublePrecision
    {
        [Test]
        public void Mile()
        {
            var f = 1609.344;
            var d = f * 1;
            var rt = d / f;
            Console.WriteLine(rt == 1);
        }

        [Test]
        public void TestName()
        {

            Console.WriteLine($"1E3 {RoundtripsMultiplication(1E3, 1E-3)} {RoundtripsMultiplicationDivision(1000)} {RoundtripsDivision(1E3)} {Pow(3)}");
            Console.WriteLine($"1E6 {RoundtripsMultiplication(1E6, 1E-6)} {RoundtripsMultiplicationDivision(1000000)} {RoundtripsDivision(1E6)} {Pow(6)}");
            Console.WriteLine($"1E-3 {RoundtripsMultiplication(1E-3, 1E3)} {RoundtripsDivisionMultiplication(1000)} {RoundtripsDivision(1E-3)} {Pow(-3)}");
            Console.WriteLine($"1E-6 {RoundtripsMultiplication(1E-6, 1E6)} {RoundtripsDivisionMultiplication(1000000)} {RoundtripsDivision(1E-6)} {Pow(-6)}");
        }

        private static bool RoundtripsMultiplication(double f1, double f2)
        {
            for (int i = 0; i < 100; i++)
            {
                var temp = f1 * i;
                var rt = f2 * temp;
                if (i != rt)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool RoundtripsDivision(double f1)
        {
            for (int i = 0; i < 100; i++)
            {
                var temp = f1 * i;
                var rt = temp / f1;
                if (i != rt)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool RoundtripsMultiplicationDivision(int f)
        {
            for (double i = 0; i < 100; i++)
            {
                var temp = f * i;
                var rt = temp / f;
                if (i != rt)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool RoundtripsDivisionMultiplication(int f)
        {
            for (double i = 0; i < 100; i++)
            {
                var temp = i / f;
                var rt = f * temp;
                if (i != rt)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Pow(int pow)
        {
            for (double i = 0; i < 100; i++)
            {
                var temp = Math.Pow(i, pow);
                var rt = Math.Pow(temp, -pow);
                if (i != rt)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
