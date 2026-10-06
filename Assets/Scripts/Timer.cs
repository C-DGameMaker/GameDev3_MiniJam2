using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public float endTime;
    [SerializeField] float currentTime;

    private void Awake()
    {
    }
    private void Update()
    {
       if(ServiceHubManager.Instance.gameStateManager.currentState == GameStates.Gameplay)
       {
            UpdateTime();
       }
    }
    private void UpdateTime()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= endTime)
        {
            ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Lose);
        }
    }
}
