using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AminDialogPopUp;


public class TestPopUp : MonoBehaviour 
{
	public TypeObject type;

	public Sprite weapon;
	public Sprite box;
	public Sprite gold;
	public Sprite money;


	
	void OnTriggerEnter(Collider other)
	{
	
		switch (type)
		{
			case TypeObject.Weapon:
			
			AminDialogPopUpContent.Instance.setTitle("Weapon Milod98")
										   .setBodyMessage("Amazing You found Weapon but' its not free !")
										   .setIcon(weapon)
										   .addResources("85",money)
										   .addButton("Buy", () => AminDialogPopUpContent.Instance.closePopUp())
										   .create();
		
			break;

			case TypeObject.EmptyBox:

					AminDialogPopUpContent.Instance.setTitle("Wow Box!")
										   .setBodyMessage("Amazing You found Box but' its not free !")
										   .setIcon(box)
										   .addResources("85",money)
										   .addResources("999",gold)
										   .addResources("5646",money)
										   .addButton("Buy", () => AminDialogPopUpContent.Instance.closePopUp())
										   .addButton("Ok", () => AminDialogPopUpContent.Instance.closePopUp())
										   .create();
		

			break;

			default:
			break;
		}
	}
	
}


public enum TypeObject
{
	Weapon,
	EmptyBox
}
