using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;
    Transform target;
    Animator anim;

    public float speed;
    public float maxSpeed;

    public float timeShoot;
    private float shoot;

    public float health = 100;

    public GameObject bullet;
    public Transform shooterPos;
    public GameObject explosion;
    public Slider healthBar;
    public AudioSource collide_sound;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        shoot = timeShoot;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        healthBar.value = health;
        if (health > 0)
        {
            float playerPos = target.position.y - transform.position.y;
            if (playerPos > 0)
            {
                if (rb.velocity.y < maxSpeed)
                {
                    rb.AddForce(new Vector2(0, speed));
                }
            }
            else if (playerPos < 0)
            {
                if (rb.velocity.y > -maxSpeed)
                {
                    rb.AddForce(new Vector2(0, -speed));
                }
            }
            shoot -= Time.deltaTime;
            if (shoot < 0)
            {
                if (playerPos == Mathf.Clamp(playerPos, -1, 1))
                {
                    Instantiate(bullet, shooterPos.position, transform.rotation);
                    shoot = timeShoot;
                }

            }
        }
        else if (health <= 0)
        {
            anim.SetBool("dead", true);
            rb.gravityScale = 1;
            Destroy(gameObject, 3);
        }
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            health -= 25;
            GameManager.score += 20;
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                if (rb.gravityScale == 0)
                {
                    GameManager.enemiesDead += 1;
                }
            }
            Destroy(collider.gameObject);
            collide_sound.Play();

        }
    }
}
