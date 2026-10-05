using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("CharlieTestScene");
    }
}
