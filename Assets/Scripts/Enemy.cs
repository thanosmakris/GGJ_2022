using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject dieParticles;
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
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    private void Update() {
        if (target != null)
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    public void Die()
    {
        Instantiate(dieParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
