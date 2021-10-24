using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;

    public float speedX = 10;
    public float speedY = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!PhotonNetwork.IsMasterClient) return;
            rb.velocity = new Vector2(speedX, speedY);
        //rb.velocity = new Vector2(speedX, speedY);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.CompareTag("LeftPoint")){
            Debug.Log("Touch Left");
        }

        if(other.gameObject.CompareTag("RightPoint")){
            Debug.Log("Touch Right");
        }
    }
}
