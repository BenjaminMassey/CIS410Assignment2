using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class VignetteLI : MonoBehaviour
{
    // Modified vignette based on player's closeness to enemies

    public GameObject player;
    public GameObject[] enemies;
    PostProcessVolume volume;
    Vector3 playerPosition;
    Vignette vignette;
    float a; // min for vignette
    float b; // max for vignette
    float f; // num between 0 and 1 to control vignette

    // Start is called before the first frame update
    void Start()
    {
        // Need volume to mess with vignette
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
        // a and b can be modified depending on wanted intensity
        a = 0.0f;
        b = 1.0f;
        f = 0.0f;
    }

    // Update is called thirty times per second
    void FixedUpdate()
    {
        // Get enemy positions
        playerPosition = player.transform.position;
        Vector3[] enemyPositions = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyPositions[i] = enemies[i].transform.position;
        }

        // Find closest enemy's distance to player
        float minDistance = Mathf.Infinity;
        float distance;
        foreach (Vector3 enemyPosition in enemyPositions)
        {
            distance = Vector3.Distance(playerPosition, enemyPosition);
            minDistance = Mathf.Min(minDistance, distance);
        }
        
        // Use distance to change vignette
        f = 1 - ((minDistance - 1) / 6.0f); // make distance in terms that work (decimal)
        f = Mathf.Min(1.0f, f); // make sure at most 1
        f = Mathf.Max(0.0f, f); // make sure at least 0
        vignette.intensity.value = (1 - f) * a + f * b;
    }
}
