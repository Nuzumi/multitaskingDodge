using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {

    [SerializeField]
    private GameObjectEvent wallEvent;

    public WallSpeedController WallSpeedController { get; set; }
    public Vector2 Direction { get; set; }


    private void FixedUpdate()
    {
        if(WallSpeedController != null)
            transform.Translate(Direction * WallSpeedController.SpeedModifier * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallEnd"))
        {
            wallEvent.Invoke(gameObject);
        }
    }

}
