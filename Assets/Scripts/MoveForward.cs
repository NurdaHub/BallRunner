using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public static float moveSpeed = 4;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
