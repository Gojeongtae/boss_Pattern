using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornHPfollow : MonoBehaviour
{
    public GameObject HPbar;
    public GameObject canvas;
    RectTransform bar;
    public float height = 1.7f;

    void OnEnable()
    {
       bar = Instantiate(HPbar, canvas.transform).GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 barpos =Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        bar.position = barpos;
    }

    public void OnDisable()
    {
        Destroy(bar.gameObject);
    }
}
