using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void HideSlashEffect()
    {
        gameObject.SetActive(false);
    }
}
