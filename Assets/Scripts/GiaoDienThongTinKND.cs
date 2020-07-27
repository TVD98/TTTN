using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienThongTinKND : GiaoDien
{
    public static KhuNghiDuong nghiDuong;
    public static Sprite anh;
    public Text ten;
    public Text phiThamQuan;
    public Image backround;

    public override void CapNhap()
    {
        
    }

    public override void LayThongTin()
    {
        ten.text = nghiDuong.ten;
        phiThamQuan.text = nghiDuong.PhiDuLich().ToString();
        backround.sprite = anh;
    }

    public override void TatHienThi()
    {
        PhaHuy();
    }

    public static void ChonDiaDiem(KhuNghiDuong ngD, Sprite a)
    {
        nghiDuong = ngD;
        anh = a;
    }
}
