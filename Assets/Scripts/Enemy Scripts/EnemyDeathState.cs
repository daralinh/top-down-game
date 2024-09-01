public class DeathEnemyState : IStateEnemy
{
    public void EnterState(AEnemy enemy)
    {
        enemy.ChangeSpeedToZero();
        enemy.SetAnimationTrigger("death");
    }

    public void UpdateState(AEnemy enemy)
    {

    }

    public void ExitState(AEnemy enemy)
    {

    }
}
