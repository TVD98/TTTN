using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GiaoDienKetThuc : MonoBehaviour
{
    public static string ten;
    public static KieuThang kieuWin;


    public Text nguoiThang;
    public Text kieuThang;

    void Update()
    {
        if(kieuWin != KieuThang.KHONG)
        {
            HienThi();
        }
    }

    public void HienThi()
    {
        nguoiThang.text = ten + " Win";
        if (kieuWin == KieuThang.DULICH)
            kieuThang.text = "Chiến thắng sở hữu 5 du lịch";
        else if(kieuWin == KieuThang.BOMAU)
            kieuThang.text = "Chiến thắng sở hữu 3 bộ màu";
        else if (kieuWin == KieuThang.MOTHANG)
            kieuThang.text = "Chiến thắng sở hữu 1 hàng";
        else kieuThang.text = "Chiến thắng đối phương phá sản";

    }

    public void TroVeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
