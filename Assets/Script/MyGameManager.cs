using System;
using System.Collections.Generic;

public class MyGameManager
{
    //单例模式
    private static MyGameManager instance;
    public static MyGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MyGameManager();
            }
            return instance;
        }
    }
    private Dictionary<string, List<IObserver>> observerDic = new Dictionary<string, List<IObserver>>();

    //添加观察者
    public void AddObserver(string eventName,IObserver observer)
    {
        if (observerDic.ContainsKey(eventName))
        {
            observerDic[eventName].Add(observer);
        }
        else
        {
            observerDic.Add(eventName, new List<IObserver> { observer });
        }
    }
    //移除
    public void RemoveObserver(string eventName,IObserver observer)
    {
        if (observerDic.ContainsKey(eventName))
        {
            observerDic[eventName].Remove(observer);
        }
    }
    //发送通知
    public void Notify(string eventName,EventArgs e)
    {
        if (observerDic.ContainsKey(eventName))
        {
            foreach(var ob in observerDic[eventName]){
                ob.ResponseToNotify(e);
            }
        }
    }


}
