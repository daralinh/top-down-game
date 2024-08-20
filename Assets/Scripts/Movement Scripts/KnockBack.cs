using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [Header("---- Components")]
    [SerializeField] private MoveToTarget moveToTarget;
    [Header("---- Parameters ----")]
    [SerializeField] private float time;
    [SerializeField] private float thurst;

    public bool IsKnockBack
    {
        get; private set;
    }

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
