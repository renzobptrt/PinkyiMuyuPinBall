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
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif    
    }
    /* 
    void setGameState(GameState newGameState)
    {   
        
        if (newGameState == GameState.inGame)
        {
            //Se prepara la escena para jugar 
            escena = "GameScene";
            

            /* 
            //Musica
            if(inGameTrack!=null){
                //theAM.ChangeBGM(inGameTrack);
                MusicManager.sharedInstance.ChangeBGM(inGameTrack);
            }

        }
        else if (newGameState == GameState.inGameOver)
        {
            //Se prepara la escena para GameOver
            //SceneManager.LoadScene("GameOver");
            //escena = "GameOverScene";

            /* 
            //Musica
            if(inMenuTrack!=null){
                //theAM.ChangeBGM(inMenuTrack);
                MusicManager.sharedInstance.ChangeBGM(inMenuTrack);
            }

        }
        if (newGameState == GameState.inMenu)
        {   
            //Se prepara la escena para el Menu
            escena = "MenuScene";
        }
    }
    */
    /* 
    public void CollectCoins(int coinValue){
        this.collectedCoin += coinValue;

        Debug.Log("Llevamos recogidos: "+ this.collectedCoin); 
    }*/
}
