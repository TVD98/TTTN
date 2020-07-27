using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetQuanTranDau : MonoBehaviour
{
    public string nguoiChienThang;
    public string nguoiThua;
    public KieuThang kieuThang;

    public KetQuanTranDau(string winer, string loser, KieuThang kt)
    {
        this.nguoiChienThang = winer;
        this.nguoiThua = loser;
        kieuThang = kt;
    }

    public string KieuChienThang()
    {
        switch (kieuThang)
        {
            case KieuThang.BOMAU:
                return "Thắng bộ màu";
            case KieuThang.MOTHANG:
                return "Thắng một hàng";
            case KieuThang.PHASAN:
                return "Thắng phá sản";
            case KieuThang.DULICH:
                return "Thắng du lịch";
            default:
                return "Không thắng";
        }
    }

    public string[] ThanhChuoi()
    {
        string[] mangChuoi = new string[3];

        mangChuoi[0] = nguoiChienThang;
        mangChuoi[1] = nguoiThua;
        mangChuoi[2] = KieuChienThang();

        return mangChuoi;
    }
}
