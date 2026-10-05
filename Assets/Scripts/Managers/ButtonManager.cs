using UnityEngine;
using UnityEngine.Rendering;

public class ButtonManager : MonoBehaviour
{
    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("You Quit");
    }
}
