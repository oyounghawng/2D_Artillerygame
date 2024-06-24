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
        //작업을 코드로 초기화 해주는것이 좋음
    }

    // Update is called once per frame
    void Update()
    {

    }
}
