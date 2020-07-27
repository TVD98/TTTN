using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoHoiBanNha : GiaoDien
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
        
        if (TheCoHoi.nhanVat.sanDau.HienThiBanNha(TheCoHoi.nhanVat))
        {
            BangThongBao.ThayDoiNoiDung("Chọn địa điểm bạn\nmuốn tấn công");
        }
        else
        {
            TheCoHoi.nhanVat.KetThucLuot();
        }
        TheCoHoi.phaHuy = true;
    }

   
}
