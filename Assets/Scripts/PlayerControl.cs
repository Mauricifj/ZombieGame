using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.SceneManagement.SceneManager;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private Text scoreText;
    private Vector3 direction;
    private Rigidbody rigidbody;
    private Animator animator;
    public GameObject GameOverText;
    private int scorePoints;

    private void Start()
    {
        Time.timeScale = 1;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(-x, 0, -z);
        
        if (direction != Vector3.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 aim = hit.point - transform.position;

            aim.y = transform.position.y;
            
            Quaternion rotation = Quaternion.LookRotation(aim);
            
            rigidbody.MoveRotation(rotation);
        }
    }

    public void Restart()
    {
        LoadScene(GetActiveScene().name);
    }

    public void Score()
    {
        scorePoints += 10;
        scoreText.text = "Score " + scorePoints;
    }
}
