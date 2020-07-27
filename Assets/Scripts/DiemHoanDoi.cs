using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiemHoanDoi : SuKienChuotTrai
{
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        TheCoHoi.nhanVat.sanDau.TraVeMacDinh();
        CoHoiHoanDoi.ChonVitri(diaDiem.gameObject.GetComponent<DuLich>());
        if (CoHoiHoanDoi.HoanThanh())
        {
            CoHoiHoanDoi.viTriDoi.DoiQuyenSoHuu(CoHoiHoanDoi.viTriMuonDoi.thuocNguoiChoi);
            CoHoiHoanDoi.viTriMuonDoi.DoiQuyenSoHuu(TheCoHoi.nhanVat.stt);
            TheCoHoi.nhanVat.KetThucLuot();
        }
        else
        {
            Debug.Log("Chua xong");
            BangThongBao.ThayDoiNoiDung("Chọn ô đất bạn\nmuốn đổi");
            TheCoHoi.nhanVat.sanDau.HienThiViTriMuonDoi(TheCoHoi.nhanVat);
        }
    }
}
