using UnityEngine;
using UnityEngine.UI;

public class changeButtonColor : MonoBehaviour
{
    private Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    private void Update()
    {
        switch (GameSettings.difficultyIndex)
        {
            case 1:
                Button.image.color = new Color( 109f / 255f,    //R
                                                255f / 255f,    //G
                                                78f / 255f,     //B
                                                255f / 255f );  //A
                break;
            case 2:
                Button.image.color = new Color( 255f / 255f,    //R
                                                181f / 255f,    //G
                                                0f / 255f,      //B
                                                255f / 255f );  //A
                break;
            case 3:
                Button.image.color = new Color( 255f / 255f,    //R
                                                18f / 255f,     //G
                                                18f / 255f,     //B
                                                255f / 255f );  //A
                break;
        }
    }
}
