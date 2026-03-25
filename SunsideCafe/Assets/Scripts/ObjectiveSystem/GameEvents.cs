using System;
using UnityEngine;

public static class GameEvents
{
    //SOUND
    public static Action<string> OnPlayMusic;
    public static Action<string> OnPlaySFX;
    public static Action<string> OnPlayAmbience;

    //OBJECTIVE
    public static Action<string, int> OnStatChanged;
    public static Action<string> OnObjectiveCompleted;
}