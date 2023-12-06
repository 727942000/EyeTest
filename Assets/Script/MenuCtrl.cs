using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour,IObserver
{
    public GameObject startPanel;
    public GameObject endPanel;
    // Start is called before the first frame update
    void Start()
    {
        MyGameManager.Instance.AddObserver(eventName.PlayerDead,this);
        Time.timeScale = 0;
    }
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.PlayerDead, this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        EndGame();
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        startPanel.SetActive(false);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
