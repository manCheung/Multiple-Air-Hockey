using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour
{

    static SpawnPlayers instance;

    public GameObject playerPrefab;
    public GameObject ballPrefab;

    public Text pingText;

    /*
    public Text leftText;
    public Text rightText;

    public int leftScore = 0;
    public int rightScore = 0;
    */

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name,
                GameSetup.GS.spawnPoints[0].position,
                GameSetup.GS.spawnPoints[0].rotation,
                0);

            PhotonNetwork.Instantiate(ballPrefab.name,
                ballPrefab.transform.position,
                ballPrefab.transform.rotation,
                0);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name,
                GameSetup.GS.spawnPoints[1].position,
                GameSetup.GS.spawnPoints[1].rotation,
                0);
        }

    }


   private void Update()
    {
        pingText.text = PhotonNetwork.GetPing().ToString();
    }

    /*
    public static void SetLeftScore(int value)
    {
        instance.leftText.text = new System.Text.StringBuilder()
            .Append("Score: ")
            .Append(value)
            .ToString();
    }

    public static void SetRightScore(int value)
    {
        instance.rightText.text = new System.Text.StringBuilder()
            .Append("Score: ")
            .Append(value)
            .ToString();
    }

    public void addScore(string scoreBoard)
    {

        if(scoreBoard == "left")
        {
            if(PV != null)
            PV.RPC("RPC_AddLeftScore", RpcTarget.All);
        }

        if (scoreBoard == "right")
        {
            if (PV != null)
                PV.RPC("RPC_AddRightScore", RpcTarget.All);
        }

    }

    [PunRPC]
    private void RPC_AddLeftScore()
    {
        if (PV.IsMine)
        {
            SetLeftScore(leftScore++);
        }
    }

    [PunRPC]
    private void RPC_AddRightScore()
    {
        if (PV.IsMine)
        {
            SetLeftScore(rightScore++);
        }
    }

    */
}
