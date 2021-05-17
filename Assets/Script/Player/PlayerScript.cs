using System;
using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour
{
    [Header("Speler")]
    public float speed;
    public float maxSpeed;
    public float jumpHight;
    Rigidbody2D rb;
    bool jump;
    bool isOnIce;
    public GameObject resetPoint;
    public ScoreAndTimer SAT;
    
    [Header("Damage")]
    public int removalOnDeath;
    public float enemyTimeDamage;

    [Header("Wapen(Spuit)")]
    public GameObject weapon;
    float hz;
    public ParticleSystem weaponParticle;
    public Animator stab;

    [Header("GroundChecks")]
    public Transform top_left;
    public Transform bottom_right;
    public LayerMask ground_layers;

    [Header("Timer")]
    public GameObject timerObj;
    public LazerBar lazerManager;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    
    void Start()
    {
        weaponParticle.gameObject.SetActive(false); 
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    void Update()
    {
        //Invincible effect
        if (this.gameObject.layer == 10)
        {
            //Evcery time next action is triggerd
            //Disable or enable sprite on previous state for blinking
            if (Time.time > nextActionTime)
            {
                nextActionTime += period; 
                this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
                stab.gameObject.GetComponent<SpriteRenderer>().enabled = this.gameObject.GetComponent<SpriteRenderer>().enabled;
            }
        }
        else
        {
            //Makes sure its active when not invincible
            stab.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        Flip();

        //Check collision with ground layer
        jump = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);
        //Set horizontal
        hz = CrossPlatformInputManager.GetAxis("Horizontal");

        //Movement
        if (rb.velocity.x > maxSpeed || rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2((rb.velocity.normalized * maxSpeed).x, rb.velocity.y);
        }
        else
        {
            if (hz > -0.2f && hz < 0.2f)
            {
                if (!isOnIce)
                {
                    if (jump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x - rb.velocity.x * 0.04f, rb.velocity.y);
                    }
                }
            }
            else
            {
                Vector2 movement = new Vector2(hz, 0);
                rb.AddForce(speed * movement * Time.deltaTime);
            }
        }
    }

    public void SetWeapon(bool state)
    {
        weaponParticle.gameObject.SetActive(state);
    }

    //turns on invisible tag and off after 5 seconds
    IEnumerator Invin()
    {
        invisTag();
        yield return new WaitForSeconds(5f);
        invisOff();
    }
    
    //Switches the tag
    void invisTag()
    {
        this.gameObject.tag = "Untagged";
        this.gameObject.layer = 10;
    }

    //Switches the tag
    void invisOff()
    {
        this.gameObject.tag = "Player";
        this.gameObject.layer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pill")
        {
            collision.gameObject.GetComponent<PillSpawner>().pickedUp = true;
            SAT.timeRemaining += 5;
            SAT.score += 5;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slip"))
        {
            isOnIce = true;
        }
        else
        {
            isOnIce = false;
        }
        //Enemy collision
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreAndTimer t = timerObj.gameObject.GetComponent<ScoreAndTimer>();
            t.RemoveTime(enemyTimeDamage);
            StartCoroutine(Invin());
        }

        //Void collision, reset back to spawn point
        if (collision.gameObject.CompareTag("Death"))
        {
            SAT.RemoveTime(removalOnDeath);
            this.gameObject.transform.position = resetPoint.transform.position;
        }
    }
    private void Flip()
    {
        //Check horizontal input to flip to
        if (hz < 0)
        {
            //Flip sprite
            this.GetComponent<SpriteRenderer>().flipX = true;
            //Flip weapon
            weapon.transform.eulerAngles = new Vector3(0, 180, 0);
            weapon.transform.localPosition = new Vector2(-0.05f, weapon.transform.localPosition.y);
        }
        else if (hz > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            weapon.transform.eulerAngles = new Vector3(0, 0, 0);
            weapon.transform.localPosition = new Vector2(0.05f, weapon.transform.localPosition.y);
        }
    }

    public void Jump()
    {
        if (jump)
        {
            Vector2 jump_force = new Vector2(0, jumpHight);
            rb.AddForce(jump_force);
        }
    }

    public void StabStab()
    {
        if (stab != null)
        {
            //Check if stab is already playing
            if (!this.stab.GetCurrentAnimatorStateInfo(0).IsName("StabStab"))
            {
                stab.Play("StabStab");
            }
        }
    }
}
