using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class State : ScriptableObject
{
    public Activity[] activities;
    public Transition[] transitions;

    public void UpdateState(StateController controller)
    {
        DoActivities(controller);
        CheckTransitions(controller);
    }
    void DoActivities(StateController controller)
    {
        foreach ( Activity activity in activities)        
        {
            activity.Act(controller);
        }
    }

    void CheckTransitions(StateController controller)
    {
        foreach (Transition transition in transitions)
        {
            bool decision = transition.decision.Decide(controller);
            State targetState = decision ? transition.trueState : transition.falseState;
            controller.TransitionToState(targetState);
        }
    }
}
