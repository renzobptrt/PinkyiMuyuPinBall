using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerController : MonoBehaviour
{   
    private int golpes = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Destruir un objeto luego de tres golpes
        if(golpes==3){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.SendMessage("BouncingObject", transform.position.x);
            golpes ++ ;
        }

    }
}
