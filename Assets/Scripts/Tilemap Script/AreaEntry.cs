using UnityEngine;

public class AreaEntry : MonoBehaviour
{
    [SerializeField] private string transitionName;

    private void Start()
    {
        if (transitionName == MySceneManager.Instance.SceneTransitionName)
        {
            PlayerController.Instance.transform.position = this.transform.position;
        }
    }
}
