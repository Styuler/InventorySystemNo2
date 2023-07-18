using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimerDecision : Decision
{
    public float timerThreshold;
    
    public override bool Decide(StateController controller)
    {
        return controller.currentTimer >= timerThreshold;
    }
}
