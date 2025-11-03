using UnityEngine;

public class IdleState : State
{
    public IdleState(BaseAI _entity) : base(_entity) { }
    
    public override void Enter()
    {
        _entity._agent.ResetPath();
    }

    public override void Update()
    {
        if (_entity._bef.isPlayerInSight && _entity.canChasePlayer && GameManager.Instance.player.canBeInSight)
        {
            _entity._stateMachine.ChangeState(new ChasePlayer(_entity));
            return;
        }

        if (_entity._bef.isInfected && _entity._bef.isInfectedHuntTime)
        {
            _entity._stateMachine.ChangeState(new WanderToPlayerRoom(_entity));
        }
        else
        {
            _entity._stateMachine.ChangeState(new WanderToRoomState(_entity));
        }
        
    }
}
