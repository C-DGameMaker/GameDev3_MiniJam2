using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeButton()
    {
        ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Gameplay);
    }

    public void MainMenuButton()
    {
        ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.MainMenu);
        ServiceHubManager.Instance.sceneManager.LoadScene("MainMenu");
    }
}
