using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroBoost : MonoBehaviour
{
    private PlayerController pc;
    float cur  = 0;
    float resettime = 3;
    private int boostJuice = 0;
    private int boostJuiceMax = 100;
    private float boostInterval = 3;


    // Start is called before the first frame update
    void Start()
    {
        boostRefill();
    }

    // Update is called once per frame
    void Update()
    {
     
        /*if(cur < 0)
        {
            cur -= Time.deltaTime;
            boostInterval = 3;
            boostJuice++;
            print(boostJuice);
        }
        */
    }


    void boostRefill()
    {
        while (boostJuice < boostJuiceMax)
        {
            boostInterval = boostInterval - Time.deltaTime;
            if (boostInterval < 0)
            {
                boostJuice++;
                print(boostJuice);
                boostInterval = 3;
            }
        }
    }
    

}
