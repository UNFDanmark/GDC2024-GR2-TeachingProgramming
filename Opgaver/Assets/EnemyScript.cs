using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour

{
    public float cooldown;
    private NavMeshAgent agent;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        agent.destination = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
