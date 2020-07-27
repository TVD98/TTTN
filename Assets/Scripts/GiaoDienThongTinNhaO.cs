using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienThongTinNhaO : GiaoDien
{
    public Text ten;
    public Text[] danhSachGia;
    public Text phiChuyenNhuong;
    public Text phiDuLich;

    public static NhaO nhaO;

    // Update is called once per frame

    public static void ChonDiaDiem(NhaO nO)
    {
        nhaO = nO;
    }

    public override void LayThongTin()
    {
        int[] tam = nhaO.DanhSachPhi();
        ten.text = nhaO.ten;
        if(nhaO.danhSachNha[4] == 1)
        {
            phiChuyenNhuong.text = "Không thể mua lại";
        }
        else phiChuyenNhuong.text = nhaO.PhiChuyenNhuong().ToString();
        phiDuLich.text = nhaO.PhiDuLich().ToString();
        for (int i = 0; i < 5; i++)
        {
            danhSachGia[i].text = tam[i].ToString();
        }
    }

    public override void CapNhap()
    {
        
    }

    public override void TatHienThi()
    {
        PhaHuy();
    }
}
