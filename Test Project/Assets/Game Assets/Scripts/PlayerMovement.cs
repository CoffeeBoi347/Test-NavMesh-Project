using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Component References")]

    public NavMeshAgent playerAgent;
    public Animator anim;

    [Header("Others")]

    public Vector3 mousePosition;

    private void Start()
    {
        if(playerAgent == null)
        {
            playerAgent = GetComponent<NavMeshAgent>();
        }

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MovementHandling();
    }

    void MovementHandling()
    {
        mousePosition = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                anim.SetBool("isRunning", true);
                playerAgent.SetDestination(hit.point);
            }
        }


        if (HasReachedDestination())
        {
            anim.SetBool("isRunning", false);
        }
    }

    bool HasReachedDestination()
    {
        if (!playerAgent.hasPath)
        {
            return true;
        }
        return false;
    }
}