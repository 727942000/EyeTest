using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour,IObserver
{
    private Text timerText;
    private float timer = 61;
    private StringBuilder timerSB;
    public float seconds = 1;
    // Start is called before the first frame update
    void Start()
    {
        timer = 61;
        MyGameManager.Instance.AddObserver(eventName.HittheTarget, this);
        timerText = GetComponent<Text>();
        timerSB = new StringBuilder();
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.HittheTarget, this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        timer += seconds;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        timerSB.Clear();
        timerSB.Append((int)timer);
        timerText.text = timerSB.ToString();
        if(timer <= 0)
        {
            MyGameManager.Instance.Notify(eventName.PlayerDead,EventArgs.Empty);
            
        }
    }
}
