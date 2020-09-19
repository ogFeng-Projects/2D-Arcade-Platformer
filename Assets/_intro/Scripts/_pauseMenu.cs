using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _pauseMenu : MonoBehaviour
{
	private bool isPaused;
	public GameObject pausePanel;
	public string mainMenu;

	void Start()
    {
		isPaused = false;
	}

    void Update()
    {
		if (Input.GetButtonDown("pause"))
		{
			isPaused = !isPaused;
			if (isPaused)
			{
				pausePanel.SetActive(true);
				Time.timeScale = 0f;
			}
			else
			{
				pausePanel.SetActive(false);
				Time.timeScale = 1f;
			}
		}
	}

	public void Resume()
	{
		isPaused = !isPaused;
	}

	public void QuitToMain()
	{
		SceneManager.LoadScene(mainMenu);
	}
}
