using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchWeapons : MonoBehaviour {
    
    public GameObject axe;
    public GameObject bow;
    public GameObject gun;
    public Text SelectedWeapon;
	public Text SelectedAmmunition;
	PlayerWeapons pw;

	void Start () {
        SelectedWeapon.text = "Selected Weapon: Gun";
		if (gun.activeSelf) {
			GameObject gm = GameObject.FindWithTag ("gun");
			pw = gm.GetComponent<PlayerWeapons> ();
		}
	}

	
	void Update () {
       
            //Bow
            if (Input.GetKeyDown(KeyCode.O))
            {
                SelectedWeapon.text = "Selected Weapon: Bow";
                bow.SetActive(true);
                axe.SetActive(false);
                gun.SetActive(false);
            } 
            //Axe
            else if (Input.GetKeyDown(KeyCode.I))
            {
                SelectedWeapon.text = "Selected Weapon: Axe";
                axe.SetActive(true);
                bow.SetActive(false);
                gun.SetActive(false);
            }
            //Gun
            else if (Input.GetKeyDown(KeyCode.P))
            {
                SelectedWeapon.text = "Selected Weapon: Gun";
				
                gun.SetActive(true);
                bow.SetActive(false);
                axe.SetActive(false);
                if (gun.activeSelf)
                {
                    print("IN Gun");
                    print(pw.weaponSelected);
                    if (pw.weaponSelected == 0)
                        SelectedAmmunition.text = "Selected Ammunition : Capsule";
                    else if (pw.weaponSelected == 1)
                        SelectedAmmunition.text = "Selected Ammunition : Bomb";
                    else if (pw.weaponSelected == 2)
                        SelectedAmmunition.text = "Selected Ammunition : ExplosionBomb";
                }

            }
		}
}
