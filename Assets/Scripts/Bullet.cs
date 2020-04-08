using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private PlayerControl player;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            player.Score();
        }
        
        Destroy(gameObject);
    }
}
