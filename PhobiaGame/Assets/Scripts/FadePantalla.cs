using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePantalla : MonoBehaviour
{
    private bool mFaded = false;
    public float Duration = 1f;

    CanvasGroup canvGroup;

    void Start()
    {
        canvGroup = GetComponent<CanvasGroup>();
        canvGroup.alpha = 1;
        Fade();
    }

    public void Fade()
    {
        StartCoroutine(DoFade(canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    public IEnumerator DoFade(float alpha, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(alpha, end, counter / Duration);

            yield return null;
        }
    }
}
