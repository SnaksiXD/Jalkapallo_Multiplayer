using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;

    public TMP_InputField joinImput;
    // Start is called before the first frame update
    public void CreateRoom()
    {
        //Huoneen luonti
        PhotonNetwork.CreateRoom(createInput.text);
    }

}
