using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCoroutine : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(displayTouched());
    }

    IEnumerator displayTouched()
    {
        text.enabled = true;
        yield return new WaitForSeconds(1f);
        text.enabled = false;

    }
}
