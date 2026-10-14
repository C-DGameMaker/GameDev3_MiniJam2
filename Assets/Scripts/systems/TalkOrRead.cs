using UnityEngine;

public class TalkOrRead : MonoBehaviour,IInteractable
{
    [TextArea]public string[] Dialog;

    public void Interact()
    {
        Debug.Log("talked");
        if (!DialogManager.dialogManager.talking)
        {
            DialogManager.dialogManager.StartDialog(Dialog);
        }
        else
        {
            DialogManager.dialogManager.ContinueDialog();
        }
    }
}
