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

    void Start()
    {
        player = FindObjectOfType<PlayerScript>().gameObject;
        SAT = FindObjectOfType<ScoreAndTimer>();
        flip = (Random.value > 0.5f);
    }

    private void OnParticleCollision(GameObject collision)
    {
        health = health - 5;
    }

    void Update()
    {

        if(health <= 0)
        {
            SAT.AddScore(10);
            Destroy(this.gameObject);
        }

        if (flip)
        {
            if (this.GetComponent<Rigidbody2D>().velocity.x > maxSpeed)
            {
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * speed * Time.deltaTime, 0));
            }
        }
        else
        {
            if (this.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed)
            {
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * speed * Time.deltaTime, 0));
            }
        }
    }

    
    public void TakeDamage(float damage)
    {
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

        health = health - damage;
    }
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

        if (trig.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
        }
    }
}
