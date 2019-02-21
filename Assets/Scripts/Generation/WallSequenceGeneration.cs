using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSequenceGeneration
{
    public string Seed { get; set; }

    private System.Random random;

    public WallSequenceGeneration()
    {
        Seed = DateTime.Now.ToString();
        random = new System.Random(Seed.GetHashCode());
    }

    public WallSequenceGeneration(string seed)
    {
        Seed = seed;
        random = new System.Random(seed.GetHashCode());
    }

    public IEnumerator GenerateWallSequenece(Wall wall)
    {
        yield return new WaitForEndOfFrame();
        int wallPartsCount = wall.WallParts.Length;
        int wallPartsToDisableCount = random.Next(1, wallPartsCount - 1);
        List<int> posibleIndexes = new List<int>();
        posibleIndexes.Range(wallPartsCount);

        for (int i = 0; i < wallPartsToDisableCount; i++)
        {
            wall.SetActiveWallPart(posibleIndexes.GetRandom(random));
        }
    }

    public IEnumerator GenerateWallSequenece(Wall wallTop, Wall wallBottom)
    {
        yield return new WaitForEndOfFrame();
        int wallPartsCount = wallTop.WallParts.Length;
        int wallPartsToDisableCount = random.Next(1, wallPartsCount - 1);
        List<int> posbleIndexes = new List<int>();
        posbleIndexes.Range(wallPartsCount);
        List<int> choosenIndexes = new List<int>();

        for(int i = 0; i < wallPartsToDisableCount; i++)
        {
            choosenIndexes.Add(posbleIndexes.GetRandom(random));
        }
        
        int sharedIndexesCount = random.Next(1, wallPartsToDisableCount);

        for(int i =0; i < sharedIndexesCount; i++)
        {
            int sharedIndex = choosenIndexes.GetRandom(random);
            wallTop.SetActiveWallPart(sharedIndex);
            wallBottom.SetActiveWallPart(wallPartsCount - (1 + sharedIndex));
        }

        for(int i = 0; i < choosenIndexes.Count; i++)
        {
            int randomWall = random.Next(2);
            if(randomWall == 0)
            {
                wallTop.SetActiveWallPart(choosenIndexes[i]);
            }
            else
            {
                wallBottom.SetActiveWallPart(wallPartsCount - (1 + choosenIndexes[i]));
            }
        }
    }
}
