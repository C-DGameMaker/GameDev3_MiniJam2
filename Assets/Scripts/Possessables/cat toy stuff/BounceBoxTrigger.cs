using UnityEngine;
using UnityEngine.Playables;

public class BounceBoxTrigger : MonoBehaviour
{
    public PlayableDirector lockBoxIn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bounce Cube"))
        {
            other.gameObject.GetComponentInParent<BounceBox>().InPlace = true;
            other.gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            lockBoxIn.Play();
        }
    }
}
