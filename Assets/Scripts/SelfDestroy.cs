using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroySelf", 1.5f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
