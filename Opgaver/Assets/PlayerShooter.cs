using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float speed;
    private Transform tf;
    public GameObject bulletPrefab;
    public float cooldown = 0.2f;
    private float cooldownLeft;
        
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownLeft -= Time.deltaTime; 
        
        if (Input.GetKey(KeyCode.Space) && cooldownLeft <= 0)
        {
            Destroy(Instantiate(bulletPrefab,transform.position, Quaternion.identity), 5);
            cooldownLeft = cooldown;
        }
        
        tf.Rotate(0,Input.GetAxisRaw("TurnAround") * speed,0);
    }
}
