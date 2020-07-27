using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuKienDoXucXac : SuKienBatDau
{
    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        BangThongBao.ThayDoiNoiDung("Nhấn phím cách để\nđổ xúc xắc");
        BoXucXac.duocDoXucXac = true;
    }
}
