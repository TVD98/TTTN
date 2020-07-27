using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoHoiTangTien : GiaoDien
{
    public int soTien = 200;
    public override void CapNhap()
    {
        
    }

    public override void LayThongTin()
    {
        
    }

    public override void TatHienThi()
    {
        daTonTai = false;
        TheCoHoi.phaHuy = true;
        NhanVat_ThongTin nguoiNhan = Main.LayNhanVat(Main.NguoiChoiTiepTheo(TheCoHoi.nhanVat.stt - 1) + 1);
        nguoiNhan.ThemTien(soTien);
        TheCoHoi.nhanVat.TruTien(soTien);
        TheCoHoi.nhanVat.KetThucLuot();
        
    }

}
