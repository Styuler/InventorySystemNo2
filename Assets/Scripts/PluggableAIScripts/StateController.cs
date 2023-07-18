using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State initialState;
    private State currentState;
    [HideInInspector] public float currentTimer;

    private void Start()
    {
        currentState = initialState;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(State targetState)
    {
        if (targetState == null || targetState == currentState) return;

        currentTimer = 0;
        currentState = targetState;
    }
}
