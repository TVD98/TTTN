using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoHoiHoanDoi : GiaoDien
{
    public static DuLich viTriDoi = null;
    public static DuLich viTriMuonDoi = null;

    public static int soLan = 0;

    public override void CapNhap()
    {

    }

    public override void LayThongTin()
    {
        viTriDoi = null;
        viTriMuonDoi = null;
        soLan = 0;
    }

    public override void TatHienThi()
    {
        daTonTai = false;
        if (TheCoHoi.nhanVat.sanDau.DuocPhepHoanDoi(TheCoHoi.nhanVat))
        {
            BangThongBao.ThayDoiNoiDung("Chọn ô đất của bạn");
            TheCoHoi.nhanVat.sanDau.HienThiViTriDoi(TheCoHoi.nhanVat);
        }
        else TheCoHoi.nhanVat.KetThucLuot();
        TheCoHoi.phaHuy = true;
    }

    public static void ChonVitri(DuLich viTri)
    {
        if (soLan == 0)
            viTriDoi = viTri;
        else viTriMuonDoi = viTri;
        soLan++;
    }

    public static bool HoanThanh()
    {
        if (soLan == 2)
            return true;
        return false;
    }

}
