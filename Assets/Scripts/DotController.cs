using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour {

    [SerializeField]
    private bool inverse;
    [SerializeField]
    private IntEvent positionInput;
    [SerializeField]
    private float minPositionX;
    [SerializeField]
    private float maxPositionX;

    private float moveDistance;

    private void OnEnable()
    {
        positionInput.AddListener(SetPosition);
    }

    private void OnDisable()
    {
        positionInput.RemoveListener(SetPosition);
    }

    private void Start()
    {
        moveDistance = maxPositionX - minPositionX;
    }

    private void SetPosition(int percentage)
    {
        float offset = moveDistance * percentage / 100;
        if(inverse)
            transform.position = new Vector3(maxPositionX - offset, transform.position.y);
        else
            transform.position = new Vector3(minPositionX + offset, transform.position.y);
    }

}
