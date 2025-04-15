using UnityEngine;

public class OpenChat : MonoBehaviour
{
    [SerializeField] GameObject chat;

    void Start()
    {
        chat.SetActive(false);
    }
    public void ActiveOpenChat()
    {
        chat.SetActive(!chat.activeSelf);
    }
}
