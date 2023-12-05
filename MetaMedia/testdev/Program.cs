using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace testdev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Decode(Encode("WEAREDISCOVEREDFLEEATONCE", 4),4));

            int[][] array =
       {
           new []{1, 2, 3},
           new []{4, 5, 6},
           new []{7, 8, 9}
       };

            Console.WriteLine("value " + string.Join(" ", Snail(array).Select(a => a.ToString())));
        }

        public static int FlipBit(int value, int bitIndex) => value ^ (1 << (bitIndex - 1));
        public static string DatingRange(int age)
        {
            int min = age < 14 ? (int)(age - (0.10f * age)) : ((age / 2) + 7);
            int max = age < 14 ? (int)(age + (0.10f * age)) : ((age - 7) * 2);

            return $"{max}-{min}";
        }

        public static string TripleTrouble(string one, string two, string three)
        {
            string v = string.Join("", Enumerable.Range(0, one.Length).Select(i => $"{one[i]}{two[i]}{three[i]}"));

        }


        public static string PeopleWithAgeDrink(int old)
        {
            return "drink" + (old < 14 ? "toddy" : old < 18 ? "coke" : old < 21 ? "beer" : "whisky");
        }

        public static int Repeats(List<int> source) => source.Where(a => source.Count(x => a == x) > 1).Distinct().Sum();
        public static int Running(int n)
        {
            if (n % 2 == 0 || n % 5 == 0) return -1;

            int remainer = 1;
            HashSet<int> remainers = new HashSet<int>();
            int length = 0;

            while (!remainers.Contains(remainer))
            {
                remainers.Add(remainer);
                remainer = remainer * 10 % n;
                length++;
            }

            return length;
        }

        public static int HighestRank(int[] arr)
        {
            return arr.GroupBy(n => n).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).First().Key;

        }

        public static int GetLastDigit(BigInteger n1, BigInteger n2)
        {
            if (n1 == 0 && n2 == 0) return 1; // Cas spécial 0^0
            if (n2 == 0) return 1; // N'importe quel nombre à la puissance de 0 donne 1

            n1 = n1 % 10; // Nous sommes seulement intéressés par le dernier chiffre de n1

            // Le cycle de répétition pour les derniers chiffres ne dépasse jamais 4
            int reducedExponent = (int)(n2 % 4);
            if (reducedExponent == 0) reducedExponent = 4; // Si n2 est divisible par 4, nous utilisons 4 comme exposant

            return (int)BigInteger.ModPow(n1, reducedExponent, 10);
        }
        public static string[] dup(string[] arr)
        {
            string[] results = new string[arr.Length];

            int i = 0;
            foreach(string s in arr) 
            {
                results[i++] = stopDupString(s);
            }
            return results;
        }

        static string stopDupString(string s)
        {
            string result = s[0].ToString();
            char c = s[0];

            for(int i = 1; i <s.Length; i++)
            {
                if(c != s[i])
                {
                    result += s[i];
                }
                c = s[i];
            }
            return result;
        }

        public static int[] Snail(int[][] array)
        {
            if (array.Length == 0 || array[0].Length == 0)
            {
                return new int[0];
            }

            List<int> list = new List<int>();

            int rows = array.Length; int cols = array[0].Length;
            int sum = rows * cols;

            int row = 0; int col= 0; int layer = 0;

            while (list.Count < sum)
            {
                // Right
                for (; col < cols - layer; col++)
                {
                    list.Add(array[row][col]);
                }
                col--; row++;

                // Down
                for (; row < rows - layer; row++)
                {
                    list.Add(array[row][col]);
                }
                row--; col--;

                // Left
                for (; col >= layer; col--)
                {
                    list.Add(array[row][col]);
                }
                col++; row--; layer++;

                // Up
                for (; row >= layer; row--)
                {
                    list.Add(array[row][col]);
                }
                row++; col++;

            }
            return list.ToArray();
        }

        public static string WhatCentury(string year)
        {
            decimal yearInt = Math.Ceiling((decimal.Parse(year)/100));
            decimal firstnumber = yearInt % 10;
            decimal secondnumber = (int)(yearInt / 10);
            string centuryType = firstnumber == 1 && secondnumber != 1 ? "st" : firstnumber == 2 && secondnumber != 1 ? "nd" : firstnumber == 3 && secondnumber != 1 ? "rd" : "th";
            return $"{yearInt}{centuryType}";
        }

        public static string Encode(string s, int n)
        {
            if (n == 1) return s;

            string[] railArray = new string[n];
            int rail = 0;
            int change = 1;

            foreach (char c in s)
            {
                railArray[rail] += c;
                rail += change;

                if (rail == 0 || rail == n - 1)
                {
                    change = -change;
                }
            }

            return string.Join("", railArray);
        }

        public static string Decode(string s, int n)
        {
           if (n == 1) return s;

    char[] decoded = new char[s.Length];
    int indexn = 0;

    for (int k = 0; k < n; k++)
    {
        int index = k;
        bool down = true;
        
        while (index < s.Length)
        {
            decoded[index] = s[indexn++];
            
            if (k == 0 || k == n - 1)
            {
                index += (n - 1) * 2;
            }
            else if (down)
            {
                index += (n - k - 1) * 2;
                down = false;
            }
            else
            {
                index += k * 2;
                down = true;
            }
        }
    }

    return new string(decoded);
        }


        public static int[] SequenceEncode(int index)
        {
            if (index <= 1)
            {
                return new int[0];
            }

            // La longueur totale de la séquence est (index * 2 - 2)
            int[] s = new int[index * 2 - 2];

            // Remplir la première moitié du tableau (montée)
            for (int i = 0; i < index; i++)
            {
                s[i] = i;
            }

            // Remplir la seconde moitié du tableau (descente)
            for (int i = index, j = 1; i < s.Length; i++, j++)
            {
                s[i] = index - j - 1;
            }

            return s;
        }






        static int NbYear(int p0, double percent, int aug, int p)
        {
            int years = 0;
            double currentPopulation = p0;

            while (currentPopulation < p)
            {
                currentPopulation = Math.Floor(currentPopulation + currentPopulation * percent / 100 + aug);
                years++;
            }

            return years;
        }

        public static long digPow(int n, int p)
        {
            double[] nList = n.ToString().Select(a => double.Parse(a.ToString())).ToArray();

            double Sum = 0;

            for(double i = 0; i < nList.Count(); i++)
            {
               Sum += Math.Pow((int)nList[(int)i], i + p);
            }

            float division = (float)Sum / n;

            if(division == (long)division)
            {
                return (long)division;
            }

            return -1;
        }

        public static int MaxDiff(int[] lst) => (lst.Count() == 0) ? 0 : lst.Max() - lst.Min();


        public static double calculate(string s)
        {

            Console.WriteLine(s);
            string clearSpace = s.Replace(" ", "");

            List<string> bracketsOrder = new List<string>();

            int indexbrackets = 0;
            while (clearSpace.Contains('('))
            {
                Tuple<string, int, int> braketsZone = ManageBrackets(clearSpace);
                bracketsOrder.Add(braketsZone.Item1);

                clearSpace = ReplaceSubstring(clearSpace, braketsZone.Item2, braketsZone.Item3 + 1, "x" + indexbrackets.ToString() + "x");
                indexbrackets++;
                
            }

            bracketsOrder.Add(clearSpace);

            double sum = 0;

            for (int i = 0; i < indexbrackets +1; i++)
            {
                if (i != 0)
                {
                    string toRemove = "x" + (i - 1).ToString() + "x";
                    bracketsOrder[i] = bracketsOrder[i].Replace(toRemove, sum.ToString());
                }

                //Console.WriteLine(bracketsOrder[i]);

                sum = CalculPart(bracketsOrder[i]);
            }
            Console.WriteLine("Sum" + sum);
            return sum;
        }

        static Tuple<string, int, int> ManageBrackets(string input, int globalOffset = 0)
        {
            int startIndex = input.LastIndexOf('(');
            int endIndex = input.IndexOf(')', startIndex);

            if (startIndex == -1 || endIndex == -1)
            {
                return new Tuple<string, int, int>("", -1, -1);
            }

            string extractedString = input.Substring(startIndex + 1, endIndex - startIndex - 1);

            if (extractedString.Contains('(') || extractedString.Contains(')'))
            {
                return ManageBrackets(extractedString);
            }

            return new Tuple<string, int, int>(extractedString, startIndex, endIndex);
        }

        public static bool Validate_hello(string greetings)
        {

            string[] hello = { "hello", "ciao", "salut", "hallo", "hola", "ahoj", "czesc" };

            foreach(string h in hello)
            {
                if(greetings.ToLower().Contains(h)) return true;
            }

            return false;

        }

        static string ReplaceSubstring(string originalString, int startIndex, int endIndex, string replacement)
        {

            string beginning = originalString.Substring(0, startIndex);
            string ending = originalString.Substring(endIndex);

            return beginning + replacement + ending;
        }

        static double CalculPart(string v)
        {
            string vWithoutPower = RemoveElement(v, '^', (a, b) => Math.Pow(a,b));
            string vWithoutDivision = RemoveElement(vWithoutPower, '/', (a, b) => a/b);
            string vWithoutmultiplication = RemoveElement(vWithoutDivision, '*', (a, b) => a * b);
            string vWithoutaddiction = RemoveElement(vWithoutmultiplication, '+', (a, b) => a + b);
            string vWithoutSubstraction = RemoveElement(vWithoutaddiction, '-', (a, b) => a - b);

           
            return Convert.ToDouble(vWithoutSubstraction.Replace(".", ","));
        }

        private static string RemoveElement(string inp, char operation, Func<double, double, double> operationFunc)
        {
            if (!inp.Contains(operation)) return inp;

            string input = inp;
            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == operation)
                {
                    int leftStart = i, rightEnd = i;

                    // Étendre à gauche pour le nombre
                    while (leftStart > 0 && (char.IsDigit(input[leftStart - 1]) || input[leftStart - 1] == '.')) leftStart--;

                    // Étendre à droite pour le nombre
                    while (rightEnd < input.Length - 1 && (char.IsDigit(input[rightEnd + 1]) || input[rightEnd + 1] == '.')) rightEnd++;

                    double left = Convert.ToDouble(input.Substring(leftStart, i - leftStart).ToString().Replace(".", ","));
                    double right = Convert.ToDouble(input.Substring(i + 1, rightEnd - i).ToString().Replace(".", ","));

                    double result = operationFunc(left, right);
                    string newinput = input.Substring(0, leftStart) + result + input.Substring(rightEnd + 1);

                    input = newinput;
                    i = leftStart + result.ToString().Length;
                }
                else
                {
                    i++;
                }
            }
            return input;
        }




    }
}