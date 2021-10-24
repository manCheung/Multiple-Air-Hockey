using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public static NetworkManager instance;

    public GameObject startButton;
    public GameObject joinButton;
    public Text text;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Join a room failed");
        CreateRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create a room failed");
        CreateRoom();
    }

    public void OnJoinButtonClicked()
    {
        joinButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnStartButtonClicked()
    {
        startButton.SetActive(false);
        StartGame();
        //PhotonNetwork.JoinRandomRoom();
    }

    void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        PhotonNetwork.LoadLevel(1);
    }

    void CreateRoom()
    {
        Debug.Log("Created Room");
        int randomRoonName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2
        };
        PhotonNetwork.CreateRoom("Room" + randomRoonName, roomOps);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player Connected to master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        joinButton.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Player: " + PhotonNetwork.PlayerList.Length + " | isGame Master: " + PhotonNetwork.IsMasterClient;
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            if (joinButton != null) {
                joinButton.SetActive(false);
                if (PhotonNetwork.IsMasterClient)
                {
                    startButton.SetActive(true);
                }
            }
        }
        //Debug.Log(PhotonNetwork.IsConnected);
    }

}
