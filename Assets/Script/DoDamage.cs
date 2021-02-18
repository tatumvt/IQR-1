using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    private BoxCollider2D col;
    public List<enemyMove> enemiesHit;
    public bool active = false;
    public int damage;

    private void Start()
    {
        col = this.GetComponent<BoxCollider2D>();
        col.enabled = false;
        enemiesHit.Clear();
    }

    private void Update()
    {
        if (!active)
        {
            enemiesHit.Clear();
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (!enemiesHit.Contains(collision.gameObject.GetComponent<enemyMove>()))
                {
                    enemiesHit.Add(collision.gameObject.GetComponent<enemyMove>());
                    collision.gameObject.GetComponent<enemyMove>().TakeDamage(damage);
                }
            }
        }
    }
}
