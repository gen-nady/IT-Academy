using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class NavAgentMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private static float defaultSpeed = 10f;
    float speed = 1f;
    public GameObject door;
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
            //Debug.Log(index + " " + agent.GetAreaCost(index));
            agent.speed = defaultSpeed / agent.GetAreaCost(index);
        }
        else
        {
            //Debug.LogWarning(index);
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
        if (other.gameObject.CompareTag("Door"))
        {                        
            StartCoroutine(DoorOpen());
        }
    }
    IEnumerator DoorOpen()
    {
        for (int i = 0; i < 10; i++)
        {
            door.gameObject.transform.position = new Vector3(door.transform.position.x + speed, door.gameObject.transform.position.y, door.gameObject.transform.position.z);
            yield return new WaitForSeconds(0.1f);

        }
    }
    IEnumerator DoorClose()
    {
        for (int i = 0; i < 10; i++)
        {
            door.gameObject.transform.position = new Vector3(door.transform.position.x - speed, door.gameObject.transform.position.y, door.gameObject.transform.position.z);
            yield return new WaitForSeconds(0.1f);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            StartCoroutine(DoorClose());
        }
    }

}
