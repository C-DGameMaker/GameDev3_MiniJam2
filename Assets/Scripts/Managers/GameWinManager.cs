using UnityEngine;

public class GameWinManager : MonoBehaviour
{
    public GameObject firstButton;

    private void Start()
    {
        ServiceHubManager.Instance.eventSystemManager.SetButton(firstButton);
    }
    public void RetryButton()
    {
        ServiceHubManager.Instance.sceneManager.LoadScene("Gameplay");
        ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Gameplay);
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
