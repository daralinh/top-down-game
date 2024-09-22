using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATKPlayerState : IStateEnemy
{
    public void EnterState(AEnemy enemy)
    {
        enemy.ChoosePlayerDirection();
        enemy.ChangeSpeedToHalf();
        enemy.SetAnimationTrigger("atk");
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
