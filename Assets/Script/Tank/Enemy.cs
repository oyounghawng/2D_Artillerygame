using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbd2d;

    void Start()
    {
       rigidbd2d = GetComponent<Rigidbody2D>();
        //�۾��� �ڵ�� �ʱ�ȭ ���ִ°��� ����
    }

    // Update is called once per frame
    void Update()
    {

    }
}
