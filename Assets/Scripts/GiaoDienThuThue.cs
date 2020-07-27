using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienThuThue : GiaoDien
{

    public static NhanVat_ThongTin nhanVat;
    public static int tienThue;

    public Text thuePhaiTra;
    public Text giamThue;
    public Text soTienConLai;
    public Text phiThue;

    public override void CapNhap()
    {
        
    }

    public override void LayThongTin()
    {
        audioSource.Play();
        thuePhaiTra.text = tienThue.ToString();
        phiThue.text = thuePhaiTra.text;
    }

    public override void TatHienThi()
    {
        PhaHuy();
        nhanVat.TruTien(int.Parse(phiThue.text));
        nhanVat.KetThucLuot();
    }

    public static void ChonNhanVat(NhanVat_ThongTin nv, int thue)
    {
        nhanVat = nv;
        tienThue = thue;
    }

    public void TraThue()
    {
        TatHienThi();
    }

    
}
