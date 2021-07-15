using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : Singleton<SEManager>
{
    
    AudioSource audioSource;
    void Start()
    {
        audioSource=this.GetComponent<AudioSource>();
    }
    public void SEplay(AudioClip se){
        if(!audioSource.isPlaying){
            audioSource.Stop();
        }
        audioSource.clip=se;
        audioSource.time=0;
        audioSource.PlayOneShot(se);
    }
    public void SEStop(){
        audioSource.Stop();
    }
    public void SEplay(AudioClip se,int time){
        if(!audioSource.isPlaying){
            audioSource.Stop();
        }
        audioSource.clip=se;
        audioSource.time=time;
        audioSource.PlayOneShot(se);

    }

}
