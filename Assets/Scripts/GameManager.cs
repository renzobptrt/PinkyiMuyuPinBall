using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Posibles estados del videojuego
public enum GameState
{
    inGame,
    inGameOver,
    inMenu
}

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;

    //Variable para saber en que estado del juego nos encontramos
    public GameState gameState = GameState.inMenu;

    //Variables del juego
    private int contadorPuntos=0;

    private string escena;

    //AudioClips para cambio de musica
    /*public AudioClip inMenuTrack;
    public AudioClip inGameTrack;*/
    //private MusicManager theAM;

    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {   

        //Buscar objeto que tiene la musica
        //theAM = FindObjectOfType<MusicManager>();
    }

    void Update()
    {
        /*if (Input.GetButtonDown("Start") && this.gameState != GameState.inGame)
        {
            StartGame();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            BackToMenu();
        }*/
    }



    public void ChangeScene(string nombre){
        SceneManager.LoadScene(nombre);
    }
    public void ExitGame(){
        PlayerPrefs.SetInt("Score",0);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif    
    }
    
    //Aumento de puntaje
    public void AddPoints(int puntaje){
        contadorPuntos += puntaje;
        //Debug.Log("Puntaje actual: "+ contadorPuntos);
    }

    public int GetPoints(){
        return this.contadorPuntos;
    }
}
