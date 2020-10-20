using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
    public Sprite freezeSprite;
    public Sprite normalSprite;

    private bool hasSpawn;
    private MoveScript moveScript;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;

    void Awake()
    {
        // Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();

        coliderComponent = GetComponent<Collider2D>();

        rendererComponent = GetComponent<SpriteRenderer>();
    }

    // 1 - Disable everything
    void Start()
    {
        hasSpawn = false;

        // Disable everything
        // -- collider
        coliderComponent.enabled = false;
        // -- Moving
        moveScript.enabled = false;
    }

    void Update()
    {
        // 2 - Check if the enemy has spawned.
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            // 4 - Out of the camera ? Destroy the game object.
            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    // 3 - Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        // -- Collider
        coliderComponent.enabled = true;
        // -- Moving
        moveScript.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null && shot.gameObject.GetComponent<PrefabInstance>().prefabProperty ==  PrefabInstance.PrefabProperty.BreadPrefab)
        {

            SpecialEffectsHelper.Instance.EatBread(transform.position);
            SoundEffectsHelper.Instance.MakeCrunchSound();

            // Dead!
            Destroy(gameObject);

            // Destroy the shot
            Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script

            ScoreScript.scoreValue++;
            Utils.Instance.CreateRubberDuckInstance();
            Utils.Instance.CreateRubberDuckInstance();

        } else if (shot != null && shot.gameObject.GetComponent<PrefabInstance>().prefabProperty == PrefabInstance.PrefabProperty.IcePrefab)
        {

            //SpecialEffectsHelper.Instance.EatBread(transform.position);
            SoundEffectsHelper.Instance.MakeFreezeSound();

            rendererComponent.sprite = freezeSprite;
            moveScript.movingEnabled = false;

            // Destroy the shot
            Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script

            //Start the coroutine we define below named ExampleCoroutine.
            StartCoroutine(Wait2Seconds());

        }
    }

    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2);

        rendererComponent.sprite = normalSprite;
        moveScript.movingEnabled = true;

    }
}