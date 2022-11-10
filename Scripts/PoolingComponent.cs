using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoolingComponent : MonoBehaviour
{
    //const int SIZE = 5;

    public GameObject column;       // ��� ������Ʈ

    int size = 5;                   // ó�� ������ ��� ����

    [SerializeField]
    float spawnRate = 3;            // ��� ���� ����
    float time = 0;

    [SerializeField]
    float minY = -1;                // ��� �ּ� ���̰�
    [SerializeField]
    float maxY = 3.25f;             // ��� �ִ� ���̰�

    [SerializeField]
    GameObject[] columnsArr;        // ��� ��Ƶ� �迭
    int currentColumn = 0;          // ���� �ֱ� ���� ����� �ε���

    Vector2 pos = new Vector2(20, 100);   // ���� ��ġ
    float posX = 10;                // ����� �� ���� ��ġ
    float posY = 0;                 // ����� �� ���� ��ġ

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gm.isGameStart || GameManager.gm.isGameOver)
        {
            return;
        }


        Spawn();
    }

    void Init()
    {
        if (column == null)
        {
            column = (GameObject)Resources.Load("Assets/Prefabs/Columns.prefab", typeof(GameObject));

            //column = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Columns.prefab", typeof(GameObject));  
        }

        columnsArr = new GameObject[size];  // �迭�� ��� �����ŭ ���� ����

        for (int i = 0; i < columnsArr.Length; i++)
        {
            columnsArr[i] = Instantiate(column, pos, Quaternion.identity);
        }
    }

    void Spawn()
    {
        time += Time.deltaTime;

        if(time >= spawnRate)
        {
            posY = Random.Range(minY, maxY);    // ���̰��� �������� ����
            columnsArr[currentColumn].transform.position = new Vector2(posX, posY);

            currentColumn++;

            if(currentColumn >= size)
            {
                currentColumn = 0;
            }

            time = 0;
        }
    }

}
