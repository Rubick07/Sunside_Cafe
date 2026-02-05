using System.Collections.Generic;
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

    public List<EmotionSprite> emotions;

    public Sprite GetEmotion(string emotion)
    {
        foreach (var e in emotions)
        {
            if (e.emotionName == emotion)
                return e.sprite;
        }

        Debug.LogWarning(
            $"Emotion '{emotion}' not found for character '{npcName}'"
        );
        return null;
    }

}

[System.Serializable]
public class EmotionSprite
{
    public string emotionName;
    public Sprite sprite;
}