using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public float MoveSpeed;

    private Vector3 moveVelocity;

    private Animator animator;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("Attack");

        if (agent.remainingDistance <= 0.2f)
        {
            animator.SetFloat("MoveSpeed", 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("Ground")))
            {
                animator.SetFloat("MoveSpeed", 1f);
                agent.SetDestination(hit.point);
            }
        }
    }
}
