using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("You Quit");
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("CharlieTestScene");
    }
}
