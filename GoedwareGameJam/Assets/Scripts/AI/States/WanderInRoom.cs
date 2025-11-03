using UnityEngine;

public class WanderInRoom : State
{
    private float waitTime = 2f;
    private float timer = 0;
    
    public WanderInRoom(BaseAI _entity) : base(_entity) { }


    public override void Enter()
    {
        timer = 0;
        if (_entity._bef.currentRoom == null)
        {
            _entity._stateMachine.ChangeState(new WanderToRoomState(_entity));
            return;
        }
        
        Vector3 target = _entity._bef.currentRoom.GetRandomPointInRoom();
        _entity._agent.SetDestination(target);
    }

    public override void Update()
    {
        if (_entity.canChasePlayer && _entity._bef.isInfected && _entity._bef.isInfectedHuntTime && _entity._bef.isPlayerInSight && GameManager.Instance.player.canBeInSight)
        {
            _entity._stateMachine.ChangeState(new ChasePlayer(_entity));
            return;
        }
        
        if (_entity._bef.currentRoom == null)
        {
            _entity._stateMachine.ChangeState(new WanderToRoomState(_entity));
            return;
        }
        

        if (!_entity._agent.pathPending && _entity._agent.remainingDistance < 0.5f)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                Vector3 newTarget = _entity._bef.currentRoom.GetRandomPointInRoom();
                _entity._agent.SetDestination(newTarget);
                timer = 0f;
            }
        }
    }
}
