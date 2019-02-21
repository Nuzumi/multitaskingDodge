using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpeedController {

    public float SpeedModifier { get; set; }

    private TimerDataEvent timerEvent;
    private float speedUpOffset = 2.5f;

    public WallSpeedController(TimerDataEvent timerDataEvent)
    {
        timerEvent = timerDataEvent;
        SpeedModifier = 2.5f;
        timerEvent.Invoke(new TimerData(Time.timeSinceLevelLoad, SpeedUp, null));
    }

    private void SpeedUp()
    {

    }
}
