using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    //Llamara a la función de muerte del jugador
    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("Jugador entro en la zona de muerte");
            PlayerController.sharedInstance.DeadPlayer();
        }
    }
}
