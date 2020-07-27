using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienChuyenNhuong : GiaoDien
{
    public static NhanVat_ThongTin nhanVatBan;
    public static NhanVat_ThongTin nhanVatMua;
    public static NhaO nhaO;

    public Text phiChuyenNhuong;
    public Text phiDuLich;
    public Text phiMua;

    public static void ChonDiaDiem(NhanVat_ThongTin ban, NhanVat_ThongTin mua, NhaO n)
    {
        nhanVatBan = ban;
        nhanVatMua = mua;
        nhaO = n;
    }

    public void Mua()
    {
        int tien = int.Parse(phiMua.text);
        nhanVatBan.ThemTien(tien);
        nhanVatMua.TruTien(tien);
        nhaO.DoiQuyenSoHuu(nhanVatMua.stt);

        PhaHuy();

        nhaO.XuLiSoHuu(nhanVatMua);
    }

    public override void LayThongTin()
    {
        audioSource.Play();
        phiChuyenNhuong.text = nhaO.PhiChuyenNhuong().ToString();
        phiDuLich.text = nhaO.phiDuLich.ToString();
        phiMua.text = phiChuyenNhuong.text;
    }

    public override void CapNhap()
    {
        
    }

    public override void TatHienThi()
    {
        PhaHuy();
        nhanVatMua.KetThucLuot();
    }

}
