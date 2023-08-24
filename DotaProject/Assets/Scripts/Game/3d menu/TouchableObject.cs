using UnityEngine;

public abstract class TouchableObject : MonoBehaviour
{
    protected StateMachine stateMachine;

    protected void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.Initialize(new IdleState());
    }

    protected void ChangeState(State newState)
    {
        stateMachine.ChangeState(newState);
    }
}
