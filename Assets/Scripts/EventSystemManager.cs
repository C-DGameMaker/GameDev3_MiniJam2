using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    public void SetButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}
