using UnityEngine;

public class WanderToRoomState : State
{
    private Room targetRoom;
    
    public WanderToRoomState(BaseAI _entity) : base(_entity) { }

    public override void Enter()
    {
        targetRoom = GameManager.Instance.aiManager.GetRandomRoom();
        if (targetRoom == null)
        {
            _entity._stateMachine.ChangeState(new IdleState(_entity));
            return;
        }
        _entity._agent.SetDestination(targetRoom.transform.position);
    }

    public override void Update()
    {
        if (_entity._bef.isPlayerInSight && _entity.canChasePlayer && GameManager.Instance.player.canBeInSight)
        {
            _entity._stateMachine.ChangeState(new ChasePlayer(_entity));
            return;
        }

        if (!_entity._agent.pathPending && _entity._agent.remainingDistance < 0.5f)
        {
            _entity._bef.currentRoom = targetRoom;
            _entity._stateMachine.ChangeState(new WanderInRoom(_entity));
        }
    }
}
