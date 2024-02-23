using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    private Button start;
    void Start()
    {
        start.onClick.AddListener(()=>
        {
            Destroy(this.gameObject);
            GameEventHandler.CallSwitchGameState(GameState.SeletAction);
        });
    }
}
