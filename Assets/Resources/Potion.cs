using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
       {
        Player player = collision.gameObject.GetComponent<Player>();
          if (player != null)
          {
             player.ChangeHealth(+8);
             Destroy(gameObject);
          }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
