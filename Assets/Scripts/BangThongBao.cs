using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BangThongBao : MonoBehaviour
{
    public Text noiDung;
    public GameObject panel;
    public static string noiDungMoi = "";
    public static bool thayDoi = false;

    void Update()
    {
        if(noiDung.text == "")
        {
            panel.gameObject.SetActive(false);
        }
        else panel.gameObject.SetActive(true);
        if (thayDoi)
        {
            noiDung.text = noiDungMoi;
            thayDoi = false;
        }
    }

    public static void ThayDoiNoiDung(string text)
    {
        noiDungMoi = text;
        thayDoi = true;
    }


}
