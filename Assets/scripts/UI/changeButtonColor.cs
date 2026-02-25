using UnityEngine;
using UnityEngine.UI;

public class changeButtonColor : MonoBehaviour
{
    private Button Button;
    private ColorBlock colors;


    private void Awake()
    {
        Button = GetComponent<Button>();
        colors = Button.colors;
    }

    private void Update()
    {
        switch (GameSettings.difficultyIndex)
        {
            case 1:
                //vert
                break;
            case 2:
                //orange
                break;
            case 3:
                //rouge
                break;
        }
    }
}
