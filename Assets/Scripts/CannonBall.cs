using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject firedEffect;
    public float radius = 0;
    private bool hasExplode = false;

    public bool isPlayer = true;
    

    private void Awake()
    {
        Fired();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isPlayer)
        {
            if (collision.gameObject.name != "Player")
            {
                Explode();
                hasExplode = true;
                if (collision.gameObject.tag == "enemy")
                {
                    collision.gameObject.GetComponent<EnemyController>().Health -= 10;
                }
            }
        }
        else
        {
            if (collision.gameObject.name != "Enemy")
            {
                Explode();
                hasExplode = true;
                if (collision.gameObject.tag == "Player")
                {
                    collision.gameObject.GetComponent<PlayerController>().Health -= 10;
                }
            }
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Fired()
    {
        Instantiate(firedEffect, transform.position, transform.rotation);
    }
}
