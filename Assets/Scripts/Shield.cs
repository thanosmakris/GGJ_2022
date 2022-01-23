using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioManager audioManager;
    public float speed;
    public BoxCollider boxCollider;
    public MeshRenderer meshRenderer;

    public Transform[] possiblePositions;
    void Start()
    {
        StartCoroutine(SpawnSelf());
    }

    public void GatheredByPlayer()
    {
        audioManager.PlayShieldSfx();
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
        StartCoroutine(SpawnSelf());
    }

    IEnumerator SpawnSelf()
    {
        yield return new WaitForSeconds(10f);
        Transform newRandomPos = possiblePositions[Random.Range(0, possiblePositions.Length)];
        transform.position = newRandomPos.position;
        boxCollider.enabled = true;
        meshRenderer.enabled = true;

    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
