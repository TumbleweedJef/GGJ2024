using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
   [SerializeField]
   private Button rest;
   [SerializeField]
   private Button welcome;
   private void Start()
   {
      rest.onClick.AddListener(() =>
      {
         PlayerCtrl.Instance.Smoke--;
         PlayerCtrl.Instance.SAN-=5;
         GameEventHandler.CallSwitchGameState(GameState.Smoking);
         GameMain.OnSmoking = true;
      });
      welcome.onClick.AddListener(() =>
      {
         if (!GameMain.OnSmoking)
         {
            GameEventHandler.CallSwitchGameState(GameState.WaitCustomer);
         }
      });
   }

   private void Update()
   {
      rest.gameObject.SetActive(PlayerCtrl.Instance.Smoke>0);
   }
}
