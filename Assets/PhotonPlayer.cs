using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;

    // Start is called before the first frame update
    void Start()
    {

        PV = GetComponent<PhotonView>();
        int spawnPicker = PhotonNetwork.IsMasterClient ? 0 : 1;

        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"),
                GameSetup.GS.spawnPoints[spawnPicker].position,
                GameSetup.GS.spawnPoints[spawnPicker].rotation,
                0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
