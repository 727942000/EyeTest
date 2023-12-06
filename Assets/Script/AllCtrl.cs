//using Microsoft.Unity.VisualStudio.Editor;
using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.Collections.LowLevel.Unsafe;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UI;

public class AllCtrl : MonoBehaviour,IObserver
{
    private static AllCtrl instance;
    public static AllCtrl Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new AllCtrl();
            }
            return instance;
        }
    }

    public static int[] cubeNum = { 2,3,4,5,5,6,6,7,7,7,8,8,8,8,8,8,9,9,9,9,9,9,9,9,10,10,10,10,10,10,10,10,10,10 };
    private float[] levels = { (205 / 255.0f), (215 / 255.0f), (225 / 255.0f), (235 / 255.0f), (245 / 255.0f) ,(250 / 255.0f), (250 / 255.0f), (252 / 255.0f), (252 / 255.0f) };
    public static int levelIndex = 0;
    public GameObject preFab;
    public Transform parent;
    public static int flag = 0;
    public Color[] colors;
    private System.Random random = new System.Random();
    private int colorIndex = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        colorIndex = -1;
        MyGameManager.Instance.AddObserver(eventName.HittheTarget, this);
        UpdateGame(new PlayerDeadEventArgs { flag = AllCtrl.flag} );
        
    }

    private void OnDisable()
    {
        MyGameManager.Instance.RemoveObserver(eventName.HittheTarget,this);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MyGameManager.Instance.Notify(eventName.PlayerDead, EventArgs.Empty);
        }
    }

    // Update is called once per frame
    public void ResponseToNotify(EventArgs e)
    {
        UpdateGame((PlayerDeadEventArgs)e);
    }
    public void ChickOut()
    {
        MyGameManager.Instance.Notify(eventName.HittheTarget, new PlayerDeadEventArgs { playerName = null, flag = ++AllCtrl.flag });
    }
    private void UpdateGame(PlayerDeadEventArgs e )
    {
        levelIndex = LevelChoose(e.flag);
        if(e.flag >= cubeNum.Length)
        {
            MyGameManager.Instance.Notify(eventName.PlayerDead, EventArgs.Empty);
            return;
        }
        int length = cubeNum[e.flag];
        int target = random.Next(0, length * length);
        //相邻两次颜色不相同
        while (true)
        {
            int temp = random.Next(0, 9);
            if(temp != colorIndex)
            {
                colorIndex = temp;
                break;
            }
        }
        
        Debug.Log(target);
        for (int i = 0; i < length * length; i++)
        {
            GameObject go = Instantiate(preFab, parent);  //新建一个物体
            //上色
            UnityEngine.UI.Image[] imgs = go.GetComponentsInChildren<UnityEngine.UI.Image>();
            float x, y, z, w;
            x = colors[colorIndex].r;
            y = colors[colorIndex].g;
            z = colors[colorIndex].b;
            w = colors[colorIndex].a;
            //选中一个作为目标
            if (i == target)
            {
                go.tag = "Player";
                w = colors[colorIndex].a * levels[levelIndex]; 
            }
            imgs[imgs.Length - 1].color = new Color(x, y, z, w);
        }
    }
    private int LevelChoose(int index)
    {
        int level = 0;
        if(index == 0)
        {
            level = 0;
        }
        else if(index >= 0 && index < 3)
        {
            level = 1;
        }
        else if(index >= 3 && index < 5)
        {
            level = 1;
        }
        else if(index >= 5 && index < 7)
        {
            level = 2;
        }
        else if(index >= 7 && index < 10)
        {
            level = 3;//基本等同于瞎子
        }
        else if (index >= 10 && index < 16)
        {
            level = 4;//鼹鼠的视力
        }
        else if (index >= 16 && index < 20)
        {
            level = 5;//明显低于正常人
        }
        else if (index >= 20 && index < 24)
        {
            level = 6;//接近正常人
        }
        else if(index >=24 && index <= 29)
        {
            level = 7;//正常人视力
        }
        else if(index >= 29 && index <= 34)
        {
            level = 8;//超越正常人
        }
        else
        {
            level = 9;//视力超神了！！！
        }
        return level;
    }
}
