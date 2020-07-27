using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenNoiTuyY : SuKienChuotTrai
{
    // Start is called before the first frame update
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        BangThongBao.ThayDoiNoiDung("");

        NhanVat_DiChuyen nhanVatDC = Main.LayNhanVat(Main.stt + 1).GetComponent<NhanVat_DiChuyen>();
        nhanVatDC.viTriKetThuc = int.Parse(diaDiem.name);
        nhanVatDC.diChuyen = true;
        
        NhanVat_ThongTin nhanVatTT = Main.LayNhanVat(Main.stt + 1).GetComponent<NhanVat_ThongTin>();
        nhanVatTT.suKien = new SuKienDoXucXac();
        nhanVatTT.sanDau.TraVeMacDinh();
    }
}
