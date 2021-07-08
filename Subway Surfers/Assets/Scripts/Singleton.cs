using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instanse;
    public static T Instanse
    {
        get
        {
            if (instanse == null)
            {
                instanse = FindObjectOfType<T>();
                if (instanse == null)
                {
                    var singletonObject = new GameObject();
                    instanse = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instanse;
        }
    }
}

