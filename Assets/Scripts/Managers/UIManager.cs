using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject timerUI;
    public GameObject pausedUI;
    public GameObject mainMenuUI;

    public void HideAllUI()
    {
        timerUI.SetActive(false);
        pausedUI.SetActive(false);
        mainMenuUI.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
    }

    public void TimerActive()
    {
        timerUI.SetActive(true);
    }

    public void ShowPauseMenuUI()
    {
        pausedUI.SetActive(true);
    }

    public void HidePauseMenuUI()
    {
        pausedUI.SetActive(false);
    }
}
