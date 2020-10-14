using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        switch(dropdown.value)
        {
            case 0:
                CharacterInformation.character = CharacterInformation.Character.Student;
                break;
            case 1:
                CharacterInformation.character = CharacterInformation.Character.Grandma;
                break;
        }
    }
}
