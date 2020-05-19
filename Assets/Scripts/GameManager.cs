using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject levelCompletedText;
    public Text energyText;
    public GameObject gameOverText;
    public string nextLevel;
    public string gameOverLevel;

    public GameObject puta;

    public static GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LevelCompleted()
    {
        levelCompletedText.SetActive(true);
        StartCoroutine(LoadNextLevel());      
    }

    public void UpdateHealth(int health)
    {       
        energyText.text = "Energy: " + health + " %";

        if (health == 0)
            GameOver();
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);
        puta.SetActive(true);
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver ()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(gameOverLevel);
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextLevel);
    }
}
