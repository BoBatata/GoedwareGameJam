using UnityEngine;

public class IdleState : State
{
    public IdleState(BaseAI _entity) : base(_entity) { }
    
    private float idleDuration;
    private float timer;

    public override void Enter()
    {
        _entity._agent.ResetPath();
        idleDuration = Random.Range(2f, 5f);
        timer = 0f;
    }

    public override void Update()
    {
        if (_entity.canChasePlayer && _entity._bef.isInfected && _entity._bef.isInfectedHuntTime && _entity._bef.isPlayerInSight && GameManager.Instance.player.canBeInSight)
        {
            _entity._stateMachine.ChangeState(new ChasePlayer(_entity));
            return;
        }
        
        if (_entity._bef.isInfected && _entity._bef.isInfectedHuntTime && !_entity._bef.isPlayerInSight)
        {
            Room playerRoom = GameManager.Instance.aiManager.playerClosestRoom;
            if (playerRoom != null)
            {
                _entity._stateMachine.ChangeState(new WanderToPlayerRoom(_entity));
                return;
            }
        }
        
        timer += Time.deltaTime;
        if (timer >= idleDuration)
        {
            _entity._stateMachine.ChangeState(new WanderToRoomState(_entity));
            return;
        }
    }
}
