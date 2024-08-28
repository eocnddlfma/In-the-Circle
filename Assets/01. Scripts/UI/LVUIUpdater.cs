using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LVUIUpdater : MonoBehaviour
{
    private Image KillBar;
    private Image GrazeBar;
    private TextMeshProUGUI KillText;
    private TextMeshProUGUI GrazeText;

    private void Awake()
    {
        GameObject KillUI = GameObject.Find("KillLVUI");
        //GameObject GrazeUI = GameObject.Find("GrazeLVUI");
        KillBar = KillUI.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        KillText = KillUI.transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        //GrazeBar = GrazeUI.transform.Find("CurExpBar").GetComponent<Image>();
        //GrazeText = GrazeUI.transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        LevelManager.Instance.KillExpChanged.AddListener(UpdateKillUI);  
        LevelManager.Instance.GrazeExpChanged.AddListener(UpdateGrazeUI); 
        LevelManager.Instance.KillLVChanged.AddListener((value) =>
        {
            KillText.text = "KLV " + value.ToString();
        }); 
        LevelManager.Instance.GrazeLVChanged.AddListener((value) =>
        {
            GrazeText.text = "GLV " + value.ToString();
        }); 
    }

    void UpdateKillUI(float value)
    {
        print(value);
        KillBar.fillAmount = value;
    }
    void UpdateGrazeUI(float value)
    {
        GrazeBar.fillAmount = value;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
