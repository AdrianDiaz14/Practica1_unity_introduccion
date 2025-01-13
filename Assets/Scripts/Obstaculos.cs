using UnityEngine;
using System.Collections;

public class BoingSound : MonoBehaviour
{
    private SpriteRenderer blockRenderer;
    private Color originalColor;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockRenderer = GetComponent<SpriteRenderer>();
        originalColor = blockRenderer.color;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource no encontrado en " + gameObject.name);
            }

            // Cambiar color cuando el objeto colisionado es la pelota
            if (collision.gameObject.CompareTag("Pelota"))
            {
                StartCoroutine(ChangeColor());
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
}
