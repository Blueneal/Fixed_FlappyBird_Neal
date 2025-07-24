using System.Collections;
using UnityEngine;

public class BounceUI : MonoBehaviour
{
    public float bounceHeight = 50f;        
    public float bounceDuration = 0.5f;     

    private RectTransform rectTransform;
    private Vector2 startAnchoredPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPos = rectTransform.anchoredPosition;
        StartCoroutine(BounceUp());
    }

    /// <summary>
    /// Bounces the title screen text up by the MoveVertical() function transform
    /// </summary>
    /// <returns></returns>
    IEnumerator BounceUp()
    {
        yield return StartCoroutine(MoveVertical(startAnchoredPos, startAnchoredPos + Vector2.up * bounceHeight, bounceDuration));
        StartCoroutine(BounceDown());
    }

    /// <summary>
    /// Bounces the title screen text down by the MoveVertical() function transform
    /// </summary>
    /// <returns></returns>
    IEnumerator BounceDown()
    {
        yield return StartCoroutine(MoveVertical(startAnchoredPos + Vector2.up * bounceHeight, startAnchoredPos, bounceDuration));
        StartCoroutine(BounceUp());
    }

    /// <summary>
    /// Calculates the speed and positioning to move the Title text depending on its starting point in the transformation within a certain speed
    /// FROM moves it up FROM the starting point
    /// TO moves it down back to the starting point
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator MoveVertical(Vector2 from, Vector2 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = to;
    }
}
