using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int totalItemsInLevel = 0;
    private int itemsFound = 0;
    private int score = 0;
    public TMP_Text hiddenItemsTextUI;
    public TMP_Text scoreTextUI;
    public TMP_Text timeTextUI;
    public TMP_Text clickCountTextUI;
    private float timeElapsed = 0f;
    private int clickCount = 0;

    private List<string> hiddenItemNames = new List<string>();

    void Update()
{
    timeElapsed += Time.deltaTime;
    UpdateTimeUI();
}
private void UpdateTimeUI()
{
    if (timeTextUI != null)
        timeTextUI.text = "" + Mathf.FloorToInt(timeElapsed) + "s";
}


    public void RegisterHiddenItem(string itemName)
    {
        hiddenItemNames.Add(itemName);
        UpdateHiddenItemsUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
        Debug.Log("Score: " + score);
    }

    private void UpdateScoreUI()
    {
    if (scoreTextUI != null)
        scoreTextUI.text = "" + score;
    }

    public void FoundItem(string itemName)
    {
        itemsFound++;
        hiddenItemNames.Remove(itemName);
        UpdateHiddenItemsUI();

        Debug.Log($"Item found! {itemsFound}/{totalItemsInLevel}");

        if (itemsFound >= totalItemsInLevel)
        {
            Debug.Log("All items found! Proceeding to next level...");
            LoadNextScene();
        }
    }

    private void UpdateHiddenItemsUI()
    {
        if (hiddenItemsTextUI != null)
        {
            hiddenItemsTextUI.text = "Items left:" + string.Join(", ", hiddenItemNames);
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RegisterClick()
{
    clickCount++;
    UpdateClickUI();
}
private void UpdateClickUI()
{
    if (clickCountTextUI != null)
        clickCountTextUI.text = "" + clickCount;
}


    private void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            itemsFound = 0;
            totalItemsInLevel = 0;
        }
        else
        {
            Debug.Log("You completed all levels!");
        }
    }
}
