using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimeout : MonoBehaviour
{
    public Text text;
    public float textTimeOut;

    private void Start()
    {
        StartCoroutine("KillText");
    }

    IEnumerator KillText()              //destroys the text after a certain amount of time, currently set to 20 seconds
    {
        yield return new WaitForSeconds(textTimeOut);

        Destroy(text.gameObject);
    }
}
