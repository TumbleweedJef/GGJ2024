using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TalkPanel : MonoBehaviour
{
    [SerializeField] private Button noth;
    [SerializeField] private Button talk;
    [SerializeField] private Transform bingqingDan;
    [SerializeField] private Text bingqing;
    [SerializeField] private Text SAN;

    [SerializeField] private Text REWARD;

    [SerializeField] private InputField Input;

    public List<string> jokes;

    private void Awake()
    {
        GameEventHandler.SwitchGameState += SwitchGameState;
    }

    private void OnDestroy()
    {
        GameEventHandler.SwitchGameState -= SwitchGameState;
    }

    private void SwitchGameState(GameState gameState)
    {
        bingqing.text = "";
        bingqingDan.gameObject.SetActive(false);
    }

    private void Start()
    {
        talk.onClick.AddListener(() =>
        {
            PlayerCtrl.Instance.SAN += 5;
            bingqing.text = $"病情：{GameMain.currentNPCP}";
            SAN.text = $"{GameMain.Instance.currentNPc.punishment}";
            REWARD.text = $"{GameMain.Instance.currentNPc.Reward}";
            bingqingDan.gameObject.SetActive(true);
        });
        noth.onClick.AddListener(() =>
        {
            PlayerCtrl.Instance.SAN += 5;
            int count = jokes.Count;
            int index = Random.Range(0, count);
            Input.text = jokes[index];
        });
    }
}