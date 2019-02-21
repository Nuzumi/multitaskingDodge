using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethodes
{
    public static T GetRandom<T>(this List<T> list, System.Random random)
    {
        int randomIndex = random.Next(list.Count);
        T result = list[randomIndex];
        list.RemoveAt(randomIndex);
        return result;
    }

    public static void Range(this List<int> list, int to)
    {
        for(int i =0; i < to; i++)
        {
            list.Add(i);
        }
    }
}
