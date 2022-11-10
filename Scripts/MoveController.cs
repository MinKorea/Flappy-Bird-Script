using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    float upForce = 0;  // 위로 미는 힘. 점프 힘을 담을 변수

    bool isJump = false;    // 현재 점프 중인지 체크할 변수
    bool isDead = false;    // 현재 죽었는지 체크할 변수

    [SerializeField]
    Rigidbody2D rb;     // 리지드 바디를 담을 변수

    float angle = 0;        // 각도 변수

    [SerializeField]
    float rotateSpeed = 10; // 회전 속도

    SpriteRenderer img;     // 새 이미지 담을 변수


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 같은 게임 오브젝트에 있는 컴포넌트 Rigidbody2D를 가져옴
        img = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gm.isGameStart || GameManager.gm.isGameOver || isDead)
        {
            return;
        }

        if (!rb.simulated)
        {
            rb.simulated = true;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Jump(); // 점프 함수 호출!!!!
        }

        Rotate();

    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, upForce));

        angle = 35;
        Animation("AngryBirdJump");
    }

    void Rotate()
    {
        if (angle > -35)
        {
            angle -= Time.deltaTime * rotateSpeed;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            if(angle <= 0)
            {
                Animation("AngryBirdNormal");
            }
        }
    }

    void Animation(string str)
    {
        img.sprite = Resources.Load<Sprite>(str);
    }

    private void OnTriggerEnter2D(Collider2D collision)     // 모든 콜라이더 컴포넌트의 isTrigger가 true라면 얘가 호출
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)  // 아니면 얘가 호출
    {
        rb.velocity = Vector2.zero; // 속도값 초기화
        isDead = true;
        Animation("AngryBirdDie");
        GameManager.gm.GameOver();
    }







    private void FixedUpdate()      // 고정적으로 50번 호출
    {
        
    }

    private void LateUpdate()       //
    {

    }
}
