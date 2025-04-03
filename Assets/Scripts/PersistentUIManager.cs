using UnityEngine;

public class PersistentUIManager : MonoBehaviour
{
    private static PersistentUIManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
