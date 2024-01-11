using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float verticalInput;
    [Header("Turning")]
    public float turnSpeed;
    public float horizontalInput;
    [Header("Shooting")]
    public GameObject projectile;
    public GameObject bulletSpawn;

    //Animation
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE 
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput);
        animator.SetFloat("verticalInput",Mathf.Abs(verticalInput));
        //TURN
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //SHOOT
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(projectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
    }
}
