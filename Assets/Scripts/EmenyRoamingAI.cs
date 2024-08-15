using System.Collections;
using UnityEngine;

public class EmenyRoamingAI : MonoBehaviour
{
    [SerializeField] private float timeToChangeDir;
    private enum State
    {
        Roaming,
        StopRoaming,
    }

    private State state;
    private RoamingNoneTarget roamingNoneTarget;

    private void Awake()
    {
        roamingNoneTarget = GetComponent<RoamingNoneTarget>();
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
            roamingNoneTarget.ChooseRandomMove();
            yield return new WaitForSeconds(timeToChangeDir);
        }
    }

    public void StopRoaming()
    {
        state = State.StopRoaming;
    }
}
