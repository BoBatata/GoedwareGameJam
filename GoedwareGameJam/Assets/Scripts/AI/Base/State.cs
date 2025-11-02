public abstract class State
{
    protected BaseAI _entity;

    public State(BaseAI _entity)
    {
        this._entity = _entity;
    }

    public virtual void Enter() { }
    public virtual void Update() { }

    public virtual void Exit()
    {
        _entity._agent.ResetPath();
    }
}
