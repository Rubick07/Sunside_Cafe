using UnityEngine;

public class CalmNote : MonoBehaviour
{
    public RectTransform approachCircle;
    public float duration = 2f; // waktu mengecil
    public float perfectWindow = 0.1f;
    public float goodWindow = 0.25f;

    float timer;
    bool isActive = true;

    void Update()
    {
        if (!isActive) return;

        timer += Time.deltaTime;

        float progress = timer / duration;

        // Shrink dari 2x size ke 1x size
        float scale = Mathf.Lerp(10f, 1f, progress);
        approachCircle.localScale = Vector3.one * scale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckHit();
        }

        if (timer >= duration + goodWindow)
        {
            Miss();
        }
    }

    void CheckHit()
    {
        float difference = Mathf.Abs(timer - duration);

        if (difference <= perfectWindow)
        {
            Debug.Log("PERFECT");
        }
        else if (difference <= goodWindow)
        {
            Debug.Log("GOOD");
        }
        else
        {
            Debug.Log("BAD");
        }

        EndNote();
    }

    void Miss()
    {
        Debug.Log("MISS");
        EndNote();
    }

    void EndNote()
    {
        isActive = false;
        Destroy(gameObject);
    }
}
