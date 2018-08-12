using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to pause a game
 * and change quality settings 
 */ 
public class QualityChooser : MonoBehaviour 
{
	// GUI panel for the pause screen
	public GameObject panelGo;

	// GUI slider for adjusting quality settings from the pause screen
	public Slider slider;

	// GUI Text label for quality settings
	public Text textLabel;

	// Boolean variable for adotping expensive changes (anti-alias, etc.) when changing quality settings
	public bool expensiveQualitySettings = true;

	/* ----------------------------------------
	 * At Start, make mouse cursor invisible, adjust UI Slider settings 
	 * and set UI Panel inactive.
	 */ 	
	void Awake () {
		// Set number of available quality settings as the maximum value of the GUI slider
		slider.maxValue = QualitySettings.names.Length - 1;

		// Set current Quality Level as the current value of the GUI slider
		slider.value = QualitySettings.GetQualityLevel();

		// make our slider and cursor active
		SetQualitySliderActive(false);
	}

	public void SetQualitySliderActive(bool active)
	{
		// show cursor and panel if Active
		// otherwise hide cursor and panel
		Cursor.visible = active;
		panelGo.SetActive(active);
	}

	/* ----------------------------------------
	 * A function to change quality settings to be accessed from
	 * the UI Slider
	 */
	public void UpdateQuality(float sliderFloat)
	{
		// Convert UI slider float to Int
		int qualityInt = Mathf.RoundToInt (sliderFloat);

		// Set Quality level to Int value from UI slider
		QualitySettings.SetQualityLevel (qualityInt);
		
		// Set the name of the chosen quality level as text of GUI text label
		textLabel.text = QualitySettings.names [qualityInt];
	}
}
