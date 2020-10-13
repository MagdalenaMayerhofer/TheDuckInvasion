using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform foodPrefab;
    public Transform icePrefab;


    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void FoodAttack()
    {
        // Create a new shot
        var shotTransform = Instantiate(foodPrefab);

        // Assign position
        shotTransform.position = transform.position;

        // The is enemy property
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

        // Make the weapon shot always towards it
        MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
        if (move != null)
        {
            move.direction = this.transform.right; // towards in 2D space is the right of the sprite
        }
    }

    public void IceAttack()
    {
        // Create a new shot
        var shotTransform = Instantiate(icePrefab);

        // Assign position
        shotTransform.position = transform.position;

        // The is enemy property
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

        // Make the weapon shot always towards it
        MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
        if (move != null)
        {
            move.direction = this.transform.right; // towards in 2D space is the right of the sprite
        }
    }
}
