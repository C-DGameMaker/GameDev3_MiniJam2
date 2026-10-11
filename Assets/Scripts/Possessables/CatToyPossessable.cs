using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class CatToyPossessable : MonoBehaviour,Possessable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public AudioSource SFX;
    public PlayableDirector DoorOpenTimeline;
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CatCanHear = false;
     
    public void Action()
    {
        Debug.Log("sqeeked");
        //SFX.Play();
        if (CatCanHear)
        {
            Debug.Log("cat hear the toy");
            DoorOpenTimeline.Play();
        }
    }
    
    public void Move(InputAction.CallbackContext context)
    {

    }
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
