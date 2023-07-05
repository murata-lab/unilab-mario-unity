// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CharaControl : MonoBehaviour
// {

//     int speed =  5;
//     public float jumpForce;
//     public LayerMask groundlayer;
//     public bool isJumping = true;
//     public GameObject mainCamera;
//     public GameObject GoalPanel;
//     public GameObject ClearPanel;
//     public GameObject QuitButton;
//     public GameObject NextButton;
//     public int currentStageIndex;

//     private StageManager stageManager;

//     private void Start()
//     {
//         stageManager = FindObjectOfType<StageManager>();
//     }

//     private void FixedUpdate()
//     {
//         float x = Input.GetAxis("Horizontal");
//         Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//         Animator anim = GetComponent<Animator>();

//         if (x != 0)
//         {
//             Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
//             rigidbody.velocity = movement;
//             anim.SetBool("Dash", true);
//         }
//         else
//         {
//             rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
//             anim.SetBool("Dash", false);
//         }

//         if (transform.position.x > mainCamera.transform.position.x - 4)
//         {
//             Vector3 cameraPos = mainCamera.transform.position;
//             cameraPos.x = transform.position.x + 4;
//             mainCamera.transform.position = cameraPos;
//         }
//         Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
//         Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
//         Vector2 pos = transform.position;
//         pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
//         transform.position = pos;

//         if (Input.GetKeyDown(KeyCode.Space) && isJumping)
//         {
//             rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
//             isJumping = false;
//         }

//     }

//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isJumping = true;
//         }
//     }

//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag == "Goal")
//         {
//             StartCoroutine(ShowGoalAndLoadNextStage());
//         }
//     }


//     private IEnumerator ShowGoalAndLoadNextStage()
//     {
//         GoalPanel.SetActive(true);
//         yield return new WaitForSeconds(2f);
//         if (currentStageIndex < 2)
//         {
//             GoalPanel.SetActive(false);
//             QuitButton.SetActive(true);
//             NextButton.SetActive(true);
//         }
//         else
//         {
//             GoalPanel.SetActive(false);
//             ClearPanel.SetActive(true);
//             yield return new WaitForSeconds(2f);
//             ClearPanel.SetActive(false);
//             GoalPanel.SetActive(false);
//             QuitButton.SetActive(true);
//         }
//     }

//     //public void MoveForward()
//     //{
//     //    float x = 1;
//     //    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//     //    Animator anim = GetComponent<Animator>();

//     //    Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
//     //    rigidbody.velocity = movement;
//     //    anim.SetBool("Dash", true);
//     //}

//     //public void MoveBackward()
//     //{
//     //    float x = -1;
//     //    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//     //    Animator anim = GetComponent<Animator>();

//     //    Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
//     //    rigidbody.velocity = movement;
//     //    anim.SetBool("Dash", true);
//     //}

//     //public void Jump()
//     //{
//     //    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

//     //    if (isJumping)
//     //    {
//     //        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
//     //        isJumping = false;
//     //    }
//     //}

//     public void MoveForward()
//     {
//         float x = 1;
//         Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//         Animator anim = GetComponent<Animator>();

//         Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
//         rigidbody.velocity = movement;
//         anim.SetBool("Dash", true);
//     }

//     public void MoveBackward()
//     {
//         float x = -1;
//         Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//         Animator anim = GetComponent<Animator>();

//         Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
//         rigidbody.velocity = movement;
//         anim.SetBool("Dash", true);
//     }

//     public void StopMoving()
//     {
//         Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//         Animator anim = GetComponent<Animator>();

//         Vector2 movement = new Vector2(0, rigidbody.velocity.y);
//         rigidbody.velocity = movement;
//         anim.SetBool("Dash", false);
//     }

//     public void Jump()
//     {
//         Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

//         if (isJumping)
//         {
//             rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
//             isJumping = false;
//         }
//     }



//     // Update is called once per frame
//     void Update()
//     {

//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaControl : MonoBehaviour
{
    int speed = 5;
    public float jumpForce;
    public LayerMask groundlayer;
    public bool isJumping = true;
    public GameObject mainCamera;
    public GameObject GoalPanel;
    public GameObject ClearPanel;
    public GameObject QuitButton;
    public GameObject NextButton;
    public int currentStageIndex;

    private StageManager stageManager;
    private Rigidbody2D rigidbody;
    private Animator anim;
    

    private void Awake()
    {
        stageManager = FindObjectOfType<StageManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
            rigidbody.velocity = movement;
            anim.SetBool("Dash", true);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            anim.SetBool("Dash", false);
        }

        Vector3 cameraPos = mainCamera.transform.position;
        if (transform.position.x > cameraPos.x - 4)
        {
            cameraPos.x = transform.position.x + 4;
            mainCamera.transform.position = cameraPos;
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            StartCoroutine(ShowGoalAndLoadNextStage());
        }
    }

    private IEnumerator ShowGoalAndLoadNextStage()
    {
        GoalPanel.SetActive(true);
        yield return new WaitForSeconds(2f);

        if (currentStageIndex < 2)
        {
            QuitButton.SetActive(true);
            NextButton.SetActive(true);
        }
        else
        {
            ClearPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            ClearPanel.SetActive(false);
        }

        GoalPanel.SetActive(false);
        QuitButton.SetActive(true);
    }

    public void MoveForward()
    {
        float x = 1;
        Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
        rigidbody.velocity = movement;
        anim.SetBool("Dash", true);
    }

    public void MoveBackward()
    {
        float x = -1;
        Vector2 movement = new Vector2(x * speed, rigidbody.velocity.y);
        rigidbody.velocity = movement;
        anim.SetBool("Dash", true);
    }

    public void StopMoving()
    {
        Vector2 movement = new Vector2(0, rigidbody.velocity.y);
        rigidbody.velocity = movement;
        anim.SetBool("Dash", false);
    }

    public void Jump()
    {
        if (isJumping)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            isJumping = false;
        }
    }
}

