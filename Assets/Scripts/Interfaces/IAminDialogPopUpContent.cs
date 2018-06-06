using System;
using UnityEngine;

namespace AminDialogPopUp.Interface
{
    public interface IAminDialogPopUpContent 
    {
	IAminDialogPopUpContent  setBodyMessage(string message);
	IAminDialogPopUpContent  setIcon(Sprite icon);
    IAminDialogPopUpContent  addButton(string text, Action action);
    IAminDialogPopUpContent  addResources(string value, Sprite icon);
    IAminDialogPopUpContent  create();

    }
}