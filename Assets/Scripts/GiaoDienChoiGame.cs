using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienChoiGame : GiaoDien
{
    public static NhanVat_ThongTin nhanVat;
    public static int soLanLat = 0;
    public static bool duocPhepLat = true;

    public LaBaiGame[] cacLaBai;
    public GameObject thongBao;
    public Text soTienNhan;
    public Text luotChoi;
    public int[] mucThuong;
    public AudioClip[] audioClips;
    private bool duocNhanTien = true;
    private int soLanDung = 0;

    public override void CapNhap()
    {
        if (soLanLat == 2)
        {
            duocPhepLat = false;
            soLanLat = 0;
            bool tam = KiemTraKetQua();
            StartCoroutine(HienThiKetQua(tam));
        }
    }

    public override void LayThongTin()
    {
        duocPhepLat = true;
        soLanLat = 0;
        audioSource.clip = audioClips[0];
        audioSource.Play();
        SapXepNgauNhien();
    }

    public override void TatHienThi()
    {
        PhaHuy();
        nhanVat.KetThucLuot();
    }

    public static void ChonNhanVat(NhanVat_ThongTin nv)
    {
        nhanVat = nv;
    }

    public void SapXepNgauNhien()
    {
        int[] ds = TaoDSNgauNhien();
        int[] tam = new int[4] { 1, 1, 2, 2 };
        for (int i = 0; i < 4; i++)
        {
            cacLaBai[i].matSap = true;
            cacLaBai[i].giaTri = tam[ds[i]];
        }
        duocPhepLat = true;
    }

    public int[] TaoDSNgauNhien()
    {
        int[] ds = new int[4];
        int[] dsTham = new int[4] { 0, 0, 0, 0 };
        for (int i = 0; i < 4; i++)
        {
            int tam;
            do
            {
                tam = Random.Range(0, 4);
            } while (dsTham[tam] == 1);
            ds[i] = tam;
            dsTham[tam] = 1;
        }
        return ds;
    }

    public bool KiemTraKetQua()
    {
        int[] cacGiaTri = new int[2] { 0, 3 };
        int dem = 0;
        for (int i = 0; i < 4; i++)
        {
            if (!cacLaBai[i].matSap)
            {
                cacGiaTri[dem] = cacLaBai[i].giaTri;
                dem++;
            }
        }
        if (cacGiaTri[0] == cacGiaTri[1])
        {
            return true;
        }
        return false;
    }

    IEnumerator HienThiKetQua(bool ketQua)
    {
        ThongBaoKetQua(ketQua);
        thongBao.SetActive(true);
        duocNhanTien = false;
        yield return new WaitForSeconds(3f);
        duocNhanTien = true;
        thongBao.SetActive(false);
        TaoManTiepTheo(ketQua);
    }

    public void TaoManTiepTheo(bool ketQua)
    {
        if (ketQua)
        {
            soTienNhan.text = mucThuong[soLanDung].ToString();
            soLanDung++;
            if (soLanDung == 3)
            {
                TatHienThi();
                nhanVat.ThemTien(mucThuong[2]);
            }
            else
            {
                SapXepNgauNhien();
                luotChoi.text = (soLanDung + 1).ToString();
            }
        }
        else TatHienThi();
    }

    public void NhanTien()
    {
        if (duocNhanTien)
        {
            int soTien = int.Parse(soTienNhan.text);
            TatHienThi();
            if (soTien != 0)
                nhanVat.ThemTien(soTien);
        }
    }

    public void ThongBaoKetQua(bool ketQua)
    {
        if (ketQua)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            thongBao.GetComponent<Text>().text = "Chính xác";
        }
        else {
            audioSource.clip = audioClips[2];
            audioSource.Play();
            thongBao.GetComponent<Text>().text = "Sai rồi";
        }
    }
}
