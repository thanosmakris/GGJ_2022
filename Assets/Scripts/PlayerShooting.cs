using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform[] weaponSlots;
    Transform weaponTransform;
    Queue<Transform> slotsQueue = new Queue<Transform>();


    private void OnEnable() {
        GameObject weaponInstance = Instantiate(weaponPrefab, weaponSlots[0].position, Quaternion.identity);
        weaponTransform = weaponInstance.transform;
    }


    void Start()
    {
        slotsQueue.Enqueue(weaponSlots[0]);
        slotsQueue.Enqueue(weaponSlots[1]);
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
            Transform newPos = slotsQueue.Dequeue();
            slotsQueue.Enqueue(newPos);
            weaponTransform.position = newPos.position;
            weaponTransform.parent = newPos;
        }
    }

    void Fire()
    {

    }
}
