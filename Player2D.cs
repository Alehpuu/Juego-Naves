using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public GameObject laser;
    private GameObject laserClonD;
    private GameObject laserClonI;

    public GameObject puntoSpawnI;
    public GameObject puntoSpawnD;

    public float fuerzaLaser = 10.0f;

    public VariableJoystick vj;
    public float velocidadAvion = 5.0f;

    public GameObject explosion;
    protected GameObject explosionClon;

    // Límites del rango de movimiento
    public float minX = -2.61f;
    public float maxX = 2.61f;
    public float minY = -4.42f;
    public float maxY = 4.42f;

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del joystick
        float h = vj.Horizontal * Time.deltaTime * velocidadAvion;
        float v = vj.Vertical * Time.deltaTime * velocidadAvion;

        // Calcular la nueva posición
        float newX = Mathf.Clamp(transform.position.x + h, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y + v, minY, maxY);

        // Aplicar la nueva posición
        transform.position = new Vector3(newX, newY, transform.position.z);

        // Disparar láser al hacer clic derecho
        if(Input.GetMouseButtonDown(1))
        {
            DispararLaser();
        }
    }

    // Método para disparar láser
    void DispararLaser()
    {
        // Clonar y configurar láser izquierdo
        laserClonI = Instantiate(laser, puntoSpawnI.transform.position, Quaternion.identity);
        laserClonI.GetComponent<Rigidbody2D>().velocity = Vector2.up * fuerzaLaser;

        // Clonar y configurar láser derecho
        laserClonD = Instantiate(laser, puntoSpawnD.transform.position, Quaternion.identity);
        laserClonD.GetComponent<Rigidbody2D>().velocity = Vector2.up * fuerzaLaser;
    }

    // Manejar colisiones
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            General.puntuacionGeneral= General.puntuacionGeneral + 1;
            explosionClon = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(explosionClon.gameObject, 2.0f);
            Destroy(other.gameObject);
        }
    }
}
