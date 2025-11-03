using System;
using UnityEngine;

public class NPCController : BaseAI
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite parasiteSprite;
    
    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        _stateMachine.ChangeState(new IdleState(this));
    }

    protected override void Update()
    {
        base.Update();

        if (_bef.isInfected && _bef.isInfectedHuntTime)
        {
            _spriteRenderer.sprite = parasiteSprite;
        }
        else
        {
            _spriteRenderer.sprite = normalSprite;
        }
    }
}
