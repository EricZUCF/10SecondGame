using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;
    public float speed = 5.0f;
    public int score = 0;
    public Text scoreText;
    public bool win = false;
    AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public Timer clock;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
        scoreText.text = "Score: 0";
        PlaySound(clip1);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
        if(score == 3 && clock.timeLeft > 0){
            PlaySound(clip2);
            win = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
