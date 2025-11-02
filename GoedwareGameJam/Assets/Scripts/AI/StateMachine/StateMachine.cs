using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State _currentState;


    public void ChangeState(State newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;

        if (_currentState != null)
            _currentState.Enter();
    }

    public void Update()
    {
        if (_currentState != null)
            _currentState.Update();
    }

}
