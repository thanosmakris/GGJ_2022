using UnityEngine;


public enum State
{
    Happy,
    Angry
}

public class Player : MonoBehaviour
{

    public GameObject dieParticles;
    public GameObject player1, player2;

    private void OnEnable() {
        GameEvents.onPlayerDied += Death;
    }

    private void OnDisable() {
        GameEvents.onPlayerDied -= Death;
    }

    bool isDead = false;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Enemy") || other.transform.CompareTag("Hazard"))
        {
            if (!isDead)
            {
                GameEvents.onPlayerDied?.Invoke();
            }
        }
    }

    void Death()
    {
        isDead = true;
        player1.SetActive(false);
        player2.SetActive(false);
        Instantiate(dieParticles, transform.position, Quaternion.identity);
    }
    
}
