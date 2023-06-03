using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeelManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI titleText;
    [SerializeField] Button playButton;
    Coroutine animateGameTitleRoutine = null;
    Coroutine animatePlayButtonRoutine = null;
    private void OnEnable()
    {
        animateGameTitleRoutine = StartCoroutine(AnimateGameTitleRoutine());
        animatePlayButtonRoutine = StartCoroutine(AnimatePlayButtonRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(animateGameTitleRoutine);
        StopCoroutine(animatePlayButtonRoutine);
    }

    IEnumerator AnimateGameTitleRoutine()
    {
        const float animationTime = 1.0f;
        float animationRuntime = 0.0f;
        yield return new WaitForSeconds(1.0f);
        while (true)
        {

            if (animationRuntime < 0.25f * animationTime)
            {
                titleText.rectTransform.localScale = Vector3.one * Mathf.Lerp(1.0f, 1.1f, animationRuntime / 0.25f);
            }
            else if (animationRuntime < 0.75f * animationTime)
            {
                titleText.rectTransform.localScale = Vector3.one * Mathf.Lerp(1.1f, 0.9f, (animationRuntime - 0.25f) / 0.5f);
            }
            else if (animationRuntime < 1.0f * animationTime)
            {
                titleText.rectTransform.localScale = Vector3.one * Mathf.Lerp(0.9f, 1.0f, (animationRuntime - 0.75f) / 0.25f);
            }

            animationRuntime += Time.deltaTime;
            if (animationRuntime >= animationTime)
            {
                animationRuntime = 0.0f;
            }
            yield return null;
        }
    }

    IEnumerator AnimatePlayButtonRoutine()
    {
        const float animationTime = 0.375f;
        float animationRuntime = 0.0f;
        yield return new WaitForSeconds(1.0f);
        while (true)
        {

            if (animationRuntime < 0.25f * animationTime)
            {
                playButton.transform.eulerAngles = Vector3.back * Mathf.Lerp(0.0f, 22.5f, animationRuntime / (0.25f * animationTime));
            }
            else if (animationRuntime < 0.75f * animationTime)
            {
                playButton.transform.eulerAngles = Vector3.back * Mathf.Lerp(22.5f, -22.5f, (animationRuntime - (0.25f * animationTime)) / (0.5f * animationTime));
            }
            else if (animationRuntime < 1.0f * animationTime)
            {
                playButton.transform.eulerAngles = Vector3.back * Mathf.Lerp(-22.5f, 0.0f, (animationRuntime - (0.75f * animationTime)) / (0.25f * animationTime));
            }

            animationRuntime += Time.deltaTime;
            if (animationRuntime >= 6*animationTime)
            {
                animationRuntime = 0.0f;
            }
            yield return null;
        }
    }


    [SerializeField] RectTransform settingsPanel;

    public void ShowSettings()
    {
        settingsPanel.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.gameObject.SetActive(false);
    }
}
