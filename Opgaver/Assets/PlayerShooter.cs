using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float speed;
    private Transform tf;
    public GameObject bulletPrefab;
    public float cooldownTime = 0.2f;
    private float cooldownLeft;
    public float bulletSpeed = 100;
    public Animator animator;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownLeft -= Time.deltaTime; 
        if (Input.GetKey(KeyCode.Space) && cooldownLeft <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = tf.forward * bulletSpeed;
            cooldownLeft = cooldownTime;
            
            animator.SetTrigger("Shoot");
            audioSource.Play();
                
        }   
        
        tf.Rotate(0,Input.GetAxisRaw("TurnAround") * speed,0);
    }
}
