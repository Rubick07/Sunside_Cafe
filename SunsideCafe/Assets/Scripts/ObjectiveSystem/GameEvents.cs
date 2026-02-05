using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<string, int> OnStatChanged;
    public static Action<string> OnObjectiveCompleted;
}