using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class DieButtonUI : MonoBehaviour {

    public SpriteAtlas diceAtlas;
    public Button dieButton;
    public Image dieImage;

	public void AssignDie(Die die)
    {
        dieImage.sprite = diceAtlas.GetSprite("ui-dice_" + die.dieValue);
    }
}
