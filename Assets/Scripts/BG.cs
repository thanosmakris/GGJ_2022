using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public MeshRenderer bgMeshRenderer;

    private void OnEnable() {
        GameEvents.onStateChanged += ChangeBG;
    }

    private void OnDisable() {
        GameEvents.onStateChanged -= ChangeBG;
    }

    private void Start() {
        bgMeshRenderer.material.SetFloat("_Angry", 0f);
    }


    void ChangeBG(State state)
    {
        if (state == State.Happy)
        {
            bgMeshRenderer.material.SetFloat("_Angry", 0f);
        }
        else
        {
            bgMeshRenderer.material.SetFloat("_Angry", 1f);
        }
    }
}
