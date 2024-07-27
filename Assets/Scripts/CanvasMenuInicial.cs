﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Febucci.UI;



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

    public Animator animatorTelas, animatorLED;
    public AudioSource audioSource;
    public AudioClip audioEntraTela, audioSaiTela, audioSegundaTela;

    public TextAnimatorPlayer textAnimatorPlayerPessoas, textAnimatorPlayerTecnologia, textAnimatorPlayerProcessos;



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

        AudioSaitela();
        StartCoroutine(EntraTextoTelaPrincipal());
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

        /*
        if(isScreenSaver == false)
        {
            timer += Time.deltaTime;
            if (timer >= 40.0f)
            {
                //PressionaButtonScreenSaver();
            }
        }
        */
    }


    IEnumerator EntraTextoTelaPrincipal()
    {
        textAnimatorPlayerPessoas.ShowText("");
        textAnimatorPlayerTecnologia.ShowText("");
        textAnimatorPlayerProcessos.ShowText("");
        yield return new WaitForSeconds(0.75f);

        textAnimatorPlayerPessoas.ShowText("Pessoas");
        textAnimatorPlayerPessoas.StartShowingText(true);

        textAnimatorPlayerTecnologia.ShowText("Tecnologia");
        textAnimatorPlayerTecnologia.StartShowingText(true);

        textAnimatorPlayerProcessos.ShowText("Processos");
        textAnimatorPlayerProcessos.StartShowingText(true);
    }

    void SaiTextoTelaPrincipal()
    {
        /*
        //textAnimatorPlayerPessoas.StartDisappearingText();
        textAnimatorPlayerPessoas.ShowText("        ");
        textAnimatorPlayerPessoas.StartShowingText(false);
        */
    }


    void AudioEntraTela()
    {
        audioSource.clip = audioEntraTela;
        audioSource.Play();
    }

    void AudioSaitela()
    {
        audioSource.clip = audioSaiTela;
        audioSource.Play();
    }

    void AudioSegundaTela()
    {
        audioSource.clip = audioSegundaTela;
        audioSource.Play();
    }


    //--------------------------------------------------------------
    public void PressionaButtonCapacitacao()
    {
        animatorTelas.SetBool("EntraCapacitacao", true);
        animatorLED.SetBool("EntraCapacitacao", true);
        AudioEntraTela();
    }

    public void PressionaButtonVoltarCapacitacao()
    {
        animatorTelas.SetBool("EntraCapacitacao", false);
        animatorLED.SetBool("EntraCapacitacao", false);
        animatorLED.SetBool("EntraGPTW", false);
        animatorLED.SetBool("EntraFormacao", false);
        AudioSaitela();
        StartCoroutine(EntraTextoTelaPrincipal());
    }

    public void PressionaGPTW()
    {
        animatorLED.SetBool("EntraGPTW", true);
        animatorLED.SetBool("EntraFormacao", false);
        AudioSegundaTela();
    }

    public void PressionaFormacao()
    {
        animatorLED.SetBool("EntraFormacao", true);
        animatorLED.SetBool("EntraGPTW", false);
        AudioSegundaTela();
    }


    //--------------------------------------------------------------
    public void PressionaButtonSuporte()
    {
        animatorTelas.SetBool("EntraSuporte", true);
        animatorLED.SetBool("EntraSuporte", true);
        AudioEntraTela();
    }

    public void PressionaButtonVoltarSuporte()
    {
        animatorTelas.SetBool("EntraSuporte", false);
        animatorLED.SetBool("EntraSuporte", false);
        animatorLED.SetBool("EntraSuporteInterno", false);
        AudioSaitela();
        StartCoroutine(EntraTextoTelaPrincipal());
    }

    public void PressionaSuporteInterno()
    {
        animatorLED.SetBool("EntraSuporteInterno", true);
        AudioSegundaTela();
    }

    //--------------------------------------------------------------
    public void PressionaButtonPrevencao()
    {
        animatorTelas.SetBool("EntraPrevencao", true);
        animatorLED.SetBool("EntraPrevencao", true);
        AudioEntraTela();
    }

    public void PressionaButtonVoltarPrevencao()
    {
        animatorTelas.SetBool("EntraPrevencao", false);
        animatorLED.SetBool("EntraPrevencao", false);
        AudioSaitela();
        StartCoroutine(EntraTextoTelaPrincipal());
    }

    public void PressionaButtonTecnologia()
    {
        animatorTelas.SetBool("EntraTecnologia", true);
        animatorLED.SetBool("EntraTecnologia", true);
        AudioEntraTela();
    }

    public void PressionaButtonVoltarTecnologia()
    {
        animatorTelas.SetBool("EntraTecnologia", false);
        animatorLED.SetBool("EntraTecnologia", false);
        AudioSaitela();
        StartCoroutine( EntraTextoTelaPrincipal());
    }

    public void PressionaButtonLideres()
    {
        animatorTelas.SetBool("EntraLideres", true);
        animatorLED.SetBool("EntraLideres", true);
        AudioEntraTela();
    }

    public void PressionaButtonVoltarLideres()
    {
        animatorTelas.SetBool("EntraLideres", false);
        animatorLED.SetBool("EntraLideres", false);
        AudioSaitela();
        StartCoroutine(EntraTextoTelaPrincipal());
    }

    public void PressionaButtonESG()
    {
        animatorTelas.SetBool("EntraESG", true);
        animatorLED.SetBool("EntraESG", true);
        AudioEntraTela();
    }

    public void PressionaButtonVoltarESG()
    {
        animatorTelas.SetBool("EntraESG", false);
        animatorLED.SetBool("EntraESG", false);
        AudioSaitela();
        StartCoroutine(EntraTextoTelaPrincipal());
    }

    //-----------------------------------------------------------------

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
