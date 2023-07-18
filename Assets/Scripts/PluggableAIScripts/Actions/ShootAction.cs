using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShootAction : Activity
{
    public override void Act(StateController controller)
    {
        Debug.Log("pew pew");
    }
}
