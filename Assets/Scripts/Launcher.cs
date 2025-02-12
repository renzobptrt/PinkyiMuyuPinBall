﻿

using UnityEngine;
using System.Collections;


public class Launcher : MonoBehaviour
{
    // EfxZoom
    public GameObject efxZoomObj;
    private SpriteRenderer efxZoomRenderer;
    private AnimateController efxZoomAniController;
    // EfxZoom light
    public GameObject efxLightObj;
    private SpriteRenderer efxLightRenderer;
    private AnimateController efxLightAniController;

    // Touch Listener
    public bool isTouched = false;
    public bool isKeyPress = false;
    // Ready for Launch
    public bool isActive = true;
    // Timers
    private float pressTime = 0f;
    private float startTime = 0f;
    private int powerIndex;
    // #1..
    private SpringJoint2D springJoint;
    private float force = 0f; //current force generated
    public float maxForce = 90f;


    void Start()
    {
        // zoom animation object
        efxZoomAniController = efxZoomObj.GetComponent<AnimateController>();
        efxLightAniController = efxLightObj.GetComponent<AnimateController>();
        // zoom light object
        efxZoomRenderer = efxZoomObj.GetComponent<Renderer>() as SpriteRenderer;
        efxLightRenderer = efxLightObj.GetComponent<Renderer>() as SpriteRenderer;
        // #2..
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.distance = 1f;
    }


    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown("space"))
            {
                isKeyPress = true;
            }

            if (Input.GetKeyUp("space"))
            {
                isKeyPress = false;
            }

            // on keyboard press or touch hotspot
            if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
            {   
                if (startTime == 0f)
                {   
                    startTime = Time.time;
                }
            }

            // on keyboard release 
            if (isKeyPress == false && isTouched == false && startTime != 0f)
            {
                //#3..
                force = powerIndex * maxForce;
                // reset values & animation
                pressTime = 0f;
                startTime = 0f;
                efxLightRenderer.sprite = efxLightAniController.spriteSet[1];
                while (powerIndex >= 0)
                {
                    efxZoomRenderer.sprite = efxZoomAniController.spriteSet[powerIndex];
                    powerIndex--;
                }
            }
        }

        // Start Press
        if (startTime != 0f)
        {
            pressTime = Time.time - startTime;
            // plays zoom animation on loop
            powerIndex = (int)(Mathf.PingPong(pressTime * efxZoomAniController.fps, efxZoomAniController.spriteSet.Length));
            efxZoomRenderer.sprite = efxZoomAniController.spriteSet[powerIndex];
            // turns on/ off zoom light based on powerIndex
            if (powerIndex == efxZoomAniController.spriteSet.Length - 1)
            {
                efxLightRenderer.sprite = efxLightAniController.spriteSet[0];
            }
            else
            {
                efxLightRenderer.sprite = efxLightAniController.spriteSet[1];
            }
        }   

    }

    // #4..
    void FixedUpdate(){
        if(force!=0){
            springJoint.distance = 1f;
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);
            force = 0;
        }
        if(pressTime!=0){
            springJoint.distance = .8f;
            GetComponent<Rigidbody2D>().AddForce(Vector3.down * force);
        }
    }
}

