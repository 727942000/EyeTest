using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour,IObserver
{
    private Text levelText;
    private StringBuilder levelSB;
    // Start is called before the first frame update
    void Start()
    {
        MyGameManager.Instance.AddObserver(eventName.HittheTarget, this);
        levelText = GetComponent<Text>();
        levelSB = new StringBuilder();
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.HittheTarget, this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        PlayerDeadEventArgs playerDeadEventArgs = e as PlayerDeadEventArgs;
        levelSB.Clear();
        levelSB.Append("ตฺ");
        int level = playerDeadEventArgs.flag + 1;
        levelSB.Append(level);
        levelSB.Append("นุ");
        levelText.text = levelSB.ToString();
    }
}
