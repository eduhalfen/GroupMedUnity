using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;




public static class Const
{
    public const float KDELAY_ANIM = 0.5f;
}


public class CanvasMenuInicial : MonoBehaviour
{
    public GameObject Canvas02, Camera02;

    public int contadorEmergencia = 0;
    public float timerEmergencia = 0.0f;
    public float timer = 0.0f;

    public RectTransform RectTransformSafeArea;

    bool isScreenSaver = false;





    private void Start()
    {
        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        RectTransformSafeArea.anchorMin = anchorMin;
        RectTransformSafeArea.anchorMax = anchorMax;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            for (int i = 1; i < Display.displays.Length; i++)
            {
                Display.displays[i].Activate();
            }
        }

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Canvas02.SetActive(true);
            Camera02.SetActive(true);

        }
        else
        {
            Canvas02.SetActive(false);
            Camera02.SetActive(false);

        }

        PlayerPrefs.SetInt("Bloco", 0);
    }




    void Update()
    {
        if (contadorEmergencia >= 1)
        {
            timerEmergencia += Time.deltaTime;
        }

        if (timerEmergencia >= 10.0f)
        {
            contadorEmergencia = 0;
            timerEmergencia = 0.0f;
        }
        
        if(isScreenSaver == false)
        {
            timer += Time.deltaTime;
            if (timer >= 40.0f)
            {
                PressionaButtonScreenSaver();
            }
        }
        
    }



    public void PressionaButtonLocalizacao()
    {
        SceneManager.UnloadSceneAsync("MenuInicial");
        SceneManager.LoadSceneAsync("Localizacao");
    }


    public void PressionaButtonBairroNovaCaxias()
    {
        SceneManager.UnloadSceneAsync("MenuInicial");
        SceneManager.LoadSceneAsync("BairroNovaCaxias");
    }

    public void PressionaButtonNovaCaxiasFun()
    {
        SceneManager.UnloadSceneAsync("MenuInicial");
        SceneManager.LoadSceneAsync("NovaCaxiasFun");
    }

    public void PressionaButtonScreenSaver()
    {
        SceneManager.UnloadSceneAsync("MenuInicial");
        SceneManager.LoadSceneAsync("Filme");
    }



    public void PressionaButtonEmergencia()
    {
        contadorEmergencia++;
        if (contadorEmergencia >= 4)
        {
            print("Saida de Emergencia");
            Application.Quit();
        }
    }



    public void PressionaButtonEmergenciaSimples()
    {
        print("Saida de Emergencia");
        Application.Quit();

    }







}
