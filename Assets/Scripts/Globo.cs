using UnityEngine;

public class Globo : MonoBehaviour
{
    private float velocidad_movimiento = 4;
    private float gravityScale = -0.03f;
    private Rigidbody2D globo;

    void Start()
    {
        globo = GetComponent<Rigidbody2D>();

        Vector2 position2D = new Vector2(1.0f, 2.0f);
        transform.position = new Vector3(position2D.x, position2D.y, 0);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Anulamos el movimiento hacia arriba, ya que verticalmente solo querremos moverlo hacia abajo.
        if (moveY > 0)
        {
            moveY = 0;
        }

        // Calcular el movimiento como un Vector3
        Vector3 movement = new Vector3(moveX, moveY*2, 0f);

        // Aplicar el movimiento al Transform del GameObject
        transform.Translate(movement * velocidad_movimiento * Time.deltaTime);

        globo.gravityScale = gravityScale;

    }
}
