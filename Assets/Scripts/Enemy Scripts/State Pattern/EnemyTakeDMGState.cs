public class EnemyTakeDMGState : IStateEnemy
{
    public void EnterState(AEnemy enemy)
    {
        enemy.ChangeSpeedToZero();
        enemy.SetAnimationTrigger("takeDMG");
    }

    public void ExitState(AEnemy enemy)
    {
        enemy.ChangeStateToIdle();
    }

    public void FixedUpdateState(AEnemy enemy)
    {
    }

    public void UpdateState(AEnemy enemy)
    {
    }
}
