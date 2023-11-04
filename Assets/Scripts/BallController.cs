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

    private void FixedUpdate()          //qualsiasi cosa che riguarda la FISICA lo inserisco in questo metodo FixedUpdate--> a differenza dell'update normale questo � TEMPORIZZATO--> il DeltaTime � sempre lo stesso-->la FISICA ha un comportamento molto pi� omogeneo
    {
        KeepConstantVelocity();   
    }

    void KeepConstantVelocity()                 //velocit� che voglio richiamarmi costantemente affinch� la velocit� sia sempre uguale a quella definita nella variabile ballSpeed
    {
        body.velocity = ballSpeed * body.velocity.normalized;   //body.velocity.normalized--> mi da la DIREZIONE del vettore velocit� (cambia sempre perch� la pallina sbatte nelle varie pareti e cambia direzione)
    }
    //cos� facendo ottengo un vettore con direzione della velocit� e intensit� pari a ballSpeed    

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
