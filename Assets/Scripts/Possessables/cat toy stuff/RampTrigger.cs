using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CatToy"))
        {
            GetComponentInParent<RampPossessable>().RollBall();
        }
    }
}
