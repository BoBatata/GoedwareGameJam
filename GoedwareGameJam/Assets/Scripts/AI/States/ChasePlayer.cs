using UnityEngine;

public class ChasePlayer : State
{
    public ChasePlayer(BaseAI _entity) : base(_entity) { }

    public override void Enter()
    {
        _entity._agent.SetDestination(_entity._bef.player.transform.position);
    }

    public override void Update()
    {
        if (_entity._agent.remainingDistance < 0.5f)
        {
            Debug.Log("Perdeu");
        }
    }
}
