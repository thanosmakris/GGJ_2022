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
            other.transform.GetComponent<Enemy>().Die();
        }
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
