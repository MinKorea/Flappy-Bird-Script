using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    float upForce = 0;  // ���� �̴� ��. ���� ���� ���� ����

    bool isJump = false;    // ���� ���� ������ üũ�� ����
    bool isDead = false;    // ���� �׾����� üũ�� ����

    [SerializeField]
    Rigidbody2D rb;     // ������ �ٵ� ���� ����

    float angle = 0;        // ���� ����

    [SerializeField]
    float rotateSpeed = 10; // ȸ�� �ӵ�

    SpriteRenderer img;     // �� �̹��� ���� ����


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ���� ���� ������Ʈ�� �ִ� ������Ʈ Rigidbody2D�� ������
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
            Jump(); // ���� �Լ� ȣ��!!!!
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

    private void OnTriggerEnter2D(Collider2D collision)     // ��� �ݶ��̴� ������Ʈ�� isTrigger�� true��� �갡 ȣ��
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)  // �ƴϸ� �갡 ȣ��
    {
        rb.velocity = Vector2.zero; // �ӵ��� �ʱ�ȭ
        isDead = true;
        Animation("AngryBirdDie");
        GameManager.gm.GameOver();
    }







    private void FixedUpdate()      // ���������� 50�� ȣ��
    {
        
    }

    private void LateUpdate()       //
    {

    }
}
