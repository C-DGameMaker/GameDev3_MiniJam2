using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject timerUI;
    public GameObject pausedUI;

    public void HideAllUI()
    {
        timerUI.SetActive(false);
        pausedUI.SetActive(false);
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
