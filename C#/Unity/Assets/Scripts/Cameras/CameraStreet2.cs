using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStreet2 : MonoBehaviour
{
    public float dumping = 2f;
    public GameObject vcam2;

    void Update()
    {   
        // if (Hero.hero == null)
        // {
        //     transform.position = new Vector3(-10.14f, -6.54f, -10);
        // }
        // else
        // {
        //     Vector3 target = new Vector3(Hero.hero.position.x, Hero.hero.position.y, transform.position.z);
        //     transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        // }

        if (Hero.hero != null)
        {
            //vcam2.Follow();
            Vector3 target = new Vector3(Hero.hero.position.x, Hero.hero.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);  
        }      
    }
}
