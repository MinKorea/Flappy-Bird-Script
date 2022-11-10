using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBg : MonoBehaviour
{
    BoxCollider2D bc;
    float length;       // ��׶��� ����

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponentInChildren<BoxCollider2D>();
        // �ڽ� ������Ʈ�� �ִ� �ڽ� �ݶ��̴��� ������ ����

        length = bc.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -length)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(length * 1.999f, 0);

        transform.position = (Vector2)transform.position + offset;
    }
}
