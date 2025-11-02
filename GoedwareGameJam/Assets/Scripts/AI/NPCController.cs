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
        _stateMachine.ChangeState(new WanderInRoom(this));

        // // Se começar já dentro de um cômodo
        // if (startInRandomRoom)
        // {
        //     blackboard.currentRoom = RoomManager.Instance.GetRandomRoom();
        //     if (blackboard.currentRoom != null)
        //         transform.position = blackboard.currentRoom.GetRandomPointInside();
        // }
    }
    
    protected override void Update()
    {
        base.Update();
        
        if (_bef.isInfected)
        {
            if (CheckPlayerOnSight())
            {
                _stateMachine.ChangeState(new ChasePlayer(this));
            }
            else if (!CheckPlayerOnSight())
            {
                _stateMachine.ChangeState(new WanderToPlayerRoom(this));
            }
        }
    }

    public bool CheckPlayerOnSight()
    {
        RaycastHit hit;
        Vector3 offSet = new Vector3(0, .5f, 0);
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;

        Debug.DrawRay(this.transform.position + offSet, direction + offSet, Color.blue);
        if (Physics.Raycast(transform.position + offSet, direction + offSet, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag != player.tag)
            {
                return false;
            }
        }
        return true;
    }
}
