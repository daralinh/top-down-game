public class MySceneManager : Singleton<MySceneManager>
{
    public string SceneTransitionName { get; private set; }

    public void SetTransitionName(string name)
    {
        this.SceneTransitionName = name;
    }
}