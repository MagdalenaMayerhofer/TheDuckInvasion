using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject grandmaPrefab;
    public GameObject studentPrefab;

    GameObject chosenCharacterPrefab;

    // Start is called before the first frame update
    void Start()
    {

        GetPlayerCharacter();

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.17f, 0, 0)).x;
        var verticalMiddle = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y;

        Vector3 position = new Vector3(leftBorder, verticalMiddle, 0);
        Instantiate(chosenCharacterPrefab, position, Quaternion.identity);
    }

    public void GetPlayerCharacter()
    {
        switch (CharacterInformation.character)
        {
            case CharacterInformation.Character.Grandma:
                chosenCharacterPrefab = grandmaPrefab;
                break;
            case CharacterInformation.Character.Student:
                chosenCharacterPrefab = studentPrefab;
                break;
        }
    }
}
