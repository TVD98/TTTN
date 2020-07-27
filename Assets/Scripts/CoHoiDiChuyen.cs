using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoHoiDiChuyen : GiaoDien
{
    public int diemDen;

    public override void CapNhap()
    {
        
    }

    public override void LayThongTin()
    {
 
    }

    public override void TatHienThi()
    {
        daTonTai = false;
        NhanVat_DiChuyen nhanVat = TheCoHoi.nhanVat.gameObject.GetComponent<NhanVat_DiChuyen>();
        TheCoHoi.phaHuy = true;
        nhanVat.viTriKetThuc = diemDen;
        nhanVat.diChuyen = true;
    }

    public void DiemDenDiDong()
    {
        diemDen = LeHoi.diaDiemDangCoLeHoi;
        daTonTai = false;
        if (diemDen >= 0)
        {
            NhanVat_DiChuyen nhanVat = TheCoHoi.nhanVat.gameObject.GetComponent<NhanVat_DiChuyen>();
            TheCoHoi.phaHuy = true;
            nhanVat.viTriKetThuc = diemDen;
            nhanVat.diChuyen = true;
        }
        else
        {
            NhanVat_ThongTin nhanVat = TheCoHoi.nhanVat.gameObject.GetComponent<NhanVat_ThongTin>();
            audioSource.Play();
            TheCoHoi.phaHuy = true;
            nhanVat.KetThucLuot();
        }
    }

}
