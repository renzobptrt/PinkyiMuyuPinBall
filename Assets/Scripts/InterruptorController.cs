using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorController : MonoBehaviour
{   
    public bool estado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            if(this.estado == false){
                this.estado = true;
                col.gameObject.SendMessage("AddContInterruptor",1);
            }
            else{
                this.estado = false;
                col.gameObject.SendMessage("AddContInterruptor",-1);
            }
        }
    }
}
