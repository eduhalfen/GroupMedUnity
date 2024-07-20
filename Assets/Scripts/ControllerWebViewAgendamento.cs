using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ControllerWebViewAgendamento : MonoBehaviour
{
    // Start is called before the first frame update

    UniWebView webView;
    string  link;

    void Start()
    {
        link = "http://eduhalfen-001-site7.itempurl.com/calendario-casa-pedra/";



        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();


        webView.Frame = new Rect(0, 160, Screen.width, Screen.height - 160);
        //webView.BackgroundColor = new Color(0.9058824f, 0.8196079f, 0.6862745f, 1.0f);

        webView.Load(link);
        //webView.Show();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
