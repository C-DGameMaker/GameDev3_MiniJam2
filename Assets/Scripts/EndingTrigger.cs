using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Win);
        }
    }
}
