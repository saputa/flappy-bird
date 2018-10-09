using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
    public float jump = 5;
    public Text scoreText;
    Rigidbody2D rb2d;
    bool isDead = false;
    int score = 0;

	public AudioClip jumpclip;
	public AudioClip deadclip;
	public AudioClip scoreclip;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            rb2d.velocity = new Vector2(0, jump);
			AudioManager.instance.playsfx(jumpclip);
            print("space pressed");
        }
        else if(Input.GetKeyDown(KeyCode.Space) && isDead)
        {
            SceneManager.LoadScene(0);
			AudioManager.instance.playsfx(deadclip);
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("dead");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "scoreTrigger")
        {
            score += 1;
            scoreText.text = "Score : " + score;
			AudioManager.instance.playsfx(scoreclip);
		}
    }
}