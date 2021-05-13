using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
	///<summary>Play Button</summary>
	public Button PlayButton;
	///<summary>Quit Button</summary>
	public Button QuitButton;
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

	void Start () 
	{
		Button play = PlayButton.GetComponent<Button>();
		play.onClick.AddListener(PlayOnClick);
		Button quit = QuitButton.GetComponent<Button>();
		quit.onClick.AddListener(QuitMaze);
	}

	void PlayOnClick()
	{
		if (colorblindMode.isOn is true)
		{
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		}
		else
		{
			trapMat.color = Color.red;
			goalMat.color = Color.green;
		}
        SceneManager.LoadScene("maze");
	}
	public void QuitMaze()
	{
		Debug.Log($"Quit Game");
		Application.Quit();
	}
}
