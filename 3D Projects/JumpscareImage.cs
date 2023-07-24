using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscareImg;
    public AudioSource jumpscareSound;
    [SerializeField] private float JumpscareLiving = 3f;

    void Start()
    {
        disableImage();
        jumpscareSound.Stop();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enableImage();

            if (!jumpscareSound.isPlaying)
                jumpscareSound.Play();

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
