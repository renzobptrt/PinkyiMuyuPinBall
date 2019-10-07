using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerController : MonoBehaviour
{   
    private int golpes = 0;
    public int puntaje=0;
    public int intensidad=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Destruir un objeto luego de tres golpes
        /*if(golpes==3){
            Destroy(this.gameObject);
        }*/
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            PlayerController.sharedInstance.BouncingObject(transform.position.x,intensidad);
            GameManager.sharedInstance.AddPoints(puntaje);
            golpes ++ ;
        }
    }

    void OnTriggerExit2D(Collider2D col){ 
        if(col.gameObject.tag == "Player"){
            this.GetComponent<EdgeCollider2D>().isTrigger = false;
            Debug.Log("Dandole collider");
        }
    }
    void OnTriggerStay2D(Collider2D col){ 
        if(col.gameObject.tag == "Player" && this.tag == "Catcher"){
            PlayerController.sharedInstance.CatchPlayer();
            Debug.Log("Atrape al jugador");
        }
    }

}
