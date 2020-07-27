using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoHoiTangDat : GiaoDien
{
    public override void CapNhap()
    {
        
    }

    public override void LayThongTin()
    {
        
    }

    public override void TatHienThi()
    {
        daTonTai = false;
        if (TheCoHoi.nhanVat.sanDau.HienThiTangDat(TheCoHoi.nhanVat))
        {
            BangThongBao.ThayDoiNoiDung("Chọn ô đất của bạn");
        }
        else
        {
            TheCoHoi.nhanVat.KetThucLuot();
            audioSource.Play();
        }
        TheCoHoi.phaHuy = true;
    }

    
}
