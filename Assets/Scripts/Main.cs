using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static GameObject[] danhSachNhanVat;
    public static int stt = 0;
    public static bool sanSanBatDau = false;
    private int sttTruoc = 0;

    public BoXucXac boXucXac;

    public GameObject panelThongBao;
    public GameObject panelTamDung;
    public GameObject panelWin;
    public static bool ketThuc = false;
    public static string nguoiChienThang = "";
    public static KieuThang kieuWin;

    public Text[] tenCacNhanVat;
    public InputField[] cacFiledNhap;
    public Button xacNhan;

    void Start()
    {
        stt = 0;
        danhSachNhanVat = GameObject.FindGameObjectsWithTag("NhanVat");
        cacFiledNhap[0].Select();
        KiemTraNhap();

        LeHoi.diaDiemDangCoLeHoi = -1;
    }

    void Update()
    {
        if (ketThuc)
        {
            StartCoroutine(HienThiGiaoDienWin());
        }
        if (stt != sttTruoc)
        {
            sttTruoc = stt;
            NhanVat_ThongTin nhanVat = LayNhanVat(stt + 1).GetComponent<NhanVat_ThongTin>();
            nhanVat.BatDauLuot();
        }
        if (Input.GetKey(KeyCode.Escape) && sanSanBatDau)
        {
            panelTamDung.SetActive(true);
            panelThongBao.SetActive(false);
        }
    }

    public void ThayDoiLuot()
    {
        stt = NguoiChoiTiepTheo(stt);
    }

    public static int NguoiChoiTiepTheo(int hienTai)
    {
        int soLuong = danhSachNhanVat.Length;
        if (hienTai == soLuong - 1)
        {
            return 0;
        }
        return hienTai + 1;
    }

    public static int TimViTriKetThuc(int viTriHienTai, int soNutXucXac)
    {
        int tong = viTriHienTai + soNutXucXac;
        if (tong <= 31) return tong;
        else return (tong - 32);
    }

    public static NhanVat_ThongTin LayNhanVat(int stt)
    {
        return danhSachNhanVat[stt - 1].GetComponent<NhanVat_ThongTin>();
    }

    public static void KetThucGame(string ten, KieuThang kieuThang)
    {
        nguoiChienThang = ten;
        kieuWin = kieuThang;
        ketThuc = true;
    }

    public void CapNhapTen()
    {
        for(int i = 0; i < 2; i++)
        {
            tenCacNhanVat[i].text = cacFiledNhap[i].text;
            danhSachNhanVat[i].GetComponent<NhanVat_ThongTin>().ten = cacFiledNhap[i].text;
        }
        sanSanBatDau = true;
        sttTruoc = -1;
    }

    public void KiemTraNhap()
    {
        if (string.IsNullOrEmpty(cacFiledNhap[0].text) || string.IsNullOrEmpty(cacFiledNhap[1].text))
            xacNhan.interactable = false;
        else xacNhan.interactable = true;
    }

    IEnumerator HienThiGiaoDienWin()
    {
        panelThongBao.SetActive(false);
        sanSanBatDau = false;
        GiaoDienKetThuc.ten = nguoiChienThang;
        GiaoDienKetThuc.kieuWin = kieuWin;
        ketThuc = false;
        yield return new WaitForSeconds(1f);
        panelWin.SetActive(true);
    }

    public void TroVeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
}
