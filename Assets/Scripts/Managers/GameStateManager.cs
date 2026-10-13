using UnityEngine;

public enum GameStates
{
    init,
    MainMenu,
    Gameplay,
    Win,
    Lose,
    Paused,
    Secret,


}

public class GameStateManager : MonoBehaviour
{
    public GameStates currentState { get; private set; }
    public GameStates previousState { get; private set; }

    private void Start()
    {
        SwitchGameStates(GameStates.init); 
    }

    public void SwitchGameStates(GameStates newGameState)
    {
        previousState = currentState;
        currentState = newGameState;

        OnStateChange(newGameState);
        Debug.Log(currentState);
    }

    private void OnStateChange(GameStates newState)
    {
        switch (newState)
        {
            default:
                break;

            case GameStates.init:
                SwitchGameStates(GameStates.MainMenu);
                break;

            case GameStates.MainMenu:
                ServiceHubManager.Instance.uiManager.HideAllUI();
                ServiceHubManager.Instance.timer.ResetTimer();
                Time.timeScale = 1;
                break;

            case GameStates.Gameplay:
                ServiceHubManager.Instance.uiManager.TimerActive();
                ServiceHubManager.Instance.uiManager.HidePauseMenuUI();
                Time.timeScale = 1;
                break;

            case GameStates.Paused:
                ServiceHubManager.Instance.uiManager.HideAllUI();
                ServiceHubManager.Instance.uiManager.ShowPauseMenuUI();
                Time.timeScale = 0;
                break;

            case GameStates.Lose:
                ServiceHubManager.Instance.sceneManager.LoadScene("GameOverScene");
                ServiceHubManager.Instance.timer.ResetTimer();
                break;

            case GameStates.Win:
                ServiceHubManager.Instance.sceneManager.LoadScene("GameWinScene");
                ServiceHubManager.Instance.timer.ResetTimer();
                break;

            case GameStates.Secret:
                break;

        }

    }
}
