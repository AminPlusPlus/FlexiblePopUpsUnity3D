# FlexiblePopUpsUnity3D-1.0v

<a href="https://imgflip.com/gif/2bprkb"><img src="https://i.imgflip.com/2bprkb.gif" title="made at imgflip.com"/></a>

## Implementation with C# and "Fluent Interface Builder" 
if you want to know more detail about ["Fluent Interface"](https://en.wikipedia.org/wiki/Fluent_interface#C#.)

## How To Use It?
You can download UnityPackage from [HERE](https://drive.google.com/file/d/1pKuSY1SZUTZgGCTwyEr-VT8fjpEaf5NZ/view?usp=sharing)

Inside folder *Prefab*, use simple technic drag drop it under *Canvas* AUU DONE!

### Ok Then!
Insert namespace **using AminDialogPopUp**

**Example**

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AminDialogPopUp;


public class TestPopUp : MonoBehaviour 
{
	public Sprite box;
	public Sprite gold;
	public Sprite money;


	
	void OnTriggerEnter(Collider other)
	{
					AminDialogPopUpContent.Instance.setTitle("Wow Box!")
										   .setBodyMessage("Amazing You found Box but' its not free !")
										   .setIcon(box)
										   .addResources("85",money)
										   .addResources("999",gold)
										   .addResources("5646",money)
										   .addButton("Buy", () => AminDialogPopUpContent.Instance.closePopUp())
										   .addButton("Ok", () => AminDialogPopUpContent.Instance.closePopUp())
										   .create();
	}
	
}
```

## Done!



