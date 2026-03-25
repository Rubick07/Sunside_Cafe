using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;

public class TimelineDayDreamController : MonoBehaviour
{
    [SerializeField] private List<PlayableDirector> timelineList;

    private void Start()
    {
        DialogRunnerSingleton.instance.GetDialogueRunner().AddCommandHandler<string>("PlayCutscene", PlayCutscene);
        DialogRunnerSingleton.instance.GetDialogueRunner().AddCommandHandler<string>("RemoveCutscene", RemoveCutscene);
    }

    public void PlayCutscene(string timelineName)
    {
        PlayableDirector playableDirector = GetDirectorByTimelineName(timelineName);
        Debug.Log(playableDirector);
        playableDirector.Play();
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
