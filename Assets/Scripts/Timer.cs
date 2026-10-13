using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public float endTime;
    [SerializeField] float currentTime;
    public TextMeshProUGUI timerText;

 

    private void Update()
    {
       if(ServiceHubManager.Instance.gameStateManager.currentState == GameStates.Gameplay)
       {
            UpdateTime();
            UpdateTimerText();
       }
    }

    private void UpdateTimerText()
    {

        int minutes = Mathf.FloorToInt((endTime - currentTime) / 60);
        int seconds = Mathf.FloorToInt((endTime - currentTime) % 60);

        timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }
    private void UpdateTime()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= endTime)
        {
            ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Lose);
        }
    }

    public void ResetTimer()
    {
        currentTime = 0;
    }
}
