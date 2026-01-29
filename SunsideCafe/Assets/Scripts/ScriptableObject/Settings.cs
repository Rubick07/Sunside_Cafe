using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    public float musicVolume;
    public float sfxVolume;

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(this);
    }

    public void LoadSettings()
    {
        SettingData data = SaveSystem.LoadSettings();

        musicVolume = data.MusicSet;
        sfxVolume = data.SFXSet;
    }

}