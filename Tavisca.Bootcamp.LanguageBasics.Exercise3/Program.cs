using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {

            //throw new NotImplementedException();
            int[] result = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
                calories[i] = carbs[i] * 5 + protein[i] * 5 + fat[i] * 9;
            List<int> listone;
            List<int> listtwo;


            int max = -1, min = 100000;

            for (int i = 0; i < dietPlans.Length; i++)
            {
                string s = dietPlans[i];
                if (s.Length == 0)
                    continue;
                listone = new List<int>();
                listtwo = new List<int>();
                for (int j = 0; j < protein.Length; j++)
                    listone.Add(j);
                for (int x = 0; x < s.Length; x++)
                {
                    max = -1;
                    min = 100000;
                    switch (s[x])
                    {
                        case 'P':

                            foreach (int k in listone)
                                max = Math.Max(max, protein[k]);
                            foreach (int k in listone)
                                if (max == protein[k])
                                    listtwo.Add(k);
                            break;

                        case 'C':

                            foreach (int k in listone)
                                max = Math.Max(max, carbs[k]);
                            foreach (int k in listone)
                                if (max == carbs[k])
                                    listtwo.Add(k);
                            break;
                        case 'F':

                            foreach (int k in listone)
                                max = Math.Max(max, fat[k]);
                            foreach (int k in listone)
                                if (max == fat[k])
                                    listtwo.Add(k);
                            break;
                        case 'T':

                            foreach (int k in listone)
                                max = Math.Max(max, calories[k]);
                            foreach (int k in listone)
                                if (max == calories[k])
                                    listtwo.Add(k);
                            break;
                        case 'p':

                            foreach (int k in listone)
                                min = Math.Min(min, protein[k]);
                            foreach (int k in listone)
                                if (min == protein[k])
                                    listtwo.Add(k);
                            break;
                        case 'c':

                            foreach (int k in listone)
                                min = Math.Min(min, carbs[k]);
                            foreach (int k in listone)
                                if (min == carbs[k])
                                    listtwo.Add(k);
                            break;
                        case 'f':

                            foreach (int k in listone)
                                min = Math.Min(min, fat[k]);
                            foreach (int k in listone)
                                if (min == fat[k])
                                    listtwo.Add(k);
                            break;
                        case 't':

                            foreach (int k in listone)
                                min = Math.Min(min, calories[k]);
                            foreach (int k in listone)
                                if (min == calories[k])
                                    listtwo.Add(k);
                            break;
                    }
                    listone = listtwo;
                    listtwo = new List<int>();
                    if (listone.Count == 1)
                        break;
                }

                result[i] = listone[0];


            }

            return result;

        }
    }
}
