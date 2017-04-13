using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed;

    private Rigidbody myRigidbody;
    private Vector3 moveVelocity;

    // Use this for initialization
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var moveDirection = new Vector3(horizontal, 0f, vertical);

        moveVelocity = moveDirection * MoveSpeed;

        this.transform.LookAt(this.transform.position + moveDirection);
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
