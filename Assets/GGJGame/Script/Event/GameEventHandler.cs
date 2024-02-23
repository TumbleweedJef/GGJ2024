using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    public static Action<int> JokeScoreBack;

    public static void CallCallJokeScoreBack(int score)
    {
        JokeScoreBack?.Invoke(score);
    }
    public static Action<GameState> SwitchGameState;

    public static void CallSwitchGameState(GameState gameState)
    {
        SwitchGameState?.Invoke(gameState);
    }
    
    public static Action<int> AddSAN;

    public static void CallAddSAN(int san)
    {
        AddSAN?.Invoke(san);
    }
    
    public static Action<int> AddReward;

    public static void CallAddReward(int san)
    {
        AddReward?.Invoke(san);
    }
}
