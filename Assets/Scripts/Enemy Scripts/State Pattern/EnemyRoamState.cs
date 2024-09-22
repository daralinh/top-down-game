using UnityEngine;
public class EnemyRoamState : IStateEnemy
{
    private float countTimeToChangeDirection;

    public void EnterState(AEnemy enemy)
    {
        enemy.BackToOriginSpeed();
        enemy.ChooseRandomMove();
        enemy.SetAnimationTrigger("run");

        countTimeToChangeDirection = 0;
    }

    public void FixedUpdateState(AEnemy enemy)
    {
        countTimeToChangeDirection += Time.deltaTime;

        if (enemy.TimeToChangeDirectionWhenRoaming < countTimeToChangeDirection)
        {
            enemy.ChooseRandomMove();
            countTimeToChangeDirection = 0;
        }
    }

    public void ExitState(AEnemy enemy)
    {
    }

    public void UpdateState(AEnemy enemy)
    {
    }
}
