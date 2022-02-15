using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player: MonoBehaviour
{
    bool isDead;
    Rigidbody2D rb2d;
    public GameObject ReplayButton;
    public float speed = 5f;
    public Animator anim;
    [SerializeField] private float force = 20f;
    void Start()
    {
        Time.timeScale = 0;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !isDead)
        {
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            rb2d.AddForce(Vector2.up * force);
        }
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("test");
        if (coll.gameObject.tag == "Obstacle"){
            isDead = true;
            rb2d.velocity = Vector2.zero;
            ReplayButton.SetAvtive(true);
            anim.SetBool("isDead", true);
            Debug.Log("test");
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
