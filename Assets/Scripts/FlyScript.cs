using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;





public class FlyScript : MonoBehaviour
{
    public float speed = 1.5f;

    public float range = 50.0f;
    public float fatorDistancia = 5.0f;

    Vector3 newPosition , oldPosition, oldNewPosition;
    float timer = 0.0f;
    float fatorVelocidade;



    void Start()
    {
        //PositionChange();
        CalculaPosition();
    }

    void PositionChange()
    {

        newPosition = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
        Debug.Log("New Position: " + newPosition.x + "," + newPosition.y);
    }

    void Update()
    {
        if (Vector3.Distance(transform.localPosition, newPosition) < fatorDistancia)
        {
            //PositionChange();
            CalculaPosition();
        }

        timer = Time.deltaTime;

        //transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, timer * speed);
        //transform.localPosition = Vector3.Slerp(transform.localPosition, newPosition, Time.deltaTime * speed);
        transform.Translate((newPosition - transform.localPosition) * fatorVelocidade * Time.deltaTime);

    }


    void CalculaPosition()
    {
        oldPosition = transform.localPosition;
        //oldNewPosition = newPosition;

        float randomAngle = Random.Range(0, 360);

        float newX = Mathf.Cos(randomAngle) * range;
        float newY = Mathf.Sin(randomAngle) * range;

        newPosition = new Vector3(newX, newY, 0);
        Debug.Log("New Position: " + newPosition.x + "," + newPosition.y);

        float distanciaNova = Vector3.Distance(oldPosition, newPosition);
        Debug.Log("distanciaNova: " + distanciaNova);

        float tempoDuracao = distanciaNova / (speed * 10);
        Debug.Log("tempoDuracao: " + tempoDuracao);

        fatorVelocidade = 1.0f;
        //transform.DOLocalMove(newPosition, tempoDuracao).SetEase(Ease.InOutSine);
    }



}
