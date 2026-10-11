using UnityEngine;
using UnityEngine.Playables;

public class CatThatOpensDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        if (CatCanHear && hasMoved == false)
        {
            Debug.Log("cat hear the toy");
            DoorOpenTimeline.Play();
            hasMoved = true;
        }
    }
    public bool CatCanHear = false;
    public PlayableDirector DoorOpenTimeline;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " entered trigger");
        if (other.gameObject.CompareTag("CatToy"))
        {
            Debug.Log("cat toy enterd cat's hearing range");
            CatCanHear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CatToy"))
        {
            Debug.Log("cat toy has left cat's hearing range");
            CatCanHear = false;
        }
    }
    public bool hasMoved = false;
}
