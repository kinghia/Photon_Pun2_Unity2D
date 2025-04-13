using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using Photon.Realtime;

public class Spanwer : MonoBehaviour
{
    public Joystick joystick;

    void Start()
    {
        GameObject ToasterPlayer = PhotonNetwork.Instantiate("ToasterPlayer", new Vector3(Random.Range(-8, 8), -1.5f, 0), Quaternion.identity);
        ToasterPlayer.GetComponent<Player>().joystick = joystick;
        ToasterPlayer.GetComponent<Player>().mark.SetActive(true);
    }
}
