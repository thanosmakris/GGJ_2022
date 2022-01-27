using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gauge : MonoBehaviour
{
    public Slider gauge;
    public TextMeshProUGUI warningLeft, warningRight;

    public AudioManager audioManager;
    float gaugeValue = 0.5f;

    private void Start() {
        gauge.value = gaugeValue;
        warningLeft.enabled = false;
        warningRight.enabled = false;
    }

    public void HandleShoot(State state)
    {
        if (state == State.Happy)
        {
            gaugeValue -= 0.025f;
            gaugeValue = Mathf.Clamp01(gaugeValue);
        }
        else if(state == State.Angry)
        {
            gaugeValue += 0.025f;
            gaugeValue = Mathf.Clamp01(gaugeValue);
        }
        gauge.value = gaugeValue;
        CheckGauge();
    }

    void CheckGauge()
    {
        if (gaugeValue >= 1f || gaugeValue <= 0f)
        {
            GameEvents.onPlayerDied?.Invoke();
            return;
        }

        if (gaugeValue < 0.15f)
        {
            if (!warningLeft.enabled)
            {
                warningLeft.enabled = true;
                audioManager.PlayWarningSfx();
            }
        }

        else if (gaugeValue > 0.85f)
        {
            if (!warningRight.enabled)
            {
                warningRight.enabled = true;
                audioManager.PlayWarningSfx();
            }
        }

        else
        {
            warningRight.enabled = false;
            warningLeft.enabled = false;
        }
    }
    
}
