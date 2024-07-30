using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // Amplitude da flutuação vertical
    public float floatFrequency = 1f; // Frequência da flutuação vertical
    public Vector3 floatAxis = Vector3.up; // Eixo da flutuação vertical (padrão é para cima)

    public float horizontalAmplitude = 0.5f; // Amplitude da flutuação horizontal
    public float horizontalFrequency = 1f; // Frequência da flutuação horizontal

    private Vector3 initialPosition;

    void Start()
    {
        // Armazena a posição inicial do objeto
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calcula a nova posição vertical
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // Calcula a nova posição horizontal usando PerlinNoise para suavidade
        float noiseX = Mathf.PerlinNoise(Time.time * horizontalFrequency, 0.0f) * 2 - 1; // Valor entre -1 e 1
        float noiseZ = Mathf.PerlinNoise(0.0f, Time.time * horizontalFrequency) * 2 - 1; // Valor entre -1 e 1
        float horizontalOffsetX = noiseX * horizontalAmplitude;
        float horizontalOffsetZ = noiseZ * horizontalAmplitude;

        // Aplica a nova posição
        transform.localPosition = initialPosition + floatAxis * floatOffset + new Vector3(horizontalOffsetX, 0, horizontalOffsetZ);
    }
}
