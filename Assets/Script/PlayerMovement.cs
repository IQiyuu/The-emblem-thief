using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 velocity = Vector3.zero;
    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }
    
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        transform.position = new Vector3(transform.position.x + _horizontalMovement, transform.position.y + _verticalMovement, 0);
    }
}