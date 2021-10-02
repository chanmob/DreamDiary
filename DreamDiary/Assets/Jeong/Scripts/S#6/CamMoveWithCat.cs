using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveWithCat : MonoBehaviour
{
    public GameObject cat;

    Vector3 newposition;
    Vector3 initPosition=new Vector3(0,0,-10);

    private void Start()
    {
        this.gameObject.transform.position = initPosition;
        newposition = initPosition;
    }

    void Update()
    {
        moveWithCat();
    }

    void moveWithCat()
    {
        if (cat.gameObject.transform.position.x >= 0&& cat.gameObject.transform.position.x<= 18)
        { //고양이가 특정 영역을 벗어나지 않는다면 고양이를 따라다님
            newposition =new Vector3( cat.gameObject.transform.position.x,newposition.y,-10);
            this.gameObject.transform.position = newposition;
        }
    }


}
