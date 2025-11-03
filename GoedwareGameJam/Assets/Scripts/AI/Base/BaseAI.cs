using UnityEngine;
using UnityEngine.AI;

public class BaseAI : MonoBehaviour
{
    public NavMeshAgent _agent;
    public StateMachine _stateMachine;
    public Beliefs _bef;
    
    public bool canChasePlayer = false;

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine();
        _bef = new Beliefs();
    }
    
    protected virtual void Start()
    {
        _stateMachine.ChangeState(new IdleState(this));
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            _bef.player = playerObj.transform;
    }
    
    protected virtual void Update()
    {
        CheckPlayerOnSight();
        
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

    public void ForceChangeState(IdleState state)
    {
        _stateMachine.ChangeState(state);
    }
    
    public void CheckPlayerOnSight()
    {
        _bef.isPlayerInSight = false;

        if (_bef.player == null) return;
        
        RaycastHit hit;
        Vector3 offSet = new Vector3(0, .5f, 0);
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 direction = player.transform.position - _agent.transform.position;

        Debug.DrawRay(_agent.transform.position + offSet, direction + offSet, Color.blue);
        if (Physics.Raycast(_agent.transform.position + offSet, direction + offSet, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {
            if (hit.transform != null && hit.transform.CompareTag("Player"))
            {
                _bef.isPlayerInSight = true;
                return;
            }
        }
        _bef.isPlayerInSight = false;
    }
}
