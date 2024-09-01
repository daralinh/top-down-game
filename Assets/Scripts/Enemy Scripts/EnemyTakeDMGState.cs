public class EnemyTakeDMGState : IStateEnemy
{
    public void EnterState(AEnemy enemy)
    {
        enemy.SetAnimationTrigger("takeDMG");
    }

    public void ExitState(AEnemy enemy)
    {
    }

    public void UpdateState(AEnemy enemy)
    {
    }
}
