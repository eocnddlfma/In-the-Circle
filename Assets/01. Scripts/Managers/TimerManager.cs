using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float leftTime;
    void Start()
    {
        leftTime = 10 * 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = string.Format("{0:D2}:{1:D2}", (int)leftTime/60, (int)leftTime%60);
        leftTime -= Time.deltaTime;
        if (leftTime <= 0) SceneManager.LoadScene(2);
    }
}
