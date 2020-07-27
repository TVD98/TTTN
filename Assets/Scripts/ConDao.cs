using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConDao : ChucNang
{
    public GameObject giaoDienConDao;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        NhanVat_DiChuyen nhanVatDiChuyen = nhanVat.gameObject.GetComponent<NhanVat_DiChuyen>();
        nhanVatDiChuyen.themLuot = false;
        nhanVat.suKien = new SuKienNghiDuong();
        nhanVat.KetThucLuot();
    }

    public void HienThi()
    {
        Instantiate(giaoDienConDao);
    }

}
