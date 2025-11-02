using UnityEngine;
using UnityEngine.AI;

public class BaseAI : MonoBehaviour
{
    public NavMeshAgent _agent;
    public StateMachine _stateMachine;
    public Beliefs _bef;

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine();
        _bef = new Beliefs();
    }
    
    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            _bef.player = playerObj.transform;
    }
    
    protected virtual void Update()
    {
        if (!_bef.isInteracting)
        {
            _agent.isStopped = false;
            _stateMachine.Update();
        }
        else
        {
            _agent.isStopped = true;
        }
    }

}
