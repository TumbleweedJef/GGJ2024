using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Button GameOver;
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text Num;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.onClick.AddListener(() =>
        {
            ReloadCurrentScene();
        });
    }

    private void OnEnable()
    { 
        Num.text = GameMain.Num.ToString();
        if (GameMain.Score>0)
        {
            Score.text = "你就是那个笑话";
        }
        if (GameMain.Score>20)
        {
            Score.text = "你觉得好笑吗？";
        }
        if (GameMain.Score>30)
        {
            Score.text = "医学界郭德纲";
        }
        if (GameMain.Score>40)
        {
            Score.text = "世界和平大使";
        }
       
    }

    public void ReloadCurrentScene()
    {
        // 获取当前场景的名称
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneName);
    }

    private void Update()
    {
      
    }
}
