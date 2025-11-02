using UnityEngine;

public class WanderToRoomState : State
{
    private Room targetRoom;
    
    public WanderToRoomState(BaseAI _entity) : base(_entity) { }

    public override void Enter()
    {
        targetRoom = GameManager.Instance.aiManager.GetRandomRoom();
        _entity._agent.SetDestination(targetRoom.transform.position);
    }

    public override void Update()
    {
        if (!_entity._agent.pathPending && _entity._agent.remainingDistance < 0.5f)
        {
             _entity._bef.currentRoom = targetRoom;
             _entity._stateMachine.ChangeState(new WanderInRoom(_entity));
        }
    }
}
