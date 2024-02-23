using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum GameState
{
    None,
    SeletAction,
    Smoking,
    WaitCustomer,
    Joking,
    PlayerKillSelf,
    GameOver
}

public class GameMain : SingletonMono<GameMain>
{
    public GameState GameState;
    public GameObject ChatPanel;
    public GameObject SelectPanel;
    public GameObject TalkPanel;
    private PlayerCtrl PlayerCtrl;
    [SerializeField] private NPCData_SO m_NpcDataSo;
    public NPCData currentNPc;
    public static string currentNPC = "蜡笔小新";
    public static string currentNPCP = "被妈妈打屁股了";

    public static int Score = 0;
    public static int Num = 0;
    
    public static bool OnSmoking = false;
    private void Awake()
    {
        GameEventHandler.JokeScoreBack += JokeBack;
        GameEventHandler.SwitchGameState += SwitchState;
        SwitchState(GameState.None);
    }

    private void OnDestroy()
    {
        GameEventHandler.JokeScoreBack -= JokeBack;
        GameEventHandler.SwitchGameState -= SwitchState;
    }

    private void JokeBack(int score)
    {
        Debug.Log($"笑话得分{score}");
    }

    private void SwitchState(GameState gameState)
    {
    Debug.Log("gameState:"+gameState);
        switch (gameState)
        {
            case GameState.None:
                SelectPanel.SetActive(false);
                ChatPanel.SetActive(false);
                TalkPanel.SetActive(false);
                break;
            case GameState.SeletAction:
                SelectPanel.SetActive(true);
                ChatPanel.SetActive(false);
                TalkPanel.SetActive(false);
                break;
            case GameState.WaitCustomer:
                SelectPanel.SetActive(false);
                ChatPanel.SetActive(true);
                TalkPanel.SetActive(true);
                LoadOneNpc();
                break;
            case GameState.Joking:
                SelectPanel.SetActive(false);
                ChatPanel.SetActive(false);
                TalkPanel.SetActive(false);
                break;
        }

        this.GameState = gameState;
    }

    private void LoadOneNpc()
    {
        int npcCount = m_NpcDataSo.m_NpcDatas.Count;
        int npcID = Random.Range(0, npcCount);
        NPCData npcdata = m_NpcDataSo.m_NpcDatas[npcID];
        GameObject go = GameObject.Instantiate(Resources.Load($"Prefabs/{npcdata.Name}")) as GameObject;
        GameMain.currentNPC = npcdata.NameCN;
        GameMain.currentNPCP = npcdata.PersonalityFlaw;
        go.GetComponent<NPCCtrl>().NpcData = npcdata;
        currentNPc = npcdata;
    }
}