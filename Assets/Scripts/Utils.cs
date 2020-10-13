using UnityEngine;


public class Utils : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static Utils Instance;

    public GameObject rubberDuckPrefab;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void CreateRubberDuckInstance()
    {
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1.08f, 0, 0)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        Vector3 position = new Vector3(rightBorder, Random.Range(topBorder, bottomBorder), 0);
        Instantiate(rubberDuckPrefab, position, Quaternion.identity);
    }
}