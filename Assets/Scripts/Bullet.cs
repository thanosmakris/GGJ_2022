using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Vector3 direction = Vector3.zero;


    State bulletType;

    public void SetupBullet(State bulletType, Vector3 direction)
    {
        this.bulletType = bulletType;
        this.direction = direction;
        if (bulletType == State.Happy)
        {
            GetComponent<MeshRenderer>().material.SetFloat("_T", 0f);
            GetComponent<TrailRenderer>().material.SetFloat("_T", 0f);
        }
        else
        {
            GetComponent<MeshRenderer>().material.SetFloat("_T", 1f);
            GetComponent<TrailRenderer>().material.SetFloat("_T", 1f);
        }
    }

    private void Start() {
        Invoke("SelfDestroy", 5f);
    }

    void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Enemy"))
        {
            other.transform.GetComponent<Enemy>().HandleBulletCollision(bulletType);
        }
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
