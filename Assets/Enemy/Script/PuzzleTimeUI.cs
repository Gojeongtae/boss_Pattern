using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTimeUI : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject clock;
    [SerializeField] GameObject border;
    [SerializeField] GameObject timebar;
    [SerializeField] float maxTime;

    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timebar.SetActive(true);
        Text.SetActive(true);
        clock.SetActive(true);
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timebar.GetComponent<Image>().fillAmount = timeLeft / maxTime;
        }
        else
        {
            Text.SetActive(false);
            clock.SetActive(false);
            border.SetActive(false);
        }
    }

}
