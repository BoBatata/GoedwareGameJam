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
        Debug.Log("Está infectado: "+_bef.isInfected + "; Está na hora da putaria?: " +_bef.isInfectedHuntTime);
        
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
    
    public bool CheckPlayerOnSight()
    {
        RaycastHit hit;
        Vector3 offSet = new Vector3(0, .5f, 0);
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 direction = player.transform.position - _agent.transform.position;

        Debug.DrawRay(_agent.transform.position + offSet, direction + offSet, Color.blue);
        if (Physics.Raycast(_agent.transform.position + offSet, direction + offSet, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag != player.tag || !GameManager.Instance.player.canBeInSight)
            {
                return false;
            }
        }
        return true;
    }
}
