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

    public GameObject shieldObj;

    bool hasShield = false;

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
                if (hasShield)
                {
                    hasShield = false;
                    shieldObj.SetActive(false);
                    return;
                }
                GameEvents.onPlayerDied?.Invoke();
            }
        }
        if (other.transform.CompareTag("Shield"))
        {
            hasShield = true;
            shieldObj.SetActive(true);
            other.transform.GetComponent<Shield>().GatheredByPlayer();
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
