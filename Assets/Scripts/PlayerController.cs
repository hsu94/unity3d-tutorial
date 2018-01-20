using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void Update()
    {

    }

    //physics code
    private void FixedUpdate()
    {
        float jump;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            rb.velocity = new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jump = 1;
        }
        else
            jump = 0;

        if (rb.position.y >= 3)
        {
            jump = 0;
        }

        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>= 12)
        {
            winText.text = "You Win.";
        }
    }
}
