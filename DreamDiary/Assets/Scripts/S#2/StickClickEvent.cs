using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickClickEvent : MonoBehaviour
{


    public bool IsFishing=false;
    bool IsTiming=false;
    void Start()
    {
        InvokeRepeating("watermovingset",5,5);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){  
            if(!IsFishing){
                IsFishing=true;
                if(IsTiming){ //타이밍 맞춰서 클릭한 경우
                    stopFishing();
                    FindObjectOfType<StickAnimTrigger>().eggfish();
                }else{ //그냥 타이밍에 클릭한 경우
                    FindObjectOfType<StickAnimTrigger>().nonefish();
                    restartFishing();
                }
                    
            }            
        }
        
    }

    void watermovingset(){
        if(!IsFishing){        
            StartCoroutine(waterMovingTiming());
        }
    }
    IEnumerator waterMovingTiming(){
        IsTiming=true;
        FindObjectOfType<WaterAnimTrigger>().setMoving();

        yield return new WaitForSeconds(2.5f);
        IsTiming=false;
        if(FindObjectOfType<WaterAnimTrigger>()==true){
            FindObjectOfType<WaterAnimTrigger>().cancelMoving();
        }
    }

    void restartFishing(){
        CancelInvoke("watermovingset");
        Invoke("watermovingset",5);
    }
    void stopFishing(){
        CancelInvoke("watermovingset");
    }
}
