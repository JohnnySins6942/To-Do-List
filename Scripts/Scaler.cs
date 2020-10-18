using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaler : MonoBehaviour
{
    public float resoX;
    public float resoY;

    public CanvasScaler can;

    void Start()
    {

        SetInfo();
    }
    public void SetInfo()
    {
        resoX = (float)Screen.currentResolution.width;
        resoY = (float)Screen.currentResolution.height;
        can.referenceResolution = new Vector2(resoX, resoY);
    }

}
