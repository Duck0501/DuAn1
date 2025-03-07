﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DangNhapTaiKhoanDuc : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField passwd;
    public TextMeshProUGUI thongbao;
    public void DangNhapButton()
    {
        StartCoroutine(DangNhap());
    }
    private IEnumerator DangNhap()
    {
        WWWForm dataForm = new WWWForm();
        dataForm.AddField("user", user.text);
        dataForm.AddField("passwd", passwd.text);
        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", dataForm);
        yield return www.SendWebRequest();
        if (!www.isDone)
        {
            print("Kết nối không thành công");
        }
        else if (www.isDone)
        {
            string get = www.downloadHandler.text;
            if (get == "empty")
            {
                thongbao.text = "Vui lòng nhập đầy đủ thông tin đăng nhập";
            }
            else if (get == "" || get == null)
            {
                thongbao.text = "Tài khoản hoặc mật khẩu không chính xác";
            }
            else if (get.Contains("Lỗi"))
            {
                thongbao.text = "Không kết nối được tới server";
            }
            else
            {
                thongbao.text = "Đăng nhập thành công";
                PlayerPrefs.SetString("token", get);
                SceneManager.LoadScene("Home(duc)1");
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
