using System.Collections;
using UnityEngine;


[RequireComponent(typeof(MoveToTarget))]
public class RandomMove : MonoBehaviour
{
    [SerializeField] private float timeToChangeDir;
    private MoveToTarget moveToTarget;
    
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
        StartCoroutine(StateHandler());
    }

    private IEnumerator StateHandler()
    {
        moveToTarget.ChooseRandomMove();
        yield return new WaitForSeconds(timeToChangeDir);
    }
}
