using UnityEngine;
using UnityEngine.AI;
public class NavAgentMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private static float defaultSpeed = 10f;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(agent.transform.position, out hit, 1.1f, NavMesh.AllAreas);
        int index = IndexFromMask(hit.mask);
        if (index >= 0)
        {
            Debug.Log(index + " " + agent.GetAreaCost(index));
            agent.speed = defaultSpeed / agent.GetAreaCost(index);
        }
        else
        {
            Debug.LogWarning(index);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitt))
            {
                agent.SetDestination(hitt.point);
            }
        }
    }
    int IndexFromMask(int mask)
    {
        for (int i = 0; i < 32; ++i)
        {
            if ((1 << i) == mask)
                return i;
        }
        return -1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {       
            float speed = 2f;
            other.gameObject.transform.position = Vector3.Lerp(other.transform.position, new Vector3(other.transform.position.x + 10f, other.transform.position.y, other.transform.position.z), speed);
        }
    }
}
