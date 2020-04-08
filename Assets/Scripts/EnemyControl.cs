using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 5;
    private Rigidbody rigidbody;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        int zombieType = Random.Range(1, 28);
        transform.GetChild(zombieType).gameObject.SetActive(true);
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 direction = player.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rigidbody.MoveRotation(rotation);
        
        if (distance > 2.5)
        {
            Vector3 position = rigidbody.position;
            rigidbody.MovePosition(position + direction.normalized * speed * Time.deltaTime);
            
            animator.SetBool("Atacking", false);
        }
        else
        {
            animator.SetBool("Atacking", true);
        }
    }

    void Atack()
    {
        Time.timeScale = 0;
        
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        playerControl.GameOverText.SetActive(true);
    }
}