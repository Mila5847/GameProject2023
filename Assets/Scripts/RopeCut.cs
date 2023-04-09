using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    public GameObject markerPrefab;
    public float duration = 0.05f;
    public float fadeTime = 0.05f;
    public float ropeCutDelay = 30f;
    private GameObject redRope;

    // Start is called before the first frame update
    void Start()
    {
        // Find the red rope
        GameObject rope = GameObject.FindGameObjectWithTag("RedRope");
        redRope = rope;

        // Cut the red rope after a delay
        if (redRope != null)
        {
            InvokeRepeating("CutRope", ropeCutDelay, 1f);
        }
    }

    void CutRope()
    {
        // Find a random link in the red rope to cut
        int linkCount = redRope.transform.childCount;
        int linkIndex = Random.Range(0, linkCount);

        // Destroy the link and its joint
        GameObject link = redRope.transform.GetChild(linkIndex).gameObject;
        Destroy(link.GetComponent<HingeJoint2D>());
        Destroy(link);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject marker = Instantiate(markerPrefab, clickPosition, Quaternion.identity);
            StartCoroutine(FadeMarker(marker));

            //Spawning ray at point of mouse position, ray is async pointer
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Link")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private IEnumerator FadeMarker(GameObject marker)
    {
        SpriteRenderer renderer = marker.GetComponent<SpriteRenderer>();
        float timer = 0.04f;

        // Fade in the marker
        while (timer < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 0.2f, timer / fadeTime);
            renderer.color = new Color(1f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Wait for the duration
        yield return new WaitForSecondsRealtime(duration - 2f * fadeTime);

        // Fade out the marker
        timer = 0.04f;
        while (timer < fadeTime)
        {
            float alpha = Mathf.Lerp(0.2f, 0f, timer / fadeTime);
            renderer.color = new Color(1f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(marker);
    }
}
