using System.Runtime.Serialization;

public class EnemyIdleState : IStateEnemy
{
    public void EnterState(AEnemy enemy)
    {
        enemy.SetAnimationTrigger("idle");
        enemy.ChangeSpeedToZero();
    }

    public void ExitState(AEnemy enemy)
    {
    }

    public void FixedUpdateState(AEnemy enemy)
    {
        if (enemy.IsPlayerNearby)
        {
            enemy.ChangeStateToChasingPlayer();
            return;
        }

        enemy.ChangeStateToRoam();
    }

    public void UpdateState(AEnemy enemy)
    {
    }
}
