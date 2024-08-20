using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] private GameObject vFX;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
