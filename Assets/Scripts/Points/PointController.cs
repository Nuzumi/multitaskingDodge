using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;
    [SerializeField]
    private NativeEvent addPoints;

    private int points = 0;

    private void OnEnable()
    {
        addPoints.AddListener(AddPoint);
    }

    private void OnDisable()
    {
        addPoints.RemoveListener(AddPoint);
    }

    private void Start()
    {
        DisplayPointsText();
    }

    private void AddPoint()
    {
        points++;
        DisplayPointsText();
    }

    private void DisplayPointsText()
    {
        pointsText.text = points.ToString();
    }



}
