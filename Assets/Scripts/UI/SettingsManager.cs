using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void SetSFXVolume(float value)
    {
        Debug.Log($"SFX Volume changed to: {value}");
        AudioManager.Instance?.SetSFXVolume(value);
    }

    public void SetMusicVolume(float value)
    {
        Debug.Log($"Music Volume changed to: {value}");
        AudioManager.Instance?.SetMusicVolume(value);
    }
}
