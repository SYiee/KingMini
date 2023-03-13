using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State {Nomal,Skinny};
    internal State state = State.Nomal;
    

    public void StateChange(State presentState)
    {
        state = presentState;
    }

    private void Update()
    {
        //print(state);
    }
}
