using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameObject puntuacion;
    public VariableJoystick joystick; 
    void Start(){
        General.puntuacionGeneral = 0;
    }
    void Update(){
        puntuacion.GetComponent<Text>().text= "" + General.puntuacionGeneral;
    }

    
    public void Reiniciar()
    {
      
        joystick.gameObject.SetActive(false);
        SceneManager.LoadScene("Juego");
    }
}