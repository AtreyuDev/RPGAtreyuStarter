using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutiDialogImagenes : MonoBehaviour
{
    public float Delay = 0.1f;
    public string FullText;
    public string CurrenText;
    public AudioSource SourceSound;
    public AudioClip ThisClip;
    public int NumberOfDialogs;
    public List<string> FullTexts;
    public Image ImagenesDisplay;
    public List<Sprite> FullTextsSprites;
    public bool IsBusy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
        NumberOfDialogs = 0;
        IsBusy = false;
    }

    IEnumerator ShowText()
    {
        if (IsBusy == false)
        {
            IsBusy = true;
            if (NumberOfDialogs < FullTexts.Count)
            {
                ImagenesDisplay.sprite = FullTextsSprites[NumberOfDialogs];
                for (int i = 0; i < FullTexts[NumberOfDialogs].Length + 1; i++)
                {
                    CurrenText = FullTexts[NumberOfDialogs].Substring(0, i);
                    this.GetComponent<Text>().text = CurrenText;
                    SourceSound.PlayOneShot(ThisClip, 1);
                    yield return new WaitForSeconds(Delay);
                }
            }
            else if (NumberOfDialogs == FullTexts.Count)
            {
                Debug.Log("Todos Los dialogos Terminados");
            }
            IsBusy = false;
        }
        StopCoroutine(ShowText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsBusy == false)
            {
                this.GetComponent<Text>().text = " ";
                NumberOfDialogs = NumberOfDialogs + 1;
                StartCoroutine(ShowText());
            }
        }
    }
}
