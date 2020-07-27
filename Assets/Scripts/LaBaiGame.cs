using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaBaiGame : MonoBehaviour
{
    public Image anhNen;

    public bool matSap;
    public Sprite[] cacMat;
    public int giaTri;

    void Start()
    {
        anhNen = GetComponent<Image>();
        HienThi();
    }

    void Update()
    {
        HienThi();
    }

    public void HienThi()
    {
        if (matSap)
            anhNen.sprite = cacMat[0];
        else anhNen.sprite = cacMat[giaTri];
       
    }

    public void LatMat()
    {
        if (GiaoDienChoiGame.duocPhepLat)
        {
            matSap = !matSap;
            GiaoDienChoiGame.soLanLat++;
        }
    }
}
