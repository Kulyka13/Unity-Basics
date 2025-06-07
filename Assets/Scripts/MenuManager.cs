using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
	public string gameSceneName;
	public GameObject settingsPanel;

	public Slider slider;
	public Toggle toggle;
	public TMP_InputField inputField;

	public Image background;
	public TMP_Text nameText;

	private void Start()
	{
		
	}
	private void Update()
	{
		background.color = Color.HSVToRGB(slider.value, 1, 1);
		nameText.enabled = toggle.isOn;
		nameText.text = inputField.text;
	}
	public void PlayGame()
	{
		SceneManager.LoadScene(gameSceneName);
	}
	public void SettingsOn()
	{
		settingsPanel.SetActive(true);
	}
	public void SettingsOff()
	{
		settingsPanel.SetActive(false);
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
