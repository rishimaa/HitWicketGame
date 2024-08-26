using UnityEngine;
using TMPro;
using System.Collections;

public class PulpitManager : MonoBehaviour
{
    public GameObject[] pulpits;    // Array of pulpits to manage
    private float minActivationTime;   // Minimum time each pulpit stays active
    private float maxActivationTime;   // Maximum time each pulpit stays active
    private float delayBetweenActivations; // Delay before the next pulpit activates

    private GameManager gameManager; // Reference to the GameManager

    void Start()
    {
        // Get reference to GameManager to access the gameData
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null && gameManager.gameData != null)
        {
            Debug.Log("Success");
            // Set the activation time range and delay from the JSON data
            minActivationTime = gameManager.gameData.pulpit_data.min_pulpit_destroy_time;
            maxActivationTime = gameManager.gameData.pulpit_data.max_pulpit_destroy_time;
            delayBetweenActivations = gameManager.gameData.pulpit_data.pulpit_spawn_time;
        }
        else
        {
            Debug.LogError("GameManager or GameData not found! Using default values.");
            // Set default values if the GameManager or GameData isn't found
            minActivationTime = 2f;
            maxActivationTime = 4f;
            delayBetweenActivations = 1.5f;
        }

        // Deactivate all pulpits except the first one
        for (int i = 1; i < pulpits.Length; i++)
        {
            pulpits[i].SetActive(false);
            UpdatePulpitTimer(pulpits[i], "");  // Set the initial timer text to empty
        }
        // Ensure the first pulpit is active at the start
        pulpits[0].SetActive(true);

        // Start the pulpit activation cycle
        StartCoroutine(ManagePulpitCycle());
    }

    IEnumerator ManagePulpitCycle()
    {
        int pulpitCount = pulpits.Length;

        while (true)
        {
            for (int i = 0; i < pulpitCount; i++)
            {
                // Activate the current pulpit
                pulpits[i].SetActive(true);

                // Calculate a random activation time within the specified range
                float randomActivationTime = Random.Range(minActivationTime, maxActivationTime);

                // Start the coroutine to manage the timer and deactivate the pulpit
                StartCoroutine(HandlePulpitTimer(pulpits[i], randomActivationTime));

                // Wait for the delay before activating the next pulpit
                yield return new WaitForSeconds(delayBetweenActivations);
            }
        }
    }

    IEnumerator HandlePulpitTimer(GameObject pulpit, float duration)
    {
        float timer = duration;
        TextMeshProUGUI timerText = pulpit.GetComponentInChildren<TextMeshProUGUI>();

        if (timerText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on " + pulpit.name);
            yield break; // Exit the coroutine if no TextMeshProUGUI component is found
        }

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");
            yield return null;
        }

        // Deactivate the pulpit and clear the timer text
        pulpit.SetActive(false);
        timerText.text = "";
    }

    void UpdatePulpitTimer(GameObject pulpit, string timeText)
    {
        TextMeshProUGUI timerText = pulpit.GetComponentInChildren<TextMeshProUGUI>();
        if (timerText != null)
        {
            timerText.text = timeText;
        }
    }
}
