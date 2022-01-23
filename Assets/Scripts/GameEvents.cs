using UnityEngine;
using System;

public static class GameEvents
{
    public static Action onEnemyKilled;
    public static Action<State> onStateChanged;
}
