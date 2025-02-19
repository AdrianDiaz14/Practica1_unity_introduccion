using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private SpriteRenderer blockRenderer;
    private Color originalColor;
    private AudioSource audioSource;
    private bool canDetectCollision = false;

    void Start()
    {
        blockRenderer = GetComponent<SpriteRenderer>();
        originalColor = blockRenderer.color;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(EnableCollisionDetectionAfterDelay());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDetectCollision)
        {
            // Generar y reproducir sonido con una frecuencia deaseada
            PlaySoundWithFrequency(250.0f); // Frecuencia de 250 Hz

            // Cambiar color cuando el objeto colisionado es la pelota
            if (collision.gameObject.CompareTag("Pelota"))
            {
                StartCoroutine(ChangeColor());
            }
        }
    }

    IEnumerator ChangeColor()
    {
        blockRenderer.color = Color.yellow;
        Debug.Log("Color cambiado a amarillo.");
        yield return new WaitForSeconds(0);
        StartCoroutine(ChangeColorBack());
    }

    IEnumerator ChangeColorBack()
    {
        // Esperar medio segundo
        yield return new WaitForSeconds(0.5f);

        // Restaurar el color original del bloque
        blockRenderer.color = originalColor;
        Debug.Log("Restaurado color original.");
    }

    IEnumerator EnableCollisionDetectionAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        canDetectCollision = true;
    }

    void PlaySoundWithFrequency(float frequency)
    {
        // Generar un AudioClip con la frecuencia deseada
        int sampleRate = 44100;
        int sampleLength = sampleRate;
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            samples[i] = Mathf.Sin(2 * Mathf.PI * frequency * i / sampleRate);
        }

        AudioClip clip = AudioClip.Create("GeneratedTone", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        // Reproducir el sonido
        audioSource.PlayOneShot(clip);
    }
}
