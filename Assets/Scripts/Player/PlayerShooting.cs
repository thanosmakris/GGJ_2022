using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioManager audioManager;
    public Gauge gauge;
    public GameObject weaponPrefab;
    public GameObject bulletPrefab;
    Transform weaponTransform;
    PlayerHand activeHand;
    Queue<PlayerHand> slotsQueue = new Queue<PlayerHand>();

    public PlayerHand happyHand = new PlayerHand();
    public PlayerHand angryHand = new PlayerHand();

    State currentState;

    bool canShoot = true;


    private void OnEnable() {
        slotsQueue.Enqueue(happyHand);
        slotsQueue.Enqueue(angryHand);
        GameEvents.onPlayerDied += () => canShoot = false;
    }

    private void OnDisable() {
        GameEvents.onPlayerDied -= () => canShoot = false;
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
        if (canShoot)
        {
            SwapPositions();
            Fire();
        }
    }


    void SwapPositions()
    {
        if (Input.GetMouseButtonDown(1))
        {
            activeHand = slotsQueue.Dequeue();
            slotsQueue.Enqueue(activeHand);
            weaponTransform.position = activeHand.pos.position;
            weaponTransform.parent = activeHand.pos;
            currentState = activeHand.state;
            GameEvents.onStateChanged?.Invoke(currentState);
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {

            audioManager.PlayFireSound(currentState);
            GameObject newBullet = Instantiate(bulletPrefab, activeHand.pos.position, Quaternion.identity);
            int randomNum = Random.Range(0,2);
            
            newBullet.GetComponent<Bullet>().SetupBullet(currentState, activeHand.pos.forward);
            gauge.HandleShoot(currentState);
        }
    }
}


[System.Serializable]
public class PlayerHand
{
    public Transform pos;
    public State state;
}
