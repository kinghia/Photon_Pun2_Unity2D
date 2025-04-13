using UnityEngine;
using Photon.Pun;
using TMPro;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public GameObject mark;
    public GameObject canvasName;
    public TMP_Text username;

    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        canvasName.SetActive(true);
        username.text = GetComponent<PhotonView>().Controller.NickName;
    }

    void FixedUpdate()
    {
        if (GetComponent<PhotonView>().IsMine == true)
        {
            Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);

            rb.MovePosition((Vector2)transform.position + moveInput * moveSpeed * Time.deltaTime);

            if ( moveInput.x < 0)
            {
                sr.flipX = true;
            }
            else if (moveInput.x > 0)
            {
                sr.flipX = false;
            }  
            anim.SetFloat("isRun", moveInput.sqrMagnitude);
        }
    }
}
