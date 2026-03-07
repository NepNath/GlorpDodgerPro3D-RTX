using UnityEngine;
using UnityEngine.UI;

public class SaveChecker : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Update()
    {
        if (!System.IO.File.Exists(SaveFunctions.savePath))
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }
}
