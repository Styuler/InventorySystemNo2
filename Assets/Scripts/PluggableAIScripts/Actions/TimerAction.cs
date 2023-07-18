using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimerAction : Activity
{
    public override void Act(StateController controller)
    {
        controller.currentTimer += Time.deltaTime;
    }
}
