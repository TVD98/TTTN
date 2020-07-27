using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuKienNghiDuong : SuKienBatDau
{
    private int soLuotBiGiam = 0;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        soLuotBiGiam++;
        if (DieuKienThoat())
            nhanVat.suKien = new SuKienDoXucXac();
        ConDao conDao = GameObject.Find("8").GetComponent<ConDao>();
        GiaoDienConDao.ChonNhanVat(nhanVat, SoLuotConLai());
        conDao.HienThi();
    }

    public bool DieuKienThoat()
    {
        if (soLuotBiGiam == 2)
            return true;
        return false;
    }

    public int SoLuotConLai()
    {
        return 3 - soLuotBiGiam;
    }

}
