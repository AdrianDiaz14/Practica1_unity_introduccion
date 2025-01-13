using UnityEngine;

public class MovimientoFantasma : MonoBehaviour
{
    private float velocidadMovimiento = 4;
    private Rigidbody2D fantasma;

    void Start()
    {
        fantasma = GetComponent<Rigidbody2D>();

        // Quitamos la gravedad al cuerpo
        fantasma.gravityScale = 0;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calcular el movimiento como un Vector3
        Vector3 movement = new Vector3(moveX, moveY, 0f);

        // Aplicar el movimiento al Transform del GameObject
        transform.Translate(movement * velocidadMovimiento * Time.deltaTime);
    }
}
