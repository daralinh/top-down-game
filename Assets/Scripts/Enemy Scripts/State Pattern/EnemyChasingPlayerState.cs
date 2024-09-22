public class EnemyChasingPlayerState : IStateEnemy
{
    private int countFixedUpdate = 0;
    private int numberFixedUpdateToFindNewPath = 6;
    public void EnterState(AEnemy enemy)
    {
        enemy.SetAnimationTrigger("run");
        enemy.ChangeSpeedWhenChasing();
        countFixedUpdate = numberFixedUpdateToFindNewPath - 1;
    }

    public void ExitState(AEnemy enemy)
    {
    }

    public void FixedUpdateState(AEnemy enemy)
    {
        if (++countFixedUpdate / numberFixedUpdateToFindNewPath == 0)
        {
            if(enemy.FindPathToPlayer())
            {
                countFixedUpdate = 0;
            }
            else
            {
                countFixedUpdate--;
            }
        }

        enemy.MoveFollowNodeInPathToPlayer();
    }

    public void UpdateState(AEnemy enemy)
    {
    }
}
