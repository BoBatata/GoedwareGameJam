using UnityEngine;

public class IdleState : State
{
    public IdleState(BaseAI _entity) : base(_entity) { }

    public override void Enter()
    {
        _entity._agent.ResetPath(); // Para quaisquer movimentos
    }

    public override void Update()
    {
        if (_entity._bef.isInfected && _entity._bef.isInfectedHuntTime)
        {
            if (_entity._bef.isPlayerInSight)
            {
                _entity._stateMachine.ChangeState(new ChasePlayer(_entity));
            }
            else if (!_entity._bef.isPlayerInSight)
            {
                _entity._stateMachine.ChangeState(new WanderToPlayerRoom(_entity));
            }
            return;
        }
        
        _entity._stateMachine.ChangeState(new WanderToRoomState(_entity));
        
        
    }
}
