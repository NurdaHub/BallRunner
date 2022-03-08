using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        gameObject.SetActive(false);
    }
}
