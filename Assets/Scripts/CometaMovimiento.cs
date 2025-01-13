using UnityEngine;

public class CometaMovimiento : MonoBehaviour
{
    public float radio = 1f;
    public float velocidadAngular = 15f;
    private float angulo = 0f;
    private Vector3 centro;

    void Start()
    {
        centro = transform.position;
    }

    void Update()
    {
        angulo += velocidadAngular * Time.deltaTime;

        // Convierte el ángulo a radianes
        float anguloRad = angulo * Mathf.Deg2Rad;

        float x = centro.x + radio * Mathf.Cos(anguloRad);
        float y = centro.y + radio * Mathf.Sin(anguloRad);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
