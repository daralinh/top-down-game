using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private void Awake()
    {
        transform.position = transform.parent.position;
    }
}
