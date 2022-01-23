using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource happySource, angrySource, sfxSource;
    public AudioClip happyFireSFX, angryFireSfx, enemyKillSfx, weaponSwitchSfx;

    private void OnEnable() {
        GameEvents.onStateChanged += SwitchSource;
        GameEvents.onEnemyKilled += PlayEnemyKillSound;
    }

    private void OnDisable() {
        GameEvents.onStateChanged -= SwitchSource;
        GameEvents.onEnemyKilled -= PlayEnemyKillSound;
    }


    public void PlayFireSound(State state)
    {
        if (state == State.Happy)
        {
            sfxSource.PlayOneShot(happyFireSFX);
        }
        else
        {
            sfxSource.PlayOneShot(angryFireSfx);
        }
    }

    void PlayEnemyKillSound()
    {
        sfxSource.PlayOneShot(enemyKillSfx);
    }

    

    void SwitchSource(State activeState)
    {
        sfxSource.PlayOneShot(weaponSwitchSfx);
        if (activeState == State.Happy)
        {
            angrySource.mute = true;
            happySource.mute = false;
        }
        else
        {
            happySource.mute = true;
            angrySource.mute = false;
        }
    }

}
