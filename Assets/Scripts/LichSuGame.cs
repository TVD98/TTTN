using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LichSuGame : MonoBehaviour
{
    public GameObject cacKetQua;

    public static List<KetQuanTranDau> cacKetQuaGame = new List<KetQuanTranDau>();

    private void Start()
    {

    }

    private void Update()
    {
        HienThi();
    }

    public static void ThemKetQua(KetQuanTranDau ketQua)
    {
        int soTranDau = cacKetQuaGame.Count;

        if(soTranDau == 10)
        {
            cacKetQuaGame.RemoveAt(0);
            cacKetQuaGame.Add(ketQua);
        }
        else
        {
            cacKetQuaGame.Add(ketQua);
        }
    }

    public void HienThi()
    {
        int soTranDau = cacKetQuaGame.Count;

        int i = 0;
        foreach(Transform ketQua in cacKetQua.transform)
        {
            int j = 0;
            if (i+1 > soTranDau)
            {
                foreach (Transform item in ketQua)
                {
                    Text text = item.GetComponent<Text>();
                    text.text = "";
                    j++;
                }
            }
            else
            {
                string[] mangChuoi = cacKetQuaGame[i].ThanhChuoi();
                foreach(Transform item in ketQua)
                {
                    Text text = item.GetComponent<Text>();
                    text.text = mangChuoi[j];
                    j++;
                }
            }
            i++;
        }
    }



}
