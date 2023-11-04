using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField]
    Color oneLifeColor, twoLifeColor, threeLifeColor;

    [SerializeField]
    int hitPoints;

    SpriteRenderer sprite;

    [SerializeField]
    ParticleSystem brickHitParticles;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();        //riferimento alla componente SpriteRenderer dell'oggetto (è quella che ci permette di cambiare colore al nostro oggetto)
        ChangeColorOnLife();



    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")          //vedo se collido con un oggetto con tag "ball" 
        {
            hitPoints--;
            ChangeColorOnLife();
            brickHitParticles.Play();

            Vector3 collisionPoint = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y);         //Ricavo la direzione in cui il brick viene colpito 
            Vector3 ballDirection = collision.transform.position - collisionPoint;
            brickHitParticles.transform.rotation = Quaternion.LookRotation(ballDirection.normalized,Vector3.back);                 //cambio la direzione delle particles in base alla direzione della collisione ricavata prima
            brickHitParticles.transform.position = collisionPoint;                      //particles nella posizione esatta della collisione
            
                if(hitPoints<=0) 
            {
                Gamemanager.gamemanager.BrickDestroyed();
                Destroy(gameObject);
            }
        }
    }

    void ChangeColorOnLife()                                //metodo da invocare ogni volta che c'è una collisione
    {
        switch (hitPoints)
        {
            case 1:
                sprite.color = oneLifeColor; 
                break;
            case 2:
                sprite.color = twoLifeColor; 
                break;    
            case 3:
                sprite.color = threeLifeColor; 
                break;
            default:
                sprite.color = oneLifeColor;
                break;
        }

        ParticleSystem.MainModule particleModule = brickHitParticles.main;
        particleModule.startColor = sprite.color;
    }
}
