using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCtrl : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_FaceList;
    [SerializeField]
    private Transform defFace;
    
    [SerializeField]
    private Animation Animation;

    public NPCData NpcData;
    private void Awake()
    {
        foreach (var item in m_FaceList)
        {
            item.gameObject.SetActive(false);
        }
        defFace.gameObject.SetActive(true);
        GameEventHandler.JokeScoreBack += ChangeState;
        Animation.Play("Enter");
    }
    private void OnDestroy()
    {
        GameEventHandler.JokeScoreBack -= ChangeState;
    }
    private void ChangeState(int state)
    {
        int faceID = 0;
        GameMain.Score+=state;
        switch (state)
        {
            case 0:
                faceID = 0;
                GameEventHandler.CallAddSAN(NpcData.punishment*2);
                break;
            case 1:
                faceID = 0;
                GameEventHandler.CallAddSAN(NpcData.punishment*2);
                GameMain.Score++;
                break;
            case 2:
                faceID = 1;
                GameEventHandler.CallAddSAN(NpcData.punishment);
                break;
            case 3:
                faceID = 1;
                break;
            case 4:
                faceID = 2;
                GameEventHandler.CallAddReward(NpcData.Reward);
                GameMain.Num++;
                break;
            case 5:
                faceID = 2;
                GameEventHandler.CallAddReward(NpcData.Reward*2);
                GameMain.Num++;
                break;
        }
        for (int i = 0; i < m_FaceList.Count; i++)
        {
            if (i==faceID)
            {
                m_FaceList[i].gameObject.SetActive(true);
            }
            else
            {
                m_FaceList[i].gameObject.SetActive(false);
            }
           
        }
        Invoke("DoExit",1f);
    }

    private void DoExit()
    {
        Animation.Play("Exit");
    }

    public void OnExit()
    {
        if (PlayerCtrl.Instance.SAN>60)
        {
            GameEventHandler.CallSwitchGameState(GameState.SeletAction);
        }
        else
        {
            GameEventHandler.CallSwitchGameState(GameState.WaitCustomer);
        }
        Destroy(this.gameObject);
    }
}
