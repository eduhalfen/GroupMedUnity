using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // Amplitude da flutua��o vertical
    public float floatFrequency = 1f; // Frequ�ncia da flutua��o vertical
    public Vector3 floatAxis = Vector3.up; // Eixo da flutua��o vertical (padr�o � para cima)

    public float horizontalAmplitude = 0.5f; // Amplitude da flutua��o horizontal
    public float horizontalFrequency = 1f; // Frequ�ncia da flutua��o horizontal

    private Vector3 initialPosition;

    void Start()
    {
        // Armazena a posi��o inicial do objeto
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calcula a nova posi��o vertical
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // Calcula a nova posi��o horizontal usando PerlinNoise para suavidade
        float noiseX = Mathf.PerlinNoise(Time.time * horizontalFrequency, 0.0f) * 2 - 1; // Valor entre -1 e 1
        float noiseZ = Mathf.PerlinNoise(0.0f, Time.time * horizontalFrequency) * 2 - 1; // Valor entre -1 e 1
        float horizontalOffsetX = noiseX * horizontalAmplitude;
        float horizontalOffsetZ = noiseZ * horizontalAmplitude;

        // Aplica a nova posi��o
        transform.localPosition = initialPosition + floatAxis * floatOffset + new Vector3(horizontalOffsetX, 0, horizontalOffsetZ);
    }
}
