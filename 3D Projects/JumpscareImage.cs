using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscareImg;
    [SerializeField] private float JumpscareLiving = 3f;

    void Start()
    {
        jumpscareImg.SetActive(false);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enableImage();
            yield return new WaitForSeconds(JumpscareLiving);
            disableImage();
        }
    }

    private void enableImage()
    {
        jumpscareImg.SetActive(true);
    }

    private void disableImage()
    {
        jumpscareImg.SetActive(false);
    }
}
