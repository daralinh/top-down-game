public class EnemyChasingPlayerState : IStateEnemy
{

    public void EnterState(AEnemy enemy)
    {
        ChooseDirectionPlayer(enemy);
        enemy.SetAnimationTrigger("run");
        enemy.ChangeSpeedWhenChasing();
    }

    public void ExitState(AEnemy enemy)
    {
    }

    public void UpdateState(AEnemy enemy)
    {
        ChooseDirectionPlayer(enemy);
    }

    private void ChooseDirectionPlayer(AEnemy enemy)
    {
        enemy.ChoosePlayerDirection();
    }
}
