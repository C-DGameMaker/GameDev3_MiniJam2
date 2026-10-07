using UnityEngine;

public class TalkOrRead : MonoBehaviour,Interactable
{
    [TextArea]public string[] Dialog;

    public void OnInteract()
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
