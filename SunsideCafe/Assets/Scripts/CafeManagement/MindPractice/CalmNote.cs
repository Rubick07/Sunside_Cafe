using UnityEngine;

public class CalmNote : MonoBehaviour
{
    [SerializeField] private RectTransform approachCircle;
    [SerializeField] private float duration = 2f; // waktu mengecil
    private float perfectWindow = 0.1f;
    private float goodWindow = 0.25f;

    float timer;
    bool isActive = true;

    void Update()
    {
        if (!isActive) return;

        timer += Time.deltaTime;

        float progress = timer / duration;

        // Shrink dari x size ke 3.5x size
        float scale = Mathf.Lerp(10f, 3.5f, progress);
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
            MindfulnessManager.instance.CalmSuccess();
        }
        else if (difference <= goodWindow)
        {
            MindfulnessManager.instance.CalmSuccess();
        }
        else
        {
            MindfulnessManager.instance.CalmFail();
        }

        EndNote();
    }

    void Miss()
    {
        MindfulnessManager.instance.CalmFail();
        EndNote();
    }

    void EndNote()
    {
        isActive = false;
        Destroy(gameObject);
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
}
