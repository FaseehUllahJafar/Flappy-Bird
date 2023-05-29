using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // to change the bird so that it makes an flying animation effect
    private int SpriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f; // earths gravity
    public float strength = 5.0f;
    [SerializeField] public AudioSource wingsSound;
    [SerializeField] public AudioSource scoreSound;
    [SerializeField] public AudioSource gameOverSound;
    [SerializeField] public AudioSource hitSound;
    [SerializeField] public AudioSource replaySound;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("isPaused", 1);
    }

    void Start()
    {
        InvokeRepeating("AnimateSprite", 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            wingsSound.Play();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // gets only the first touch if multiple touches are performed at once
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                wingsSound.Play();
            }
        }

        direction.y += gravity * Time.deltaTime; // pull the bird downward after every frame
        transform.position += direction * Time.deltaTime;
    }
    private void OnEnable() // this function is called when the user restarts the game
    {
        int isPaused = PlayerPrefs.GetInt("isPaused");
        if (isPaused != 0)
        {
            Vector3 position = transform.position;
            position.y = 0f;
            transform.position = position;
            direction = Vector3.zero;
            replaySound.Play();
        }
    }
    private void AnimateSprite()
    {
        SpriteIndex++;
        if (SpriteIndex >= sprites.Length)
        {
            SpriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[SpriteIndex]; // changes the bird to make an wings flapping animation affect
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            hitSound.Play();
            FindObjectOfType<GameManager>().GameOver();
            PlayerPrefs.SetInt("isPaused", 1);
            gameOverSound.PlayDelayed(0.5f);
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            scoreSound.Play();
        }
    }
}
