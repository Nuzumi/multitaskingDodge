using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public GameObject[] WallParts { get; set; }

    private void Start()
    {
        WallParts = new GameObject[transform.childCount];
        for (int i = 0; i < WallParts.Length; i++)
        {
            WallParts[i] = transform.GetChild(i).gameObject;
        }
    }

    public void SetActiveWallPart(int index, bool value = false)
    {
        WallParts[index].SetActive(value);
    }

    public void SetAllActive()
    {
        for (int i = 0; i < WallParts.Length; i++)
        {
            SetActiveWallPart(i, true);
        }
    }
}
