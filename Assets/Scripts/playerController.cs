using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{
    public float speed = 0;
    public float boost = 10;
    public float jumpForce = 10;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject door;

    private Rigidbody rb;
    private int count;
    private float movementx;
    private float movementy;
    private int jumps = 0;

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
    public void OnJump(InputAction.CallbackContext context)
    {
        float jumpInput = context.ReadValue<float>();
    }

    void SetCountText()
    {
        countText.text = "Jumps: " + jumps.ToString();
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
        
        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            Vector3 movement = new Vector3(movementx, 0.0f, movementy);
            rb.AddForce(movement*boost);
        }

        if(other.gameObject.CompareTag("jumps"))
        {
            other.gameObject.SetActive(false);
            jumps++;
            count++;
            SetCountText();
        }
    }

}
