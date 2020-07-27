using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat_DiChuyen : MonoBehaviour
{
    public AudioSource audioSource;

    public int viTriHienTai = 0;
    public bool diChuyen = false;
    readonly float speed = 4f;
    Animator anim;
    public int viTriKetThuc = 7;

    public bool themLuot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        themLuot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(diChuyen == true)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            anim.SetBool("move", true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        VatCan vatCan = other.GetComponent<VatCan>();
        if(vatCan != null)
        {
            int stt = int.Parse(vatCan.name);
            DenDiaDiemMoi(stt);
            if(stt == viTriKetThuc && diChuyen == true)
            {
                BangThongBao.ThayDoiNoiDung("");
                diChuyen = false;
                audioSource.Stop();
                anim.SetBool("move", false);
                NhanSuKien();
            }
        }
    }

    private void DenDiaDiemMoi(int viTri)
    {
        viTriHienTai = viTri;
        if(viTri % 8 == 0 && diChuyen == true)
        {
            transform.Rotate(0, 90, 0, Space.Self);
        }
        if (viTri == 0 && diChuyen == true)
        {
            TangVong();
        }
    }

    private void NhanSuKien()
    {
        GameObject diaDiem = GameObject.Find(viTriHienTai.ToString());
        DiaDiem script = diaDiem.GetComponent<DiaDiem>();
        script.PhatSuKien(GetComponent<NhanVat_ThongTin>());
    }

    private void TangVong()
    {
        NhanVat_ThongTin nhanVat = GetComponent<NhanVat_ThongTin>();
        nhanVat.soVong++;
        DiemXuatPhat xuatPhat = GameObject.Find("0").GetComponent<DiemXuatPhat>();
        xuatPhat.TangVong(nhanVat);
    }

}
