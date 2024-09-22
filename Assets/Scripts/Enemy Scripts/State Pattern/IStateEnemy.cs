using UnityEngine;

public interface IStateEnemy
{
    void EnterState(AEnemy enemy);
    void UpdateState(AEnemy enemy);
    void FixedUpdateState(AEnemy enemy);
    void ExitState(AEnemy enemy);
}
