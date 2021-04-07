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
    Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float JumpHight;
    public bool jump;
    public GameObject resetPoint;
    public ScoreAndTimer SAT;
    public int RemovalOnDeath;

    [Header("Wapen")]
    float hz;
    public GameObject weapon;
    public ParticleSystem weaponParticle;
    public Animator Stab;

    [Header("GroundChecks")]
    public Transform top_left;
    public Transform bottom_right;
    public LayerMask ground_layers;

    [Header("Timer")]
    public GameObject timerObj;
    public LazerBar lazerManager;


    public float EnemyTimeDamage;
    void Start()
    {
        weaponParticle.gameObject.SetActive(false); 
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    void Update()
    {
        if(this.gameObject.layer == 10)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period; 
                this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
                Stab.gameObject.GetComponent<SpriteRenderer>().enabled = this.gameObject.GetComponent<SpriteRenderer>().enabled;
            }
        }
        else
        {
            Stab.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        Flip();
        jump = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);
        hz = CrossPlatformInputManager.GetAxis("Horizontal");

        if (rb.velocity.x > maxSpeed || rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2((rb.velocity.normalized * maxSpeed).x, rb.velocity.y);
        }
        else
        {
            if (hz > -0.2f && hz < 0.2f)
            {
                rb.velocity = new Vector2(rb.velocity.x - rb.velocity.x * 0.04f, rb.velocity.y);
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

    IEnumerator Invin()
    {
        invisTag();
        yield return new WaitForSeconds(5f);
        invisOff();
    }

    void invisTag()
    {
        this.gameObject.tag = "Untagged";
        this.gameObject.layer = 10;
    }

    void invisOff()
    {
        this.gameObject.tag = "Player";
        this.gameObject.layer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (this.gameObject.tag == "Player")
            {
                ScoreAndTimer t = timerObj.gameObject.GetComponent<ScoreAndTimer>();
                t.RemoveTime(EnemyTimeDamage);
                StartCoroutine(Invin());
            }
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            SAT.RemoveTime(RemovalOnDeath);
            this.gameObject.transform.position = resetPoint.transform.position;
        }
    }
    private void Flip()
    {
        if (hz < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;

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
            Vector2 jump_force = new Vector2(0, JumpHight);
            rb.AddForce(jump_force);
        }
    }

    public void StabStab()
    {
        if (Stab != null)
        {
            if (!this.Stab.GetCurrentAnimatorStateInfo(0).IsName("StabStab"))
            {
                Stab.Play("StabStab");
            }
        }
    }
}
