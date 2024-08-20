using System.Collections;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField] private MoveToTarget moveToTarget;
    [SerializeField] private float timeToChangeDir;
    private enum State
    {
        Roaming,
        StopRoaming,
    }

    private State state;

    private void Awake()
    {
        moveToTarget = GetComponent<MoveToTarget>();
    }

    void Start()
    {
        StartRoaming();
    }

    public void StartRoaming()
    {
        state = State.Roaming;
        StartCoroutine(StateHandler());
    }

    private IEnumerator StateHandler()
    {
        while (state == State.Roaming)
        {
            moveToTarget.ChooseRandomMove();
            yield return new WaitForSeconds(timeToChangeDir);
        }
    }

    public void StopRoaming()
    {
        state = State.StopRoaming;
    }
}
