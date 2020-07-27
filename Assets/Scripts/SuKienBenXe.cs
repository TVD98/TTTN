using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuKienBenXe : SuKienBatDau
{
    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        BangThongBao.ThayDoiNoiDung("Chọn địa điểm muốn đến");
        nhanVat.sanDau.PhatAmThanh();
        nhanVat.sanDau.HienThiBenXe();
    }
}
