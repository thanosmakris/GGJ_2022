using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Player
{
    public GameObject weaponPrefab;
    public GameObject bulletPrefab;
    public Transform[] weaponSlots;
    Transform weaponTransform;
    Transform activeSlot;
    Queue<Transform> slotsQueue = new Queue<Transform>();


    private void OnEnable() {
        slotsQueue.Enqueue(weaponSlots[0]);
        slotsQueue.Enqueue(weaponSlots[1]);
    }


    void Start()
    {
        activeSlot = slotsQueue.Dequeue();
        slotsQueue.Enqueue(activeSlot);

        GameObject weaponInstance = Instantiate(weaponPrefab, activeSlot.position, Quaternion.identity);
        weaponTransform = weaponInstance.transform;
        weaponTransform.parent = activeSlot;
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
            activeSlot = slotsQueue.Dequeue();
            slotsQueue.Enqueue(activeSlot);
            weaponTransform.position = activeSlot.position;
            weaponTransform.parent = activeSlot;
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject newBullet = Instantiate(bulletPrefab, activeSlot.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().direction = activeSlot.forward;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawRay(weaponSlots[0].position, weaponSlots[0].forward);
    }
}
