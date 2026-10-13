using UnityEngine;

public class ServiceHubManager : MonoBehaviour
{
    public static ServiceHubManager Instance { get; private set; }

    public SceneManagement sceneManager;
    public GameStateManager gameStateManager;
    public Timer timer;
    public UIManager uiManager;

    public EventSystemManager eventSystemManager;

    private void Awake()
    {
        #region Singleton Pattern

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        #endregion

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
