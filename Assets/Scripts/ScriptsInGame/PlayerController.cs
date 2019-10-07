using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //Patron Singleton
    public static PlayerController sharedInstance;
    //Componentes
    private Rigidbody2D rb2d;
    private Vector3 startPosition;

    //Caracteristicas
    private float speed;
    private bool isDead;

    //Contadores
    private int contadorInterruptor;
    private int numeroMuertes;

    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
        sharedInstance = this;
        startPosition = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        numeroMuertes = 0;
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

    private void BornPlayer(){
        //Inicializamos parametros cada vez que reiniciamos
        this.transform.position = startPosition;
        this.isDead = false;
    }

    public void BouncingObject(float bouncerPosX, int bouncerIntense){
        float side = Mathf.Sign(bouncerPosX - this.transform.position.x);
        rb2d.AddForce(Vector2.left*side*bouncerIntense,ForceMode2D.Impulse);
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

    public void DeadPlayer(){
        numeroMuertes++;
        this.isDead = true;
        if(numeroMuertes==3){
            numeroMuertes = 0;

            //Creamos las variables que guardan historial de puntos aun asi se apage el juego
            int maxScore = PlayerPrefs.GetInt("maxScore", 0);
            int score = PlayerPrefs.GetInt("Score",0);
            int points = GameManager.sharedInstance.GetPoints();

            //Asiganamos los valores a las variables
            PlayerPrefs.SetInt("Score",points);
            if(maxScore < points ){
                PlayerPrefs.SetInt("maxScore",points);
            }
            GameManager.sharedInstance.ChangeScene("GameOverScene");
        }else{
            Debug.Log("Nace jugador");
            BornPlayer();
        }
        //Invoke("KillPlayer", 1.2f);
    }

    public bool GetIsDead(){
        return this.isDead;
    }
    
    
}   
