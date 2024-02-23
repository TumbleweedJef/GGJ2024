using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SAN : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;
    [SerializeField]
    private Text Text;
    [SerializeField]
    private Text SmokeNum;
    // Update is called once per frame
    void Update()
    {
        int san = PlayerCtrl.Instance.SAN;
        Text.text = $"SAN: {san}";
        Slider.value = san;
        SmokeNum.text=PlayerCtrl.Instance.Smoke.ToString();
    }
}
