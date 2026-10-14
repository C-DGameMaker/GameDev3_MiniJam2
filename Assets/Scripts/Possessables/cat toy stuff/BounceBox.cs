using UnityEngine;
using UnityEngine.Playables;

public class BounceBox : MonoBehaviour
{
    public bool InPlace = false;
    public PlayableDirector bounce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CatToy"))
        {
            if (InPlace)
            {
                bounce.Play();
            }
        }
    }
    
}
