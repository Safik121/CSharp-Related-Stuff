using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscareImg;
    public AudioSource jumpscareSound;
    [SerializeField] private float JumpscareLiving = 3f;
    [SerializeField] private float FadeOutDuration = 1f;

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

            yield return new WaitForSeconds(JumpscareLiving - 2f);

            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(FadeOutDuration);

            disableImage();
        }
    }

    private IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = jumpscareImg.GetComponent<CanvasGroup>();
        float startAlpha = canvasGroup.alpha;

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / FadeOutDuration; 
            yield return null;
        }

        canvasGroup.alpha = startAlpha; 
    }

    private void enableImage()
    {
        jumpscareImg.SetActive(true);

        CanvasGroup canvasGroup = jumpscareImg.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
            canvasGroup.alpha = 1f; 
    }

    private void disableImage()
    {
        jumpscareImg.SetActive(false);
    }
}
