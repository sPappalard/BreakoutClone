using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    float ballSpeed = 10f;

    [SerializeField]
    AudioSource ballSound;
    [SerializeField]
    AudioSource deathSound;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()          //qualsiasi cosa che riguarda la FISICA lo inserisco in questo metodo FixedUpdate--> a differenza dell'update normale questo è TEMPORIZZATO--> il DeltaTime è sempre lo stesso-->la FISICA ha un comportamento molto più omogeneo
    {
        KeepConstantVelocity();   
    }

    void KeepConstantVelocity()                 //velocità che voglio richiamarmi costantemente affinchè la velocità sia sempre uguale a quella definita nella variabile ballSpeed
    {
        body.velocity = ballSpeed * body.velocity.normalized;   //body.velocity.normalized--> mi da la DIREZIONE del vettore velocità (cambia sempre perchè la pallina sbatte nelle varie pareti e cambia direzione)
    }
    //così facendo ottengo un vettore con direzione della velocità e intensità pari a ballSpeed    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            Gamemanager.gamemanager.GameOver();         //classe.istanza.funzione()
            deathSound.Play();
        }
    }

   
} 
