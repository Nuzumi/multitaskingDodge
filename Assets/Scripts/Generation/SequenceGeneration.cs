using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SequenceElement {Top, Down, Both };

public class SequenceGeneration {

    public string Seed { get; set; }
    private System.Random random;
    private int[] elementValues;

    public SequenceGeneration()
    {
        Seed = DateTime.Now.ToString();
        random = new System.Random(Seed.GetHashCode());
        InitSequenceValues();
    }

    public SequenceGeneration(string seed)
    {
        Seed = seed;
        random = new System.Random(seed.GetHashCode());
        InitSequenceValues();
    }

    public SequenceElement GetNextSequenceElement()
    {
        float randomValue = random.Next(elementValues.Sum());
        int tmpValue = 0;
        for(int i =0; i< elementValues.Length; i++)
        {
            tmpValue += elementValues[i];
            if(randomValue < tmpValue)
            {
                ValueIncreseAfterReturningSequenceElement(i);
                return (SequenceElement)i;
            }
        }

        return (SequenceElement)(int)random.Next(3);
    }

    private void ValueIncreseAfterReturningSequenceElement(int elementIndex)
    {
        for(int i = 0; i < elementValues.Length; i++)
        {
            if(i == elementIndex)
            {
                elementValues[i] = 1;
            }
            else
            {
                elementValues[i]++;
            }
        }
    }

    private void InitSequenceValues()
    {
        elementValues = new int[3];
        for (int i = 0; i< elementValues.Length; i++)
        {
            elementValues[i] = 1;
        }
    }
}
