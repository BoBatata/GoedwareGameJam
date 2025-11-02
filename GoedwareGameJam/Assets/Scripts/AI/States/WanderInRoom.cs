using UnityEngine;

public class WanderInRoom : State
{
    private float waitTime = 5f;
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
        if (_entity.CheckPlayerOnSight() && _entity._bef.isInfected && _entity._bef.isInfectedHuntTime)
        {
            _entity._stateMachine.ChangeState(new IdleState(_entity));
            return;
        }
        
        if (_entity._bef.currentRoom == null)
        {
            _entity._stateMachine.ChangeState(new WanderToRoomState(_entity));
            return;
        }

        timer += Time.deltaTime;

        if (!_entity._agent.pathPending && _entity._agent.remainingDistance < 0.5f)
        {
            if (timer >= waitTime)
            {
                Vector3 target = _entity._bef.currentRoom.GetRandomPointInRoom();
                _entity._agent.SetDestination(target);
                timer = 0;
            }
        }
    }
}
