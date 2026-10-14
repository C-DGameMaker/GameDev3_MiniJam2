using UnityEngine;

public class carBallCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " entered trigger");
        if (other.gameObject.CompareTag("CatToy"))
        {
            Debug.Log("toy can be hit");
            this.GetComponentInParent<ToyMovingPossessable>().ballIsClose = true;
        }
    }
}
