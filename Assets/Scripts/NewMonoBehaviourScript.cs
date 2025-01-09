using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    SpriteRenderer blockRenderer;
    Color originalColor;
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
    }

    IEnumerator ChangeColor()
    {
        blockRenderer.color = Color.yellow;
        Debug.Log("Color cambiado a amarillo.");
        yield return new WaitForSeconds(0.5f);
        blockRenderer.color = originalColor;
        Debug.Log("Color restaurado al original.");
    }

    IEnumerator EnableCollisionDetectionAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        canDetectCollision = true;
    }
}
