using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    Transform target;
    private void OnEnable() {
        target = GameManager.Instance.GetRandomPlayer;
        
    }

    private void Update() {
        transform.LookAt(target.position);
    }
}
