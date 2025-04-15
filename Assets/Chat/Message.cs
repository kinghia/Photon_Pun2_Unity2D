using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    public TMP_Text MyMessage;

    void Start()
    {
        GetComponent<RectTransform>().SetAsFirstSibling();
    }
}
