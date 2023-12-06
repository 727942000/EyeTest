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
                endText.text = "��δ�����������Ҫ�˳�����";
                break;
            case 1:
            case 2:
            case 3:
                endText.text = "�������������ͬ��Ϲ��";
                break;
            case 4:
                endText.text = "�������������ͬ�����������";
                break;
            case 5:
                endText.text = "����������Ե���������";
                break;
            case 6:
                endText.text = "��������ӽ�������";
                break;
            case 7:
                endText.text = "�������������������";
                break;
            default:
                endText.text = "���������Խ������";
                break;
        }
    }

}
