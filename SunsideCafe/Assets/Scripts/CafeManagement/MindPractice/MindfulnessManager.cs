using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MindfulnessManager : MonoBehaviour
{
    public static MindfulnessManager instance;

    public event EventHandler OnSuccessHit;

    [SerializeField] private mindfulState state;
    [SerializeField] private TextMeshProUGUI countdownText;

    [Header("Sequence Setup")]
    [SerializeField] private List<BreathingNote> notes;

    private int currentIndex;

    private float timeToCountdown = 3f;


    public enum mindfulState
    {
        WAIT,
        COUNTDOWN,
        SPAWN,
        WAITNOTE,
        CLEAR
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AudioManager.Instance.StopMusic();
        //StartNote();
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
                if (timeToCountdown <= 0f)
                {
                    state = mindfulState.SPAWN;
                    StartNote();
                    countdownText.gameObject.SetActive(false);
                }
                break;

        
        }
    }

    public void StartCountdown()
    {
        state = mindfulState.COUNTDOWN;
    }

    void StartNote()
    {
        if (currentIndex >= notes.Count)
        {
            Debug.Log("Sequence Complete");
            GameManager.instance.RemoveScene();
            return;
        }

        BreathingNote note = notes[currentIndex];

        note.gameObject.SetActive(true);

        note.OnSuccess += HandleSuccess;
        note.OnFail += HandleFail;

        note.Initialize();
    }

    void HandleSuccess(BreathingNote note)
    {
        Debug.Log("Success");

        GameEvents.OnPlaySFX.Invoke("PerfectHitSFX");
        OnSuccessHit?.Invoke(this, EventArgs.Empty);

        StartCoroutine(MoveNext(note));
    }

    void HandleFail(BreathingNote note)
    {
        Debug.Log("Fail");
        GameEvents.OnPlaySFX.Invoke("MissHitSFX");

        StartCoroutine(Restart(note));
    }

    IEnumerator MoveNext(BreathingNote note)
    {
        note.OnSuccess -= HandleSuccess;
        note.OnFail -= HandleFail;

        note.gameObject.SetActive(false);

        currentIndex++;

        yield return new WaitForSeconds(.5f);

        StartNote();
    }

    IEnumerator Restart(BreathingNote note)
    {
        note.OnSuccess -= HandleSuccess;
        note.OnFail -= HandleFail;

        note.gameObject.SetActive(false);

        yield return new WaitForSeconds(.5f);

        StartNote();
    }

}
