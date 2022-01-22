using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GameObject bulletPrefab;
    Transform weaponTransform;
    PlayerHand activeHand;
    Queue<PlayerHand> slotsQueue = new Queue<PlayerHand>();

    public PlayerHand happyHand = new PlayerHand();
    public PlayerHand angryHand = new PlayerHand();


    private void OnEnable() {
        slotsQueue.Enqueue(happyHand);
        slotsQueue.Enqueue(angryHand);
    }


    void Start()
    {
        


        activeHand = slotsQueue.Dequeue();
        slotsQueue.Enqueue(activeHand);

        GameObject weaponInstance = Instantiate(weaponPrefab, activeHand.pos.position, Quaternion.identity);
        weaponTransform = weaponInstance.transform;
        weaponTransform.parent = activeHand.pos;
    }


    void Update()
    {
        SwapPositions();
        Fire();
    }


    void SwapPositions()
    {
        if (Input.GetMouseButtonDown(1))
        {
            activeHand = slotsQueue.Dequeue();
            slotsQueue.Enqueue(activeHand);
            weaponTransform.position = activeHand.pos.position;
            weaponTransform.parent = activeHand.pos;
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject newBullet = Instantiate(bulletPrefab, activeHand.pos.position, Quaternion.identity);
            int randomNum = Random.Range(0,2);
            State newState = randomNum == 0 ? State.Happy : State.Angry;
            newBullet.GetComponent<Bullet>().SetupBullet(newState, activeHand.pos.forward);
        }
    }
}


[System.Serializable]
public class PlayerHand
{
    public Transform pos;
    public State state;
}
