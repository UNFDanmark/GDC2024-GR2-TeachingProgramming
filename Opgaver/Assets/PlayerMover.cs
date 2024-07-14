using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    public float speed;
    private int totalCoins;
    public Animator animator;
    public GameObject gameOverScreen;
    private int health = 3;
    private float leftoverCooldown;
    public float deathCooldown;
    public TMPro.TMP_Text healthbarText;
    
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leftoverCooldown = deathCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = rb.velocity;
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        movement.z = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = movement;
        
        animator.SetFloat("Speed", movement.magnitude);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
        
        leftoverCooldown = leftoverCooldown - Time.deltaTime;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            totalCoins += 1;
            print(totalCoins);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (leftoverCooldown <= 0)
            {
                health -= 1;
                print("Your health is:" + health);
                leftoverCooldown = deathCooldown;

                healthbarText.text = $"Health: {health}/3";
            }
            if (health == 0)
            {
                gameOverScreen.SetActive(true);  
            }
        }
    }
}
