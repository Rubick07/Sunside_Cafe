using System.Threading;
using TMPro;
using UnityEngine;
using Yarn.Markup;
using Yarn.Unity;

public class LinePresenterSoundAction : ActionMarkupHandler
{
    public override YarnTask OnCharacterWillAppear(int currentCharacterIndex, MarkupParseResult line, CancellationToken cancellationToken)
    {
        return YarnTask.CompletedTask;
    }

    public override void OnLineDisplayBegin(MarkupParseResult line, TMP_Text text)
    {
        GameEvents.OnPlaySFX.Invoke("DialogueSFX");

        return;
    }

    public override void OnLineDisplayComplete()
    {
        return;
    }

    public override void OnLineWillDismiss()
    {
        return;
    }

    public override void OnPrepareForLine(MarkupParseResult line, TMP_Text text)
    {
        return;
    }
}
