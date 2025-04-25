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

    public bool isFacingRight;

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

            if (moveInput.x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);   
                isFacingRight = true;     
            }
            else if (moveInput.x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                isFacingRight = false;
            }
            anim.SetFloat("isRun", moveInput.sqrMagnitude);
        }
    }
}
