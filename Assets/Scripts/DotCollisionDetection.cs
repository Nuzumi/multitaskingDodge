using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DotEvents {Point, WallHit };

public class DotCollisionDetection : MonoBehaviour
{
    [SerializeField]
    private IntEvent dotEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallObstacle"))
        {
            dotEvent.Invoke((int)DotEvents.WallHit);
        }
        else
        {
            if (collision.CompareTag("WallPoint"))
            {
                dotEvent.Invoke((int)DotEvents.Point);
            }
        }
    }
}
