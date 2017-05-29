using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed;

    private Rigidbody myRigidbody;
    private Vector3 moveVelocity;

    private Animator animator;
    private float animWalkSpeed = 0f;
    private const float TransitionSpeed = 20;

    // Use this for initialization
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var moveDirection = new Vector3(horizontal, 0f, vertical);

        moveVelocity = moveDirection * MoveSpeed;

        this.transform.LookAt(this.transform.position + moveDirection);

        float maxInput = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));
        animWalkSpeed = Mathf.Lerp(animWalkSpeed, maxInput, Time.deltaTime*TransitionSpeed);
        animator.SetFloat("MoveSpeed", maxInput);

        if (Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("Attack");
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
