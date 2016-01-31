using UnityEngine;
using System.Collections;

public class CanvasChanger : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas CreditCanvas;

    Quaternion startRotation;
    Vector3 startPosition;

    public Transform targetTransform;

    void Start()
    {
        startPosition = Camera.main.transform.position;
        startRotation = Camera.main.transform.rotation;
    }

    public void ShowCredits()
    {
        StartCoroutine(GoToCredits());
    }

    public void ShowMain()
    {
        StartCoroutine(GoToMain());
    }

    IEnumerator GoToCredits()
    {
        MainCanvas.enabled = false;

        float time = 0;

        float duration = 2;

        while (time < duration)
        {
            yield return null;
            time += Time.deltaTime;

            float fraction = time / duration;

            Vector3 startpos = Camera.main.transform.position;
            Quaternion startrot = Camera.main.transform.rotation;

            Camera.main.transform.position = Vector3.Lerp(startpos, targetTransform.position, fraction);
            Camera.main.transform.rotation = Quaternion.Lerp(startrot, targetTransform.rotation, fraction);            
        }

        Camera.main.transform.position = targetTransform.position;
        Camera.main.transform.rotation = targetTransform.rotation;

        CreditCanvas.enabled = true;
    }

    IEnumerator GoToMain()
    {
        CreditCanvas.enabled = false;

        float time = 0;

        float duration = 2;

        while (time < duration)
        {
            yield return null;
            time += Time.deltaTime;

            float fraction = time / duration;

            Vector3 startpos = Camera.main.transform.position;
            Quaternion startrot = Camera.main.transform.rotation;

            Camera.main.transform.position = Vector3.Lerp(startpos, startPosition, fraction);
            Camera.main.transform.rotation = Quaternion.Lerp(startrot, startRotation, fraction);            
        }

        Camera.main.transform.position = startPosition;
        Camera.main.transform.rotation = startRotation;


        MainCanvas.enabled = true;
    }
}
