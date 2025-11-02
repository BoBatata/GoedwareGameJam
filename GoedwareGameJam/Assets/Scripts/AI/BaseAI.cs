using UnityEngine;
using UnityEngine.AI;

public class BaseAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private StateMachine _stateMachine;
    private Beliefs _bef;

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine();
        _bef = new Beliefs();
    }
}
