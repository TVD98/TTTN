using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToChucLeHoi : SuKienChuotTrai
{
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        diaDiem.suKien = new KhongLamGi();
        DuLich duLich = (DuLich)diaDiem;
        NhanVat_ThongTin nhanVat = Main.LayNhanVat(duLich.thuocNguoiChoi).GetComponent<NhanVat_ThongTin>();
        int stt = int.Parse(duLich.name);
        if (stt != LeHoi.diaDiemDangCoLeHoi)
        {
            nhanVat.sanDau.HuyToChucLeHoi();
        }
        duLich.ToChucLeHoi();
        LeHoi.diaDiemDangCoLeHoi = stt;

        nhanVat.KetThucLuot();

    }
}
