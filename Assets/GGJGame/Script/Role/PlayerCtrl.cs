using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : SingletonMono<PlayerCtrl>
{
    public GameObject gameover;
    public int SAN;
    public int Smoke;
    [SerializeField]
    private Animation Animation;

    public Sprite Sprite;
    private void Awake()
    {
        GameEventHandler.SwitchGameState += SwitchState;
        GameEventHandler.AddSAN += AddSAN;
        GameEventHandler.AddReward += AddSmoke;
        Animation.Play("Idle");
    }

    private void OnDestroy()
    {
        GameEventHandler.SwitchGameState -= SwitchState;
        GameEventHandler.AddSAN -= AddSAN;
        GameEventHandler.AddReward -= AddSmoke;
        Animation.Play("Idle");
    }

    // Update is called once per frame
    public void SwitchState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.None:
                break;
            case GameState.SeletAction:
                break;
            case GameState.WaitCustomer:
                break;
            case GameState.Joking:
                break;
            case GameState.Smoking:
                Animation.Play("smoking");
                break;
        }
    }

    public void EndSmoking()
    {
        GameEventHandler.CallSwitchGameState(GameState.SeletAction);
        GameMain.OnSmoking = false;
        Animation.Play("Idle");
    }
    public void KillME()
    {
        transform.GetComponent<SpriteRenderer>().sprite = Sprite;
        Animation.Play("Killme");
        
    }
    
    public void EndGame()
    {
        gameover.SetActive(true);
    }
    private void AddSAN(int san)
    {
        this.SAN += san;
        if (SAN>=100)
        {
            Animation.Play("Kill");
        }
    }
    private void AddSmoke(int Smoke)
    {
        this.Smoke += Smoke;
    }
    
  
}
