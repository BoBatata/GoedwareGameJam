using UnityEngine;

public class ChasePlayer : State
{
    public ChasePlayer(BaseAI _entity) : base(_entity) { }
    
    private float updateInterval = 0.25f;
    private float updateTimer = 0f;

    public override void Enter()
    {
        if (!_entity.canChasePlayer)
        {
            _entity._stateMachine.ChangeState(new IdleState(_entity));
            return;
        }

        if (_entity._bef.player != null)
            _entity._agent.SetDestination(_entity._bef.player.position);
    }

    public override void Update()
    {
        if (_entity._bef.player == null)
        {
            _entity._stateMachine.ChangeState(new IdleState(_entity));
            return;
        }
        
        updateTimer += Time.deltaTime;
        if (updateTimer >= updateInterval)
        {
            _entity._agent.SetDestination(_entity._bef.player.position);
            updateTimer = 0f;
        }
        
        if (!_entity._agent.pathPending && _entity._agent.remainingDistance < 0.5f)
        {
            float playerDistance = Vector3.Distance(_entity._agent.transform.position, _entity._bef.player.position);

            if (playerDistance < 0.7f)
            {
                GameManager.Instance.uiManager.EndPanel(true, "The parasite got you...");
                GameManager.Instance.EndGame();
            }
            else
            {
                _entity._stateMachine.ChangeState(new WanderToPlayerRoom(_entity));
            }
            return;
        }
        
        if (!_entity._bef.isPlayerInSight || !_entity._bef.isInfected || !_entity._bef.isInfectedHuntTime)
        {
            _entity._stateMachine.ChangeState(new IdleState(_entity));
            return;
        }
    }
}
