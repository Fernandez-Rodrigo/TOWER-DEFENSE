using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image imgBG;

    public AnimationCurve fadeCurve;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime ;
            float a = fadeCurve.Evaluate(t);
            imgBG.color = new Color(0.0754717f, 0.0754717f, 0.0754717f, a);

            yield return 0;

        }
    }

    public void  FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            imgBG.color = new Color(0.0754717f, 0.0754717f, 0.0754717f, a);

            yield return 0;

        }

        SceneManager.LoadScene(scene);
    }
}
