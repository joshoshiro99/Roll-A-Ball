using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{
    public float speed = 0;
    public float boost = 10;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject door;

    private Rigidbody rb;
    private int count;
    private float movementx;
    private float movementy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementx = movementVector.x;
        movementy = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=12)
        {
            winText.SetActive(true);
            door.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementx, 0.0f, movementy);

        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            speed++;
            count++;
            SetCountText();
        }
        
        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            Vector3 movement = new Vector3(movementx, 0.0f, movementy);
            rb.AddForce(movement*boost);
        }

        if(other.gameObject.CompareTag("SpeedPickup"))
        {
            other.gameObject.SetActive(false);
            boost = boost + 5;
            count++;
            SetCountText();
        }
    }

}
