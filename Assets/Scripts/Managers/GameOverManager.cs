using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public void RetryButton()
    {

    }

    public void MainMenuButton()
    {
        ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.MainMenu);
        ServiceHubManager.Instance.sceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
