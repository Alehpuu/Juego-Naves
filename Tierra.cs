
namespace MiEspacioDeNombres
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    // Asegúrate de que la clase Tierra se defina una vez
    public class Tierra : MonoBehaviour
    {
        public GameObject explosion;
        protected GameObject explosionClon;
        public GameObject panelPerder;

        // Start se llama antes del primer fotograma
        void Start()
        {
            Time.timeScale = 1.0f;
        }

        // Update se llama una vez por fotograma
        void Update()
        {
            
        }
        public void Detener(){

            Time.timeScale = 0.0f;
              Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Asteroid")
            {
                panelPerder.SetActive(true);
                Debug.Log("Tierra destruida");
                explosionClon = (GameObject) Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
                Destroy(explosionClon.gameObject, 0.3f);
                Destroy(other.gameObject);
                Invoke("Detener", 0.3f);
              
            }
        }
    }
}
