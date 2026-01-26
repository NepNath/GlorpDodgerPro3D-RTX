using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movement;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        
    }

    private void FixedUpdate()
    {

        Debug.Log("player Position : " + transform.position);
        rb.AddForce(movement * speed * 10f);
        Quaternion targetRotation = Quaternion.LookRotation(-movement);
        transform.rotation = targetRotation;
    }
}
