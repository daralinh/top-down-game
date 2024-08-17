using UnityEngine;

public class HitboxWeapon : MonoBehaviour
{
    [SerializeField] private AWeapon weapon;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HpManager>())
        {
            collision.gameObject.GetComponent<HpManager>().TakeDamge(weapon.Damage);
        }
    }
}
