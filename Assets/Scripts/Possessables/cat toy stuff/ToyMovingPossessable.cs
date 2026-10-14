using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class ToyMovingPossessable : MonoBehaviour,Possessable
{
    public PlayableDirector moveBall;
    public PlayableDirector tryToMoveBallWithoutBall;
    public bool ballIsClose;
    public void Move(InputAction.CallbackContext context)
    {

    }
    public void Action()
    {
        if(ballIsClose)
        {
            moveBall.Play();
        }
        else
        {
            tryToMoveBallWithoutBall.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " entered trigger");
        if (other.gameObject.CompareTag("CatToy"))
        {
            Debug.Log("toy can be hit");
            ballIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CatToy"))
        {
            Debug.Log("toy to far to hit");
            ballIsClose = false;
        }
    }
}
