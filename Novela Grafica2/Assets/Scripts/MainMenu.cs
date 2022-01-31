using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

void Start(){

 SoundManager.PlaySound("tension");
 
}
    public void EscenaJuego(){
    
        SceneManager.LoadScene("Juego");
}
    public void Salir(){
        Application.Quit();
        Debug.Log("he salido del juego");
    }
}

