using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public TextMeshProUGUI thongbao;

    public void Batdau()
    {
        if (thongbao.text == "Đăng nhập thành công")
        {
            SceneManager.LoadScene("Map Start");
        }
        else
        {
            thongbao.text = "Bạn vui lòng đăng nhập";
        }
    }
}
