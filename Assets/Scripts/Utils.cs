using UnityEngine;

public class Utils: MonoBehaviour
{
    public static void CreateRubberDuckInstance(GameObject rubberDuckPrefab)
    {
        var rightBorder = Camera.main.ViewportToWorldPoint( new Vector3(1, 0, 0)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        Vector3 position = new Vector3(rightBorder, Random.Range(topBorder, bottomBorder), 0);
        Instantiate(rubberDuckPrefab, position, Quaternion.identity);
    }
}
