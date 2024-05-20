using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorAsteroides : MonoBehaviour
{
    public GameObject[] zonasSpawn;
    public GameObject[] enemigos;
    protected GameObject enemigoClon;



    protected int aleatorio;
    protected int aleatorioEnemigos;

    protected float increment = 0.0f;

    void Start()
    {
        InvokeRepeating("CrearAsteroide", 0.0f, 2.5f);
    }

    public void CrearAsteroide()
    {
        aleatorio = Random.Range(0, zonasSpawn.Length);
        aleatorioEnemigos = Random.Range(0, enemigos.Length);
        enemigoClon = Instantiate(enemigos[aleatorioEnemigos], zonasSpawn[aleatorio].gameObject.transform.position, Quaternion.identity);
        increment += 0.005f;
        enemigoClon.gameObject.GetComponent<Rigidbody2D>().gravityScale = increment;
    }

    void Update()
    {
        
    }
}
