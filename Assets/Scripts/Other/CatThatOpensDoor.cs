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
        if (CatCanHear)
        {
            Debug.Log("cat hear the toy");
            DoorOpenTimeline.Play();
        }
    }
    public bool CatCanHear = false;
    public PlayableDirector DoorOpenTimeline;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cat"))
        {
            CatCanHear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cat"))
        {
            CatCanHear = false;
        }
    }
}
