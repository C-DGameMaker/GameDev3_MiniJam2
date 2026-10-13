using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class RampPossessable : MonoBehaviour,Possessable
{
    public PlayableDirector rotate;
    public PlayableDirector rotateBack;
    public PlayableDirector rollBackToCarrier;
    public PlayableDirector rolltoDrawer;
    public PlayableDirector rollBackToDrawer;
    public bool ballCameFromAbove;
    public bool ballCameFromTheSide;
    public bool rotated;
    
    public void Move(InputAction.CallbackContext context)
    {

    }
    public void Action()
    {
        if (rotated)
        {
            rotateBack.Play();
            rotated = false;
        }
        else
        {
            rotated = true;
            rotate.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CatToy"))
        {
            if (rotated)
            {
                if (ballCameFromAbove)
                {
                    rolltoDrawer.Play();
                }
                else if (ballCameFromTheSide)
                {
                    rollBackToDrawer.Play();
                }
            }
            else
            {
                if (ballCameFromAbove)
                {
                    rollBackToCarrier.Play();
                }
            }
        }
    }
}
