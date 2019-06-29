using System;
using System.Collections.Generic;
using System.Linq;

public class NutritionInformation
{
    public int[] Protein;
    public int[] Carbs;
    public int[] Fat;
    public int[] Calories;
    public const int CaloriesPerGramOfCarbs = 5;
    public const int CaloriesPerGramOfProtein = 5;
    public const int CaloriesPerGramOfFat = 9;
    public const char LessProtein = 'p';
    public const char MoreProtein = 'P';
    public const char LessCarbs = 'c';
    public const char MoreCarbs = 'C';
    public const char LessFat = 'f';
    public const char MoreFat = 'F';
    public const char LessCalories = 't';
    public const char MoreCalories = 'T';



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
 calories[i] = Carbs[i] * CaloriesPerGramOfCarbs + Protein[i] * CaloriesPerGramOfProtein + Fat[i] * CaloriesPerGramOfFat;
        return calories;
    }
    public int GetSuitableDietIndexForPerson(string diet)
    { 
        int max = 0, min = 0;
        if (diet.Length == 0)
            return 0;
        List<int> listOne = new List<int>();//listOne maintains the current indices of optimum nutrition values

        List<int> listTwo = new List<int>();/*listTwo maintains the updated indices of listone 
                                            if listone contains more than one optimum value*/

        for (int j = 0; j < Protein.Length; j++)//initializing listone
            listOne.Add(j);
        for (int x = 0; x < diet.Length; x++)
        {
            

            switch (diet[x])
            {
                case MoreProtein:
                    max = GetMaximum(listOne, Protein);
                    UpdateList(listOne, listTwo, max, Protein);
                    break;

                case MoreCarbs:
                    max = GetMaximum(listOne, Carbs);
                    UpdateList(listOne, listTwo, max, Carbs);
                    break;

                case MoreFat:
                    max = GetMaximum(listOne, Fat);
                    UpdateList(listOne, listTwo, max, Fat);
                    break;

                case MoreCalories:
                    max = GetMaximum(listOne, Calories);
                    UpdateList(listOne, listTwo, max, Calories);
                    break;

                case LessProtein:
                    min = GetMinimum(listOne, Protein);
                    UpdateList(listOne, listTwo, min, Protein);
                    break;

                case LessCarbs:
                    min = GetMinimum(listOne, Carbs);
                    UpdateList(listOne, listTwo, min, Carbs);
                    break;

                case LessFat:
                    min = GetMinimum(listOne, Fat);
                    UpdateList(listOne, listTwo, min, Fat);
                    break;

                case LessCalories:
                    min = GetMinimum(listOne, Calories);
                    UpdateList(listOne, listTwo, min, Calories);
                    break;
            }
            listOne = listTwo;
            listTwo = new List<int>();
            if (listOne.Count == 1)
                break;
        }
        return listOne[0];
    }
        private int GetMaximum(List<int> list, int[] nutritionProperty)
        {
        //returns maximum of nutritionproperty value of indices present in list
            int max = int.MinValue;
            foreach (int k in list)
                max = Math.Max(max, nutritionProperty[k]);
            return max;

        }
        private int GetMinimum(List<int> list, int[] nutritionProperty)
        {  
        //returns minimum of nutritionproperty value of indices present in list
            int min = int.MaxValue;
            foreach (int k in list)
                min = Math.Min(min, nutritionProperty[k]);
            return min;

        }
    private  void UpdateList(List<int> oldList, List<int> updatedList, int optimalNumber, int[] nutritionProperty)
    {

        foreach (int k in oldList)
            if (optimalNumber == nutritionProperty[k])
                updatedList.Add(k);
    }

}

