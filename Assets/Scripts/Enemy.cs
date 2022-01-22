using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Happy,
    Angry
}

public class Enemy : MonoBehaviour
{
    public float speed;
    Transform target;
    EnemyType enemyType;


    private void OnEnable() {
        target = GameManager.Instance.GetRandomPlayer;
        SetupSelf();
    }
    

    void SetupSelf()
    {
        int randomNumber = Random.Range(0, 2);
        enemyType = randomNumber == 0 ? EnemyType.Happy : EnemyType.Angry;

    }

    private void Update() {
        if (target != null)
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }
}
