using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    PhotonView PV;

    public float speedY = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            moveLeftOrRight();
        }
    }

    float TopOrDown () {
        return Input.GetAxis("Vertical");
    }

    void moveLeftOrRight () {
        rb.velocity = TopOrDown() * new Vector2 (0, speedY);
    }
}
