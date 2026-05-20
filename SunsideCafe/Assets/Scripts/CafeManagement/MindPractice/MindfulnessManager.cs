using UnityEngine;
using System;
using TMPro;

public class MindfulnessManager : MonoBehaviour
{
    public static MindfulnessManager instance;

    public event EventHandler OnSuccessHit;

    public enum mindfulState
    {
        WAIT,
        COUNTDOWN,
        SPAWN,
        WAITNOTE,
        CLEAR
    }

    [SerializeField] private mindfulState state;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private Transform calmNoteTransfomPrefab;
    [SerializeField] private Transform calmNoteTransformContainer;

    private float timeToCountdown = 3f;
    private float timeToSpawn = 2f;

    private int success;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AudioManager.Instance.StopMusic();
    }

    private void Update()
    {
        switch (state)
        {
            case mindfulState.WAIT:

                break;

            case mindfulState.COUNTDOWN:
                timeToCountdown -= Time.deltaTime;
                countdownText.text = timeToCountdown.ToString("0");
                if(timeToCountdown <= 0f)
                {
                    state = mindfulState.SPAWN;
                    countdownText.gameObject.SetActive(false);
                }
                break;

            case mindfulState.SPAWN:
                timeToSpawn -= Time.deltaTime;
                if(timeToSpawn <= 0)
                {
                    SpawnNote();
                    state = mindfulState.WAITNOTE;
                }
                break;

            case mindfulState.WAITNOTE:

                break;

            case mindfulState.CLEAR:

                break;
        }
    }

    public void CalmSuccess()
    {
        GameEvents.OnPlaySFX.Invoke("PerfectHitSFX");

        success++;

        OnSuccessHit?.Invoke(this, EventArgs.Empty);

        if(success == 3)
        {
            //MinigamesClear
            state = mindfulState.CLEAR;
            GameManager.instance.RemoveScene();
        }
        else
        {
            timeToSpawn = 3f;
            state = mindfulState.SPAWN;
        }
    }

    public void CalmFail()
    {
        GameEvents.OnPlaySFX.Invoke("MissHitSFX");

        success = 0;
        timeToSpawn = 3f;
        state = mindfulState.SPAWN;
    }
    public void SpawnNote()
    {
        Transform calmNoteTransform = Instantiate(calmNoteTransfomPrefab, calmNoteTransformContainer.position, Quaternion.identity, calmNoteTransformContainer);

        calmNoteTransform.SetAsFirstSibling();

        CalmNote calmNote = calmNoteTransform.GetComponent<CalmNote>();
        if(success == 0)
        {
            calmNote.SetDuration(1f);
        }
        else if(success == 1)
        {
            calmNote.SetDuration(2f);
        }
        else if(success == 2)
        {
            calmNote.SetDuration(3f);
        }
    }

    public void StartGame()
    {
        state = mindfulState.COUNTDOWN;
        
    }

}
