using System.Linq;
using UnityEngine;

public class HitboxWeapon : MonoBehaviour
{
    [SerializeField] private AWeapon weapon;

    private GameObject taker;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        AHpManager HpComponent = collision.gameObject.
            GetComponents<Component>().FirstOrDefault(c => c is AHpManager) as AHpManager;

        if (HpComponent != null)
        {
            Debug.Log("takeDMGHandler");
            HpComponent.TakeDMG(gameObject.transform, weapon.Damage, weapon.CanKnockBack);
        }
    }
}
