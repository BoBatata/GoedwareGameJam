using UnityEngine;

public class NPCController : BaseAI
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        
        // Define o estado inicial
        _stateMachine.ChangeState(new IdleState(this));

        // // Se começar já dentro de um cômodo
        // if (startInRandomRoom)
        // {
        //     blackboard.currentRoom = RoomManager.Instance.GetRandomRoom();
        //     if (blackboard.currentRoom != null)
        //         transform.position = blackboard.currentRoom.GetRandomPointInside();
        // }
    }
}
