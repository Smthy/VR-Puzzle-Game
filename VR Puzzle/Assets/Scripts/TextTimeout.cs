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

    IEnumerator KillText()
    {
        yield return new WaitForSeconds(textTimeOut);

        Destroy(text.gameObject);
    }
}
