using UnityEngine;

public class RatfolkAxe : AEnemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        gameObject.transform.position = new Vector3(-3, 3.4f, 0);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void HandlerTakeDMG()
    {
        base.HandlerTakeDMG();
    }

    public override void DeathEvent()
    {
        base.DeathEvent();
    }
}
