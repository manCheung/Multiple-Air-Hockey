using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject ballPrefab;


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
}
