﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DangKyTaiKhoan : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI thongbao;

    public void DangKyButton()
    {
        StartCoroutine(DangKy());
    }

    private IEnumerator DangKy()
    {
        WWWForm from = new WWWForm();
        from.AddField("user", username.text);
        from.AddField("passwd", password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", from);
        yield return www.SendWebRequest();


        if (!www.isDone)
        {
            thongbao.text = "Kết nối không thành công";
        }
        else if (www.isDone)
        {
            string get = www.downloadHandler.text;
            switch (get)
            {
                case "exist": thongbao.text = "Tài khoản đã tồn tại"; break;
                case "OK": thongbao.text = "Đăng ký thành công"; break;
                case "ERROR": thongbao.text = "Đăng ký không thành công"; break;
                default: thongbao.text = "Không kết nối được tới server"; break;
            }
        }
        StartCoroutine(ClearThongBao());
    }
    private IEnumerator ClearThongBao()
    {
        yield return new WaitForSeconds(2);
        thongbao.text = "";
    }
}
