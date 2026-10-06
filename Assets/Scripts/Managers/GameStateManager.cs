using UnityEngine;

public enum GameStates
{
    init,
    MainMenu,
    Gameplay,
    Win,
    Lose,
    Paused,

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
                ServiceHubManager.Instance.timer.ResetTimer();
                break;

            case GameStates.Gameplay:
                break;

            case GameStates.Paused:
                break;

            case GameStates.Lose:
                ServiceHubManager.Instance.sceneManager.LoadScene("GameOverScene");
                break;

            case GameStates.Win:
                ServiceHubManager.Instance.sceneManager.LoadScene("GameWinScene");
                break;

        }

    }
}
