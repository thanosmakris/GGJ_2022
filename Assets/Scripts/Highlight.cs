using UnityEngine;

public class Highlight : MonoBehaviour
{
    public GameObject hilightedMesh;
    public State state;

    private void OnEnable() {
        GameEvents.onStateChanged += ToggleHighlight;
    }

    private void OnDisable() {
        GameEvents.onStateChanged -= ToggleHighlight;
    }





    void ToggleHighlight(State currentState)
    {
        if (currentState == state)
        {
            hilightedMesh.SetActive(true);
        }
        else
        {
            hilightedMesh.SetActive(false);
        }
    }
}
