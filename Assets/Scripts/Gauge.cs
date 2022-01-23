using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Slider gauge;
    float gaugeValue = 0.5f;

    private void Start() {
        gauge.value = gaugeValue;
    }

    public void HandleShoot(State state)
    {
        if (state == State.Happy)
        {
            gaugeValue -= 0.03f;
            gaugeValue = Mathf.Clamp01(gaugeValue);
        }
        else if(state == State.Angry)
        {
            gaugeValue += 0.03f;
            gaugeValue = Mathf.Clamp01(gaugeValue);
        }
        gauge.value = gaugeValue;
    }
    
}
