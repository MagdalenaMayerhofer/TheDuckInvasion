using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    public Image playerGraphic;
    public Sprite grandma;
    public Sprite student;

    void Start()
    {
        CharacterInformation.character = CharacterInformation.Character.Student;
        playerGraphic.overrideSprite = student;

        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        switch(dropdown.value)
        {
            case 0:
                CharacterInformation.character = CharacterInformation.Character.Student;
                playerGraphic.overrideSprite = student;
                break;
            case 1:
                CharacterInformation.character = CharacterInformation.Character.Grandma;
                playerGraphic.overrideSprite = grandma;
                break;
        }
    }
}
