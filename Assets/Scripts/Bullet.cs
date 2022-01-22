using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector3 direction = Vector3.zero;

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
            Destroy(other.gameObject);
        }
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
