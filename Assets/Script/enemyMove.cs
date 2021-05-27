using System.Collections;
using TMPro;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool flip;
    public float health;
    public ScoreAndTimer SAT;
    public GameObject player;
    public AudioSource source;
    public AudioClip[] clips;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>().gameObject;
        SAT = FindObjectOfType<ScoreAndTimer>();
        flip = (Random.value > 0.5f);
        int timer = Random.Range(2, 5);
        StartCoroutine(sound(timer));
    }

    private void OnParticleCollision(GameObject collision)
    {
        health = health - 5;
    }

    public IEnumerator sound(int timer)
    {
        if (SAT.timeRemaining == 0)
        {

        }
        else
        {
            yield return new WaitForSeconds(timer);
            source.clip = (clips[Random.Range(0, clips.Length)]);
            source.Play();
            int timer2 = Random.Range(2, 5);
            StartCoroutine(sound(timer2));
        }
    }
    void Update()
    {

        if(health <= 0)
        {
            SAT.AddScore(10);
            Destroy(this.gameObject);
        }
        
        //Move enemy
        if (flip)
        {
            if (this.GetComponent<Rigidbody2D>().velocity.x > maxSpeed)
            {
                //Normalize
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
            }
            else
            {
                //Increase
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * speed * Time.deltaTime, 0));
            }
        }
        //move the other way
        else
        {
            if (this.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed)
            {//Normalize
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
            }
            else
            {//Increase
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * speed * Time.deltaTime, 0));
            }
        }
    }

    
    public void TakeDamage(float damage)
    {
        //Move away from player when hit
        if (this.transform.position.x > player.transform.position.x)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(160, 15));
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-160, 15));
        }

        //Set new health
        health = health - damage;
    }

    //Flip the enemy to move the other way if it hits the wall
    private void OnCollisionEnter2D(Collision2D trig)
    {
        if (trig.gameObject.CompareTag("EastWall"))
        {
            flip = false;
        }

        if (trig.gameObject.CompareTag("WestWall"))
        {
            flip = true;
        }

        //kills the enemy if it falls in the void
        if (trig.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
        }
    }
}
