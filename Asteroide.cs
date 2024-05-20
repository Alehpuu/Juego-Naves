using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public GameObject explosion;
    protected GameObject explosionClon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            General.puntuacionGeneral = General.puntuacionGeneral + 1;
            explosionClon = (GameObject)Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
            Destroy(explosionClon.gameObject, 2.0f);
            Destroy(other.gameObject); 
            Destroy(this.gameObject);
        }
    }
}
