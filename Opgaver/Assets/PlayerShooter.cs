using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float speed;

    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.Rotate(0,Input.GetAxisRaw("TurnAround") * speed,0);
    }
}
