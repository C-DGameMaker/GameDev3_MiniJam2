using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Lose);
        }
    }
}
