using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myBody;
    Animator myAnim;
    public float speedX;
    public float speedY;
    public float max;
    public float min;

    public GameObject bullet;
    public Transform shooterPos;
    public AudioSource collide_sound;

    public float health = 100;
    public GameObject explosion;
    public Slider healthBar;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    void Update()
    {
        healthBar.value = health;
        if (health > 0)
        {
            if (Input.GetMouseButton(0) && myAnim.GetBool("shoot") == false)
            {
                myAnim.SetBool("shoot", true);
                Instantiate(bullet, shooterPos.position, transform.rotation);
            }
            else if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("shoot") == false)
            {
                myAnim.SetBool("shoot", false);
            }
        }
        else if (health <= 0)
        {

        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (health > 0)
        {
            float vertical = Input.GetAxisRaw("Vertical");
            myBody.velocity = new Vector2(speedX, vertical * speedY);
            myBody.position = new Vector2(myBody.position.x, Mathf.Clamp(myBody.position.y, min, max));
        }
        else if (health <= 0)
        {
            myBody.gravityScale = 1;
            GameManager.gameOver = true;
        }
	}
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet_Enemy")
        {
            health -= 10;
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(collider.gameObject);
            collide_sound.Play();
        }
    }
}
