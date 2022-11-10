using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaleChange : MonoBehaviour
{
    RectTransform text;

    [SerializeField]
    float minSize = 1;
    [SerializeField]
    float maxSize = 4;

    bool isMax = false;     // ����� ���� Ŀ�� �� �۾����� �Ǵ��� ����
    float time = 0;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<RectTransform>();
        // ���� ���� ������Ʈ ���� �ִ� ��Ʈ Ʈ������ ������Ʈ�� ������
    }

    // Update is called once per frame
    void Update()
    {
        SizeChange();
    }

    void SizeChange()
    {
        if(isMax == false)  // !isMax ���� ������ �ǹ�
        {
            text.localScale = Vector3.Lerp(new Vector3(minSize, minSize, minSize), new Vector3(maxSize, maxSize, maxSize), time += Time.deltaTime*0.75f);

            if (time >= 1)
            {
                time = 0;
                isMax = true;
            }
        }
        else
        {
            text.localScale = Vector3.Lerp(new Vector3(maxSize, maxSize, maxSize), new Vector3(minSize, minSize, minSize), time += Time.deltaTime * 0.75f);

            if (time >= 1)
            {
                time = 0;
                isMax = false;
            }
        }
    }
}
