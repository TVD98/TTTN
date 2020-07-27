using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BangHuongDan : MonoBehaviour
{
    public Text trangHienTai;

    public Button button_Next;
    public Button button_Back;

    public Sprite[] anhHuongDan;
    public Image anhHienThi;

    private int maxTrang = 15;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SangTrang()
    {
        int trang = int.Parse(trangHienTai.text);
        trang++;
        trangHienTai.text = trang.ToString();
        KiemTraButton();
    }

    public void LuiTrang()
    {
        int trang = int.Parse(trangHienTai.text);
        trang--;
        trangHienTai.text = trang.ToString();
        KiemTraButton();
    }

    public void KiemTraButton()
    {
        int trang = int.Parse(trangHienTai.text);
        anhHienThi.sprite = anhHuongDan[trang - 1];
        if (trang == 1)
            button_Back.interactable = false;
        else button_Back.interactable = true;
        if (trang == maxTrang)
            button_Next.interactable = false;
        else button_Next.interactable = true;
    }
}
