using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        DecideMovement();
        return true;
    }

    private void DecideMovement()
    {
        
    }
}
