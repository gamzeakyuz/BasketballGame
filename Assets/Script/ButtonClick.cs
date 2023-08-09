using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    //uygulamadan çıkış işlemi
    public void Exit()
    {
        Debug.Log("Uygulamadan çıkış yapıldı");
        Application.Quit();
    }
    //anasayfaya geçiş işlemi
    public void Anasayfa()
    {
        SceneManager.LoadScene("MainScene");
    }
    //oyun sayfasına geçiş işlemi
    public void OyunSayfasi()
    {
        SceneManager.LoadScene("GameScene");
    }
}
