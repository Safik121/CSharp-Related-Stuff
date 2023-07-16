sing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollect : MonoBehaviour
{
    private int appleCount = 0;

    [SerializeField] private Text applesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            appleCount++;
            applesText.text = "Apples: " + appleCount;
        }
    }

}
