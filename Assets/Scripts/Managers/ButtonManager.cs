using UnityEngine;
using UnityEngine.Rendering;

public class ButtonManager : MonoBehaviour
{
    public GameObject creditsUI;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        creditsUI.SetActive(false);
    }
    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("You Quit");
    }

    public void OnCreditsButton()
    {
        creditsUI.SetActive(!creditsUI.activeSelf);
    }

    public void OnStartButton()
    {
        ServiceHubManager.Instance.sceneManager.LoadScene("CharlieTestScene");
        ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Gameplay);
    }
}
