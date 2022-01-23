using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource happySource, angrySource, sfxSource;
    public AudioClip happyFireSFX, angryFireSfx, enemyKillSfx, weaponSwitchSfx, playerDeathSfx, warningSfx;

    private void OnEnable() {
        GameEvents.onStateChanged += SwitchSource;
        GameEvents.onEnemyKilled += PlayEnemyKillSound;
        GameEvents.onPlayerDied += PlayPlayerDeathSound;
    }

    private void OnDisable() {
        GameEvents.onStateChanged -= SwitchSource;
        GameEvents.onEnemyKilled -= PlayEnemyKillSound;
        GameEvents.onPlayerDied -= PlayPlayerDeathSound;
    }

    public void PlayPlayerDeathSound()
    {
        sfxSource.PlayOneShot(playerDeathSfx);
    }

    public void PlayWarningSfx() => sfxSource.PlayOneShot(warningSfx);


    public void PlayFireSound(State state)
    {
        sfxSource.PlayOneShot(happyFireSFX, 0.4f);
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
            //happySource.mute = false;
        }
        else
        {
            //happySource.mute = true;
            angrySource.mute = false;
        }
    }

}
