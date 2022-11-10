using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    bool isOn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!isOn)
            {
                isOn = true;
                GameManager.gm.GetScore();  // ���� ȹ�� �Լ� ȣ��
                StartCoroutine(ResetOn());
            }

            
        }
    }

    IEnumerator ResetOn()
    {
        yield return new WaitForSeconds(1);
        isOn = false;
    }

}
