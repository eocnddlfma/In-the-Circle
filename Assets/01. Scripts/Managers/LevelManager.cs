using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoSingleton<LevelManager>
{
    public UnityEvent<float> KillExpChanged;
    public UnityEvent<float> GrazeExpChanged;
    public UnityEvent<int> GrazeLVChanged;
    public UnityEvent<int> KillLVChanged;
    public UnityEvent LevelUp;
    
    private int KillLevel;
    private int GrazeLevel;
    private int KillExpNeed;
    private int GrazeExpNeed;
    private int KillCurExp;
    private int GrazeCurExp;

    public void AddKillExp(int exp)
    {
        print("here");
        KillCurExp += exp;
        if (KillCurExp > KillExpNeed)
        {
            KillCurExp -= KillExpNeed;
            KillLevel++;
            KillLVChanged?.Invoke(KillLevel);
            LevelUp?.Invoke();
            KillExpNeed *= 2;
        }
        print(KillCurExp/(float)KillExpNeed);
        KillExpChanged?.Invoke(KillCurExp/(float)KillExpNeed);
    }
    
    public void AddGrazeExp(int exp)
    {
        GrazeCurExp += exp;
        if (GrazeCurExp > GrazeExpNeed)
        {
            GrazeCurExp -= GrazeExpNeed;
            GrazeLevel++;
            GrazeLVChanged?.Invoke(GrazeLevel);
            LevelUp?.Invoke();
            GrazeExpNeed += GrazeExpNeed/5;
        }
        GrazeExpChanged?.Invoke(GrazeCurExp/(float)GrazeExpNeed);
    }
    
    void Start()
    {
        StartSetting();
    }

    private void StartSetting()
    {
        KillLevel=0; 
        GrazeLevel= 0; 
        KillExpNeed = 5; 
        GrazeExpNeed = 20; 
        KillCurExp = 0; 
        GrazeCurExp = 0;
        print("asd");
        AddGrazeExp(0);
        AddKillExp(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
