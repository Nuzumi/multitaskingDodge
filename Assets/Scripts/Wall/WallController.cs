using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    [SerializeField]
    private WallPolling wallPolling;
    [SerializeField]
    private Transform positionTop;
    [SerializeField]
    private Transform positionBottom;
    [SerializeField]
    private TimerDataEvent addTimer;

    private SequenceGeneration sequenceGeneration;
    private WallSequenceGeneration wallSequenceGeneration;
    private System.Random random;
    private float minoffsetTime = 1.5f;
    private float maxOffsetTime = 2f;

    private void Start()
    {
        random = new System.Random();
        sequenceGeneration = new SequenceGeneration();
        wallSequenceGeneration = new WallSequenceGeneration();
        AddWallGenerationTimer();
    }

    private void AddWallGenerationTimer()
    {
        float timeOffset = (float)random.NextDouble() * (maxOffsetTime - minoffsetTime) + minoffsetTime;
        TimerData data = new TimerData(Time.timeSinceLevelLoad + timeOffset, GenerateNextWall, gameObject);
        addTimer.Invoke(data);
    }


    private void GenerateNextWall()
    {
       
        SequenceElement element = sequenceGeneration.GetNextSequenceElement();

        if(element == SequenceElement.Top)
        {
            GameObject wall = wallPolling.GetWall();
            StartCoroutine( wallSequenceGeneration.GenerateWallSequenece(wall.GetComponentInChildren<Wall>()));
            wall.transform.position = positionTop.position;
            WallMovement wallMovement = wall.GetComponent<WallMovement>();
            wallMovement.Direction = Vector2.down;
        }
        else
        {
            if(element == SequenceElement.Down)
            {
                GameObject wall = wallPolling.GetWall();
                StartCoroutine(wallSequenceGeneration.GenerateWallSequenece(wall.GetComponentInChildren<Wall>()));
                wall.transform.position = positionBottom.position;
                WallMovement wallMovement = wall.GetComponent<WallMovement>();
                wallMovement.Direction = Vector2.up;
            }
            else
            {
                GameObject wallTop = wallPolling.GetWall();
                GameObject wallBottom = wallPolling.GetWall();
                StartCoroutine(wallSequenceGeneration.GenerateWallSequenece(wallTop.GetComponentInChildren<Wall>(), wallBottom.GetComponentInChildren<Wall>()));

                wallTop.transform.position = positionTop.position;
                WallMovement wallTopMovement = wallTop.GetComponent<WallMovement>();
                wallTopMovement.Direction = Vector2.down;

                wallBottom.transform.position = positionBottom.position;
                WallMovement wallBottomMovement = wallBottom.GetComponent<WallMovement>();
                wallBottomMovement.Direction = Vector2.up;

            }
        }

        AddWallGenerationTimer();
    }


}
