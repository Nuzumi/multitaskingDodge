using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallPolling : MonoBehaviour {

    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    private GameObjectEvent wallEvent;
    [SerializeField]
    private TimerDataEvent timerEvent;

    private Queue<GameObject> walls;
    private WallSpeedController wallSpeedController;

    private void OnEnable()
    {
        wallEvent.AddListener(EnqueueWall);
    }

    private void OnDisable()
    {
        wallEvent.RemoveListener(EnqueueWall);
    }

    private void Start()
    {
        walls = new Queue<GameObject>();
        wallSpeedController = new WallSpeedController(timerEvent);
    }

    private void EnqueueWall(GameObject wall)
    {
        if (wall.CompareTag("Wall") && (walls.Count == 0 || wall.GetInstanceID() != walls.Last().GetInstanceID()))
        {
            wall.GetComponentInChildren<Wall>().SetAllActive();
            wall.SetActive(false);
            walls.Enqueue(wall);
        }
    }

    public GameObject GetWall()
    {
       if(walls.Count > 0)
        {
            var wall = walls.Dequeue();
            wall.SetActive(true);
            return wall;
        }
        else
        {
            var wall = Instantiate(wallPrefab);
            wall.GetComponent<WallMovement>().WallSpeedController = wallSpeedController;
            return wall;
        }
    }
}
