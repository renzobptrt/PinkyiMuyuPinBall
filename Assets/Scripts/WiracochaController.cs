using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiracochaController : MonoBehaviour
{   

    private GameObject startPoint;
    private GameObject endPoint;
    private int numPoints;
    private int indexInitial;
    private int indexEnd;

    public GameObject[] points;

    public float enemySpeed;

    private bool isDead;
    // Start is called before the first frame update

    void Awake(){

        this.indexEnd = 0;
        this.numPoints = points.Length;
        this.isDead = true;
    }

    void Start()
    {  
        Debug.Log(numPoints);
        /*if(isGoingRight){
            transform.position = startPoint.transform.position;
        }
        else{
            transform.position = endPoint.transform.position;
        }*/
        this.indexInitial = Random.Range(0,numPoints);
        transform.position = points[indexInitial].transform.position;
        indexEnd = RandomExcept(0,numPoints,indexInitial);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(isDead){
            endPoint = points[indexEnd];
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position,enemySpeed * Time.deltaTime);
            if(transform.position == endPoint.transform.position){
                indexEnd = RandomExcept(0,numPoints,indexEnd);
            }
        }
    }

    private int RandomExcept(int min,int max, int except){
        int random = except;
        while(random == except){
            random = Random.Range(min,max);
        }
        return random;
    }
}
