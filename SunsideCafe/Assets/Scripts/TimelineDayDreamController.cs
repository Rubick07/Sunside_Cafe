using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;

public class TimelineDayDreamController : MonoBehaviour
{
    public static event EventHandler OnAnyTimelineStart;

    [SerializeField] private List<PlayableDirector> timelineList;

    private void Start()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().AddCommandHandler<string>("PlayCutscene", PlayCutscene);
        DialogRunnerSingleton.instance.GetDialogueRunner().AddCommandHandler<string>("RemoveCutscene", RemoveCutscene);

        PlayCutscene("Part1Daydream");
    }

    public void PlayCutscene(string timelineName)
    {
        PlayableDirector playableDirector = GetDirectorByTimelineName(timelineName);

        playableDirector.played += PlayableDirector_played;
        playableDirector.stopped += PlayableDirector_stopped;

        Debug.Log(playableDirector);
        playableDirector.Play();
    }

    private void PlayableDirector_stopped(PlayableDirector obj)
    {
        //obj.gameObject.SetActive(false);
    }

    private void PlayableDirector_played(PlayableDirector obj)
    {
        OnAnyTimelineStart?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveCutscene(string timelineName)
    {
        PlayableDirector playableDirector = GetDirectorByTimelineName(timelineName);

        playableDirector.gameObject.SetActive(false);

    }

    public PlayableDirector GetDirectorByTimelineName(string timelineName)
    {
        return timelineList.FirstOrDefault(d =>
            d.playableAsset != null &&
            d.playableAsset.name == timelineName
        );
    }

    private void OnDestroy()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().RemoveCommandHandler("PlayCutscene");
        DialogRunnerSingleton.instance.GetDialogueRunner().RemoveCommandHandler("RemoveCutscene");

    }
}
