using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Tooltip("Difficult platform")]
    public lvlDifficult lvl;
    Vector3 directionPlatform = new Vector3(-1f, 0f, 0f);
    public enum lvlDifficult
    {
        easy, medium, hard
    }
    void Update()
    {
        transform.Translate(directionPlatform * PlatformManager.Instanse.speedPlatform * Time.deltaTime);
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("StartPosition"))
        {
            PlatformManager.Instanse.EmergingPlatform();          
        }
        if (coll.gameObject.CompareTag("EndPosition"))
        {
            PlatformManager.Instanse.DisablePlatform(this);
        }
    }
}
