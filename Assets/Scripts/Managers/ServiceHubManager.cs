using UnityEngine;

public class ServiceHubManager : MonoBehaviour
{
    public static ServiceHubManager Instance { get; private set; }

    public SceneManagement sceneManager;
    public GameStateManager gameStateManager;

    private void Awake()
    {
        #region Singleton Pattern

        if (Instance != null && Instance != this)
        {
            Destroy(this);
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
