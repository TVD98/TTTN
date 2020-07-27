using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienThongTinCN : GiaoDien
{
    public static ChucNang chucNang;

    public Text ten;
    public Image image;

    public static void ChonDiaDiem(ChucNang cN)
    {
        chucNang = cN;
    }

    public override void CapNhap()
    {
        
    }

    public override void LayThongTin()
    {
        ten.text = chucNang.ten;
        image.sprite = chucNang.sprite;
    }

    public override void TatHienThi()
    {
        PhaHuy();
    }
}
