using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour,IObserver
{
    // Start is called before the first frame update
    void Start()
    {
        MyGameManager.Instance.AddObserver(eventName.HittheTarget, this);
        MyGameManager.Instance.AddObserver(eventName.PlayerDead, this);
    }
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.HittheTarget, this);
        MyGameManager.Instance.RemoveObserver(eventName.PlayerDead, this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        Destroy(gameObject);
    }
    public void ChickOut()
    {
        if (gameObject.CompareTag("Player"))
        {
            AllCtrl.Instance.ChickOut();
        }
    }
}
