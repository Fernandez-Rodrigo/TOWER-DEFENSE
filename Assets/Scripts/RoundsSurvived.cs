using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        StartCoroutine(AnimatedCountRounds());
        
    }

 

    IEnumerator AnimatedCountRounds()
    {
        roundText.text = "0";
        int rounds = 0;

        yield return new WaitForSeconds(0.07f);

        while (rounds < PlayerStats.rounds)
        {
            rounds++;
            roundText.text = "WAVES SURVIVED: "+ rounds.ToString();

            yield return new WaitForSeconds(0.2f);
        }


    }

}
