using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienMuaBieuTuong : GiaoDien
{
    public static NhanVat_ThongTin nhanVat;
    public static NhaO nhaO;

    public Text phiXayDung;
    public Text giamPhi;
    public Text phiDuLich;
    public Text phiMua;

    public override void CapNhap()
    {
    }

    public override void LayThongTin()
    {
        giamPhi.text = nhanVat.giamPhiXayDung.ToString();
        phiXayDung.text = (nhaO.giaBieuTuong - (nhaO.giaBieuTuong * nhanVat.giamPhiXayDung) / 100).ToString();
        int[] dsPhi = nhaO.DanhSachPhi();
        int tong = 0;
        foreach(int item in dsPhi)
        {
            tong += item;
        }
        phiDuLich.text = tong.ToString();
        phiMua.text = phiXayDung.text;
    }

    public override void TatHienThi()
    {
        PhaHuy();
        nhanVat.KetThucLuot();
    }

    public static void ChonDiaDiem(NhaO no, NhanVat_ThongTin nv)
    {
        nhanVat = nv;
        nhaO = no;
    }

    public void XayBieuTuong()
    {
        nhaO.danhSachNha[4] = 1;
        nhaO.phiDuLich = int.Parse(phiDuLich.text);
        nhanVat.TruTien(int.Parse(phiXayDung.text));
        TatHienThi();
    }

}
