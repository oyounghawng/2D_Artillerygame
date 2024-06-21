using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gazer : MonoBehaviour
{
    private GameObject PowerGazer;
    public float Force;
    public Slider forceUI;

    private void Start()
    {
        PowerGazer = GameObject.Find("Canvas/gazer");

    }

    void Update()
    {

        PowerGazer.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
        if (Input.GetKey(KeyCode.Space))
        {
            Force++;
            Slider();

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {

            StartCoroutine(Wait());
        }
    }
    
    public void Slider()
    {
        forceUI.value = Force;
    }
    public void ResetGauge()
    {
        Force = 0;
        forceUI.value = 0;

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        ResetGauge();
    }



}
