using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndPanelCtrl : MonoBehaviour
{
    private Text endText;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        endText = GetComponent<Text>();
        level = AllCtrl.levelIndex;
        switch (level)
        {
            case 0:
                endText.text = "尚未测出视力，就要退出了吗";
                break;
            case 1:
            case 2:
            case 3:
                endText.text = "你的视力基本等同于瞎子";
                break;
            case 4:
                endText.text = "你的视力基本等同于鼹鼠的视力";
                break;
            case 5:
                endText.text = "你的视力明显低于正常人";
                break;
            case 6:
                endText.text = "你的视力接近正常人";
                break;
            case 7:
                endText.text = "你的视力是正常人视力";
                break;
            default:
                endText.text = "你的视力超越正常人";
                break;
        }
    }

}
