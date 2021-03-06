﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{
    
    public float downforce = 5;
    public float sideforce = 5;
    public float speed = 0;
    public float boost = 10;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject distanceText;

    private bool canMove = true;
    private Rigidbody rb;
    private int count;
    private float movementx;
    private float movementy;

    // Start is called before the first frame update
    void Start()
    {
        distanceText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(true);
    }

    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementx = movementVector.x;
        movementy = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "SpeedMuliplier: x" + count.ToString();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 movement = new Vector3(movementx * speed, downforce, movementy * speed);

            rb.AddForce(movement);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            Vector3 movement = new Vector3(movementx, 0.0f, movementy);
            rb.AddForce(movement*boost);
        }

        if(other.gameObject.CompareTag("jumps"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            winText.SetActive(false);
        }
        if(other.gameObject.CompareTag("speedupdone"))
        {
            distanceText.SetActive(true);
            canMove = false;
            downforce = 0;
        }
        if(other.gameObject.CompareTag("final"))
        {
            rb.velocity = Vector3.zero;
        }
    }

}
