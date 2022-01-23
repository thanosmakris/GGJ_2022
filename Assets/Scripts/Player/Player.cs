using UnityEngine;


public enum State
{
    Happy,
    Angry
}

public class Player : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Enemy"))
        {
            Death();
        }
    }

    void Death()
    {

    }
    
}
