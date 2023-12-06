using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayOutCtrl : MonoBehaviour,IObserver
{
    private GridLayoutGroup GLG;
    // Start is called before the first frame update
    void Start()
    {
        int num;
        MyGameManager.Instance.AddObserver(eventName.HittheTarget, this);
        GLG = GetComponent<GridLayoutGroup>();
        float x, y;
        num = AllCtrl.cubeNum[0];
        x = 1000 / num;
        y = x;
        GLG.cellSize = new Vector2(x,y);
        GLG.constraintCount = num;
    }
    private void OnDisable()
    {
        MyGameManager.Instance.RemoveObserver(eventName.HittheTarget,this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        OnChick((PlayerDeadEventArgs)e);
    }
    public void OnChick(PlayerDeadEventArgs e)
    {
        int num;
        float x, y;
        num = AllCtrl.cubeNum[e.flag];
        x = 1000 / num;
        y = x;
        GLG.cellSize = new Vector2(x, y);
        GLG.constraintCount = num;
    }

    // Update is called once per frame
}
