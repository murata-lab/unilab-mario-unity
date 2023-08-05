using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaControl : MonoBehaviour
{

    public int speed = 10;
    public float jumpForce = 50;
    public LayerMask groundlayer;
    public bool isJumping = true;
    public GameObject mainCamera;
    public GameObject GoalPanel;
    public GameObject ClearPanel;
    public GameObject QuitButton;
    public GameObject NextButton;
    public int currentStageIndex;

    private Rigidbody2D rb;
    private Animator anim;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            rb.gravityScale = 5.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
             StartCoroutine(ShowGoalAndLoadNextStage());
        }
    }

    private IEnumerator ShowGoalAndLoadNextStage()
    {
        GoalPanel.SetActive(true);
        if (currentStageIndex < 2)
        {
            QuitButton.SetActive(true);
            NextButton.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(2f);
            GoalPanel.SetActive(false);
            ClearPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("BeforeGame");
        }
    }

    public void StopMoving()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Animator anim = GetComponent<Animator>();

        rigidbody.velocity = Vector2.zero;
        anim.SetBool("Dash", false);
    }

    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * speed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + movement * Time.fixedDeltaTime);

        anim.SetBool("Dash", true);
    }

    public void MoveForward()
    {
        Move(1);
    }

    public void MoveBackward()
    {
        Move(-1);
    }
    public void Jump()
    {
        if (isJumping)
        {
            jumpForce = 20;

            Vector2 jumpVelocity = new Vector2(speed, jumpForce);
            rb.velocity = jumpVelocity;
            rb.gravityScale = 5.0f;
            isJumping = false;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            Move(x);
            anim.SetBool("Dash", true);
        }
        else
        {
            anim.SetBool("Dash", false);
        }

        if (isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpVelocity = new Vector2(speed, jumpForce);
            rb.velocity = jumpVelocity;
            rb.gravityScale = 5.0f;
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        // カメラの追従
        if (transform.position.x > mainCamera.transform.position.x - 4)
        {   
            Vector3 cameraPos = mainCamera.transform.position;
            cameraPos.x = transform.position.x + 4;
            mainCamera.transform.position = cameraPos;
        }
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
        transform.position = pos;

        // ジャンプ中かつ速度が0以下（＝頂点）のとき重力スケールを増加
        if (!isJumping && rb.velocity.y <= 2.0)
        {
            rb.gravityScale = 20.0f;
        }
    }
}
