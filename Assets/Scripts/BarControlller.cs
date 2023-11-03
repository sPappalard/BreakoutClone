using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControl : MonoBehaviour
{
    [SerializeField]            //mi permette di modificare la variabile movementSpeed dall'Inspector di Unity (molto comodo)
    float movementSpeed;      //definisce la velocità del movimento (lo setto dall'inspector)

    [SerializeField]                    //limiti barra (per non farla uscire fuori dallo schermo)
    float minX = -2.2f, maxX = 2.2f;



    void Start()
    {
        
    }

    void Update()
    {
        MoveBar();
    }

    void MoveBar()
    {
        float xMovement = Input.GetAxis("Horizontal");                                                  //xMovement rileva la direzione dle movimento (-1 se sx, +1 se dx)
        transform.Translate(Vector2.right * xMovement * Time.deltaTime * movementSpeed);                //*Time.deltaTime rende il movimento fluido
        if(transform.position.x < minX) 
        { 
            transform.position = new Vector2(minX,transform.position.y);
        }
        else if (transform.position.x > maxX) 
        {
            transform.position = new Vector2(maxX,transform.position.y);
        }
    }

}
