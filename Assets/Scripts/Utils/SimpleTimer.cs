using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField]
    private TimerDataEvent addTimer;

    private TimerDataQueue queue;

    private void OnEnable()
    {
        addTimer.AddListener(AddTimer);
    }

    private void OnDisable()
    {
        addTimer.RemoveListener(AddTimer);
    }

    private void Start()
    {
        queue = new TimerDataQueue();
    }

    private void Update()
    {
        TimerData? timer = queue.LookUp();
        if(timer != null && timer.Value.alarmTime < Time.timeSinceLevelLoad)
        {
            queue.Dequeue();
            timer.Value.action.Invoke();
        }
    }

    private void AddTimer(TimerData timerData)
    {
        queue.Enqueue(timerData);
    }
}

public struct TimerData
{
    public float alarmTime;
    public Action action;
    public GameObject gameObject;

    public TimerData(float alarmTime, Action action, GameObject gameObject)
    {
        this.alarmTime = alarmTime;
        this.action = action;
        this.gameObject = gameObject;
    }

}