using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    float movementDistance = 150f;
    float movementSpeed = 1f;
    float speed = 2f;

    private RectTransform rectTransform;
    private Vector2 startPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        StartCoroutine(MoveUIObject());
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private IEnumerator MoveUIObject()
    {
        while (true)
        {
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * movementSpeed;
                float newY = Mathf.Lerp(startPosition.y, startPosition.y + movementDistance, t);
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
                yield return null;
            }

            yield return new WaitForSeconds(0.4f);

            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * movementSpeed;
                float newY = Mathf.Lerp(startPosition.y + movementDistance, startPosition.y, t);
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); // Wait for half a second at the bottom position
        }
    }
}
