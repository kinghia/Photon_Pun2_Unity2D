using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using Photon.Realtime;

public class Spanwer : MonoBehaviour
{
    public Joystick joystick;

    void Start()
    {
        GameObject DemonPlayer = PhotonNetwork.Instantiate("DemonPlayer", new Vector3(Random.Range(-8, 8), -1.5f, 0), Quaternion.identity);
        DemonPlayer.GetComponent<Player>().joystick = joystick;
        DemonPlayer.GetComponent<Player>().mark.SetActive(true);
    }
}
