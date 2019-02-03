using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    //void Update()//called before rendering a frame, game code
    //{
    //}
    public float speed;
    public Text countText;
    public Text WinText;


    private Rigidbody rb;
    private int count;

    void Start()//called on first frame script is active, often first frame of game
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
     }

    void FixedUpdate()//called just before performing physics calc, physics code
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

        }
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();

        if (count >= 11)
        {
            WinText.text = "You Win!";
        }

    }

}
