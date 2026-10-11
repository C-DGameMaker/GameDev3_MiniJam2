using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class CatToyPossessable : MonoBehaviour,Possessable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public AudioSource SFX;
    
    public UnityEvent Sqeeking;
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CatCanHear = false;
     
    public void Action()
    {
        Debug.Log("sqeeked");
        //SFX.Play();
        Sqeeking.Invoke();
    }
    
    public void Move(InputAction.CallbackContext context)
    {

    }
    
    
}
