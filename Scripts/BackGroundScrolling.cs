using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; // ������ �ٵ� ������Ʈ�� ��Ƶ� ���� 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ���� ������Ʈ ���� �ִ� ������ �ٵ� ������Ʈ�� ������ ������ ���� 

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gm.isGameStart || GameManager.gm.isGameOver)
        {
            if(rb.velocity.x != 0)      // ������ �ٵ��� �ӵ� ���� ���ν�Ƽ�� x�� ���� 0�� �ƴ϶��
            {
                MoveBg(0);   // ����BG�Լ� ȣ��!!
            }
            
        }
        else
        {
            if(rb.velocity.x == 0)      // ������ �ٵ��� �ӵ� ���� ���ν�Ƽ�� x�� ���� 0�̶��
            {
                MoveBg(-1.5f);  // ����BG�Լ� ȣ��!!
            }
            
        }
        
    }

    void MoveBg(float speed)
    {
        rb.velocity = new Vector2(speed, 0);    
        // ������ �ٵ� ���� �� �ӵ��� �ӵ� ���� ����
    }


}
