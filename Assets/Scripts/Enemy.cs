using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject dieParticles, puffParticles;
    Transform target;
    State enemyType;


    private void OnEnable() {
        target = GameManager.Instance.GetRandomPlayer;
        SetupSelf();
    }


    void SetupSelf()
    {
        int randomNumber = Random.Range(0, 2);
        enemyType = randomNumber == 0 ? State.Happy : State.Angry;
        SetupColor();
    }

    void SetupColor()
    {
        if (enemyType == State.Happy)
        {
            GetComponent<MeshRenderer>().material.SetFloat("_T", 0f);
        }
        else
        {
            GetComponent<MeshRenderer>().material.SetFloat("_T", 1f);
        }
    }

    private void Update() {
        if (target != null)
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    public void HandleBulletCollision(State bulletType)
    {
        if (bulletType == enemyType)
        {
            GameEvents.onEnemyKilled?.Invoke();
            Instantiate(dieParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else
        {
            Instantiate(puffParticles, transform.position, Quaternion.identity);
        }
    }
}
