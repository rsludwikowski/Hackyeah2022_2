using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShoot : MonoBehaviour
{



    public AudioSource shootBegin;
    public AudioSource shootMid;
    public AudioSource shootEnd;

    [SerializeField] private bool shooting;

    // Start is called before the first frame update
    void Awake()
    {
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!shooting)
            {
                shootBegin.Play();
                //play clip 1st
                shooting = true;
            }
            else
            {
                if(!shootBegin.isPlaying && !shootMid.isPlaying)
                {
                    shootMid.loop = true;
                    shootMid.Play();
                }
                //check 1st clip end and play 2 clip in a loop
            }
        }
        else
        {
            if (shooting)
            {
                if(shootMid.loop == true)
                {
                    shootMid.loop = false;
                }
                if (!shootMid.isPlaying)
                {
                    shooting = false;
                    shootEnd.Play();
                }
                //check 2nd clip to end
                
            }
            
           
            //check 2nd clip end and play 3rd clip
        }



        
    }
}
