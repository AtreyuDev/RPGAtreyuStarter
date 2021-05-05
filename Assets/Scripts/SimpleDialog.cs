using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleDialog : MonoBehaviour
{
    public float Delay = 0.1f;
    public string FullText;
    public string CurrenText;
    public AudioSource SourceSound;
    public AudioClip ThisClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            CurrenText = FullText.Substring(0, i);
            this.GetComponent<Text>().text = CurrenText;
            SourceSound.PlayOneShot(ThisClip, 1);
            yield return new WaitForSeconds(Delay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Text>().text = " ";
        }
    }
}
