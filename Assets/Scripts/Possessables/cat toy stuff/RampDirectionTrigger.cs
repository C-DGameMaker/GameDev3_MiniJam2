using UnityEngine;

public class RampDirectionTrigger : MonoBehaviour
{
    public bool topTrigger;
    public RampPossessable ramp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CatToy"))
        {
            if (topTrigger)
            {
                ramp.ballCameFromAbove = true;
            }
            else
            {
                ramp.ballCameFromTheSide = true;
            }
        }
    }
}
