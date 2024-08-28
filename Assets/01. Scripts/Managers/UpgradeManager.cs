using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoSingleton<UpgradeManager>
{
    [SerializeField] private GameObject UpgradeCanvas;

    public UpgradeItemRenderer ClickableUpgradeUI1;
    public UpgradeItemRenderer ClickableUpgradeUI2;
    public UpgradeItemRenderer ClickableUpgradeUI3;
    public List<UpgradeItemRenderer> ClickableUpgradeUIs;
    
    protected override void Awake()
    {
        base.Awake();
        LevelManager.Instance.LevelUp.AddListener(ShowCanvas);

        ClickableUpgradeUI1 = GameObject.Find("UpgradeOne").GetComponent<UpgradeItemRenderer>();
        ClickableUpgradeUI2 = GameObject.Find("UpgradeTwo").GetComponent<UpgradeItemRenderer>();
        ClickableUpgradeUI3 = GameObject.Find("UpgradeThree").GetComponent<UpgradeItemRenderer>();

        ClickableUpgradeUIs = new List<UpgradeItemRenderer>
            { ClickableUpgradeUI1, ClickableUpgradeUI2, ClickableUpgradeUI3 };
        
        UpgradeCanvas.SetActive(false);
    }
    
    public void ShowCanvas()
    {
        UpgradeCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseCanvas()
    {
        Time.timeScale = 1;
        UpgradeCanvas.SetActive(false);
    }
    
}
