using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowSize : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        RectTransform rectTransform = GetComponent<RectTransform>();
        float x = 0.0f;
        x = rectTransform.parent.parent.GetComponent<GridLayoutGroup>().cellSize.x;
        rectTransform.sizeDelta = new Vector2(x,x);
    }
}
