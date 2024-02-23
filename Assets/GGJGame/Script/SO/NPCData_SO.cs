using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public enum BadThing
{
    None,
}

[CreateAssetMenu(fileName = "NewNPCData", menuName = "NPC Data", order = 51)]
public class NPCData_SO : ScriptableObject
{
    public List<NPCData> m_NpcDatas = new List<NPCData>();
}

[System.Serializable]
public class NPCData
{
    public string Name;
    public string NameCN;
    public int Reward;
    public int punishment;
    public string PersonalityFlaw;
    public bool isWorning;
    
}