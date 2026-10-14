using UnityEngine;
using UnityEngine.Rendering;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsUI;
    public GameObject firstButton;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        creditsUI.SetActive(false);

        ServiceHubManager.Instance.eventSystemManager.SetButton(firstButton);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnCreditsButton()
    {
        creditsUI.SetActive(!creditsUI.activeSelf);
    }

    public void OnStartButton()
    {
        ServiceHubManager.Instance.sceneManager.LoadScene("Gameplay");
        ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Gameplay);
    }
}
