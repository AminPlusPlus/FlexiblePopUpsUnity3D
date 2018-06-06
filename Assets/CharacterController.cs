using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AminDialogPopUp;

public class CharacterController : MonoBehaviour
{
	public float speed;

	public Sprite icon;
	
	void Start()
	{
			AminDialogPopUpContent.Instance.setTitle("Demo AminPopUp 1.0v")
										   .setBodyMessage("Welcome for Demo Version Feel Free to you use it!")
										   .setIcon(icon)
										   .addButton("Okey", () => AminDialogPopUpContent.Instance.closePopUp())
										   .create();
	}
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

       // transform.Rotate(0, x, 0);
		transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
    }
}
