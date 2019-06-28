using System;
using System.Collections.Generic;

public class NutritionInformation
{
    public int[] Protein;
    public int[] Carbs;
    public int[] Fat;
    public int[] Calories;
   

    public NutritionInformation(int[] protein, int[] carbs, int[] fat)
    {
        Protein = protein;
        Carbs = carbs;
        Fat = fat;
        Calories = GetCalories();
    }
    public int[] GetCalories()
    {
        int[] calories = new int[Protein.Length];
        for (int i = 0; i < Protein.Length; i++)
            calories[i] = Carbs[i] * 5 + Protein[i] * 5 + Fat[i] * 9;
        return calories;
    }
    public int GetSuitableDietIndexForPerson(string diet)
    { 
        int max = 0, min = 0;
        if (diet.Length == 0)
            return 0;
        List<int> listone = new List<int>();
        List<int> listtwo = new List<int>();
        for (int j = 0; j < Protein.Length; j++)//initializing listone
            listone.Add(j);
        for (int x = 0; x < diet.Length; x++)
        {

            switch (diet[x])
            {
                case 'P':
                    max = GetMaximum(listone, Protein);
                    UpdateList(listone, listtwo, max, Protein);
                    break;

                case 'C':
                    max = GetMaximum(listone, Carbs);
                    UpdateList(listone, listtwo, max, Carbs);
                    break;

                case 'F':
                    max = GetMaximum(listone, Fat);
                    UpdateList(listone, listtwo, max, Fat);
                    break;

                case 'T':
                    max = GetMaximum(listone, Calories);
                    UpdateList(listone, listtwo, max, Calories);
                    break;

                case 'p':
                    min = GetMinimum(listone, Protein);
                    UpdateList(listone, listtwo, min, Protein);
                    break;

                case 'c':
                    min = GetMinimum(listone, Carbs);
                    UpdateList(listone, listtwo, min, Carbs);
                    break;

                case 'f':
                    min = GetMinimum(listone, Fat);
                    UpdateList(listone, listtwo, min, Fat);
                    break;

                case 't':
                    min = GetMinimum(listone, Calories);
                    UpdateList(listone, listtwo, min, Calories);
                    break;
            }
            listone = listtwo;
            listtwo = new List<int>();
            if (listone.Count == 1)
                return listone[0];
        }
        return 0;
    }
        private int GetMaximum(List<int> list, int[] nutritionProperty)
        {
            int max = int.MinValue;
            foreach (int k in list)
                max = Math.Max(max, nutritionProperty[k]);
            return max;

        }
        private int GetMinimum(List<int> list, int[] nutritionProperty)
        {
            int min = int.MaxValue;
            foreach (int k in list)
                min = Math.Min(min, nutritionProperty[k]);
            return min;

        }
    private  void UpdateList(List<int> oldList, List<int> updatedList, int number, int[] property)
    {

        foreach (int k in oldList)
            if (number == property[k])
                updatedList.Add(k);
    }

}

