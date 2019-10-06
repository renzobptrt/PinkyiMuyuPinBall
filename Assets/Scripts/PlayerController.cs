using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private float speed;
    private Rigidbody2D rb2d;
    private int contadorInterruptor = 0;


    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(contadorInterruptor == 3){
                Debug.Log("Activación de evento");
                contadorInterruptor = 0;
            }  
            //Modo lunatico
            //rb2d.velocity = new Vector3((float)rb2d.velocity.x*1.01f,(float)rb2d.velocity.y*1.01f,1);
            //Debug.Log(rb2d.velocity.x);
    }

    public void BouncingObject(float bouncerPosX){
        float side = Mathf.Sign(bouncerPosX - this.transform.position.x);
        rb2d.AddForce(Vector2.left*side*10,ForceMode2D.Impulse);
    }

    //Funcion para trasladar un objeto de un punto a otro
    public void TransporterObject(TransporterController transporter){
        float side = Mathf.Sign( 0.0f - this.transform.position.x);
        this.transform.position = new Vector3(transporter.transform.position.x - 0.5f,transporter.transform.position.y,this.transform.position.z);
        Debug.Log("Cambie de posicion al jugador" + this.transform.position.x);
        rb2d.AddForce(Vector2.left*side*10,ForceMode2D.Impulse);
    }

    //Contador para activar un evento
    public void AddContInterruptor(int parametro){
        if(contadorInterruptor<3 && contadorInterruptor>=0){
            if(contadorInterruptor + parametro < 0){
                contadorInterruptor = 0;
            }else{
                contadorInterruptor= contadorInterruptor + parametro;
            }
        }
        Debug.Log("Aumentamos el contador a :"+  contadorInterruptor);
    }
    
    
}   
