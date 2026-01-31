using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "Scriptable Objects/NPCData")]
public class NPCData : ScriptableObject
{
    public enum NPC_Type
    {
        IMPORTANT,
        SIDE
    }

    public string npcName;
    public NPC_Type type;
    public Sprite npcSprite;

}
