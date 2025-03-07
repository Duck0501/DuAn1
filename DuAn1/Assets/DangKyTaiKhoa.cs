using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DangKyTaiKhoa : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField passwd;
    public TextMeshProUGUI ThongBao;
    #region
    public void DangKyButton()
    {
        StartCoroutine(DangKy());
    }

    IEnumerator DangKy()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user.text);
        form.AddField("passwd", passwd.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", form);

        yield return www.SendWebRequest();

        if(!www.isDone)
        {
            ThongBao.text = "Kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;

            switch(get)
            {
                case "exist":
                    ThongBao.text = "Tài khoản đã tồn tại!";
                    break;
                case "OK":
                    ThongBao.text = "Đăng ký thành công!";
                    break;
                case "ERROR":
                    ThongBao.text = "Đăng ký không thành công!";
                    break;
                default: ThongBao.text = "Không kết nối được sever";
                    break;
            }
        }
    }
#endregion
    #region Đăng Nhập
    public void DangNhapButton()
    {
        StartCoroutine(DangNhap());
    }
    IEnumerator DangNhap()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user.text);
        form.AddField("passwd", passwd.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            ThongBao.text = "Kết nối thành công";
        }
        else
        {
            string get = www.downloadHandler.text;
            if (get == "empty")
            {
                ThongBao.text = "Các trường giữ liệu không được để trống";
            }
            else if (get == "" || get == null)
            {
                ThongBao.text = "Tài khoản hoặc mật khẩu không đúng";
            }
            else if (get.Contains("Lỗi"))
            {
                ThongBao.text = "Không kết nối được sever";
            }
            else
            {
                ThongBao.text = "Đăng nhập thành công";
                PlayerPrefs.SetString("token", get);
                Debug.Log(get);
                string tk = PlayerPrefs.GetString("token");
            }
        }
    }
    #endregion
}
