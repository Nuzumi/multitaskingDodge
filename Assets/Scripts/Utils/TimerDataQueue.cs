using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDataQueue
{
    private List<TimerData> queue;

    public TimerDataQueue()
    {
        queue = new List<TimerData>();
    }

    public void Enqueue(TimerData timerData)
    {
        if(queue.Count == 0)
        {
            queue.Add(timerData);
            return;
        }

        for(int i = 0; i < queue.Count; i++)
        {
            if(queue[i].alarmTime > timerData.alarmTime)
            {
                queue.Insert(i, timerData);
                return;
            }
        }

        queue.Add(timerData);
    }

    public TimerData? Dequeue()
    {
        if(queue.Count > 0)
        {
            var result = queue[0];
            queue.RemoveAt(0);
            return result;
        }

        return null;
    }

    public TimerData? LookUp()
    {
        if(queue.Count > 0)
        {
            return queue[0];
        }

        return null;
    }
}
