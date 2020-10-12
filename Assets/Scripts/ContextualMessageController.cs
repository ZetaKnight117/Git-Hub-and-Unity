using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    [SerializeField]
    private float fadeOutDuration = 1;

    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();


        canvasGroup.alpha = 0;

      
    }

    private IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;

        yield return new WaitForSeconds(duration);
        // start fading out
        float fadedElaspedTime = 0;
        float fadedStartTime = Time.time;
        while (fadedElaspedTime < fadeOutDuration)
        {
            fadedElaspedTime = Time.time - fadedStartTime;
            canvasGroup.alpha = 1 - fadedElaspedTime / fadeOutDuration;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

    private void OnConContextualMessageTriggered(string message, float messageDuration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessage(message, messageDuration));
    }

    private void OnEnable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered += OnConContextualMessageTriggered;
    }

    private void OnDisable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered -= OnConContextualMessageTriggered;
    }
}
