using UnityEngine;

public class WanderInRoom : State
{
    private float waitTime = 2f;
    private float timer = 0;
    
    public WanderInRoom(BaseAI _entity) : base(_entity) { }


    public override void Enter()
    {
        Vector3 target = _entity._bef.currentRoom.GetRandomPointInRoom();
        _entity._agent.SetDestination(target);
    }

    public override void Update()
    {
        if (_entity._bef.isPlayerInSight && _entity.canChasePlayer && _entity._bef.isInfected && _entity._bef.isInfectedHuntTime)
        {
            _entity._stateMachine.ChangeState(new ChasePlayer(_entity));
            return;
        }
        
        _entity._stateMachine.ChangeState(new IdleState(_entity));
    }
}
