using UnityEngine;

[CreateAssetMenu(fileName = "ProfileSO", menuName = "Scriptable Objects/ProfileSO")]
public class ProfileSO : ScriptableObject
{
    public string profileName;
    public string age;
    public string hobbies;
    public string favouriteFood;

    [TextArea(5, 10)]
    public string profileDesc;

    public Sprite characterPotrait;
}
