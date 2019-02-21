using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoint : MonoBehaviour
{
    [SerializeField]
    private NativeEvent addPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dot"))
        {
            addPoint.Invoke();
        }
    }

}
