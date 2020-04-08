using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 distanceFromPlayer;
    void Start()
    {
        distanceFromPlayer = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + distanceFromPlayer;
    }
}
