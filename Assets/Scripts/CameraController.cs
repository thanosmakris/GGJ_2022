using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class CameraController : MonoBehaviour
{
    public Shaker shaker;
    public ShakePreset shakePreset;

    private void OnEnable() {
        GameEvents.onEnemyKilled += ShakeCamera;
    }

    private void OnDisable() {
        GameEvents.onEnemyKilled -= ShakeCamera;
    }

    void ShakeCamera()
    {
        shaker.Shake(shakePreset);
    }
}
