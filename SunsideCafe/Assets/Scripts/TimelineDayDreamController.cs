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
    }

    public void PlayCutscene(string timelineName)
    {
        PlayableDirector playableDirector = GetDirectorByTimelineName(timelineName);
        playableDirector.Play();
    }

    public PlayableDirector GetDirectorByTimelineName(string timelineName)
    {
        return timelineList.FirstOrDefault(d =>
            d.playableAsset != null &&
            d.playableAsset.name == timelineName
        );
    }


}
