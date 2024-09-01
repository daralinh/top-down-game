using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveToTarget))]
public class KnockBack : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float thurst;

    private MoveToTarget moveToTarget;
    private Rigidbody2D rb;

    public bool IsKnockBack { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveToTarget = GetComponent<MoveToTarget>();
    }

    public void GetKnockBack(Transform source)
    {
        IsKnockBack = true; moveToTarget.enabled = false;
        Vector2 difference = (transform.position - source.position).normalized * thurst * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(Handler());
    }

    private IEnumerator Handler()
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero;
        IsKnockBack = false;
        moveToTarget.enabled = true;
    }

    public void ChangeThurst(float newThurst)
    {
        thurst = newThurst;
    }
}
