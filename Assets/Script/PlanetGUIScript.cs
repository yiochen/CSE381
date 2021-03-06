﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlanetGUIScript : MonoBehaviour {
    
    public ShipIconScript shipIcon;
    public Image OwnershipImage;
	public Slider combatBar;
	public Image upgradeIcon;
	public Image soldierIcon;

	private Light spotLight;
	private AbstractPlanet planet;

	private float flickerTimer = 0f;
	private const float FLICKER = 0.25f;
	private bool isWhite = false;
	private bool isSoundPlaying = false;

	// Use this for initialization
	void Start () {
        planet = transform.parent.gameObject.GetComponent<AbstractPlanet>();
		spotLight = combatBar.gameObject.GetComponentInChildren<Light> ();
		spotLight.type = LightType.Spot;
		spotLight.intensity = 0;
		combatBar.gameObject.SetActive (false);
		isSoundPlaying = false;
		//For Testing
		if (upgradeIcon) {
			upgradeIcon.gameObject.SetActive (false);
			soldierIcon.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
        switch (planet.planetOwnership)
        {
            case AbstractPlanet.Ownership.Enemy:
                OwnershipImage.color = Color.blue;
                break;
            case AbstractPlanet.Ownership.Player:
                OwnershipImage.color = Color.yellow;
                break;
            default:
                OwnershipImage.color = Color.gray;
                break;
        }
        if (planet.ships[Indices.SHIP_PLAYER] != null)
        {
            shipIcon.gameObject.SetActive(true);
        }
        else
        {
            shipIcon.gameObject.SetActive(false);
        }

		CombatSliderUpdates ();

		if(upgradeIcon)
			UpdateIconStatus ();
    }

	void UpdateIconStatus() {
		if (planet.GetIsTrainingSoldiers ())
			soldierIcon.gameObject.SetActive (true);
		else
			soldierIcon.gameObject.SetActive (false);

		if (ManagerScript.Instance.GetUpgrading () && planet.GetPlanetType() == AbstractPlanet.PlanetType.Reactor)
			upgradeIcon.gameObject.SetActive (true);
		else
			upgradeIcon.gameObject.SetActive (false);
	}

	void CombatSliderUpdates() {
		if (planet.isContested) {
			combatBar.gameObject.SetActive (true);

			float totalUnits = planet.enemySoldiers + planet.playerSoldiers;
			combatBar.value = planet.playerSoldiers / totalUnits;

			if (combatBar.normalizedValue <= 0.3f) {
				PlaySound ();
				spotLight.intensity = (1.0f - combatBar.normalizedValue) * 8;
				flickerTimer += Time.deltaTime;
				if (flickerTimer >= FLICKER) {
					if (isWhite)
						spotLight.color = Color.red;
					else
						spotLight.color = Color.white;

					isWhite = !isWhite;
					flickerTimer = 0;
				}
			} else {
				StopSound ();
				ResetLight ();
			}
		} else {
			StopSound ();
			ResetLight ();
			combatBar.gameObject.SetActive (false);
		}
	}

	void ResetLight() {
		spotLight.intensity = 0;
		flickerTimer = 0;
		spotLight.color = Color.red;
		isWhite = false;
	}

	void PlaySound() {
		if (!isSoundPlaying) {
			Debug.Log ("Play Sound");
			isSoundPlaying = true;
			ManagerScript.Instance.audioManager.PlaySound ("planetLosing");
		}
	}

	void StopSound() {
		if (isSoundPlaying) {
			Debug.Log ("Stop Sound");
			ManagerScript.Instance.audioManager.StopSound ("planetLosing");
			isSoundPlaying = false;
		}
	}
}
