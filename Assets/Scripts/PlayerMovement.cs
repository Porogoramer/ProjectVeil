using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 1000f;
    private Input inputActions;
    private Vector2 inputVector;
    private Vector2 lookVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new Input();
        inputActions.Player.Enable();
    }

    void Update()
    {
        inputVector = inputActions.Player.Walk.ReadValue<Vector2>();
        lookVector = inputActions.Player.Look.ReadValue<Vector2>();
        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0, lookVector.x, 0).normalized);
    }

    void FixedUpdate()
    {
        rb.AddForce(speed * Time.deltaTime * (Quaternion.AngleAxis(rb.rotation.eulerAngles.y, Vector3.up) * new Vector3(inputVector.x, 0, inputVector.y)).normalized);
    }
}
