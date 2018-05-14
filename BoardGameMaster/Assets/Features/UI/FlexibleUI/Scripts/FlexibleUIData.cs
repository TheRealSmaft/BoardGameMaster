using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flexible UI Data")]
public class FlexibleUIData : ScriptableObject {

    public Sprite buttonSprite;
    public SpriteState buttonSpriteState;

    public Color defaultColor;
    public Color defaultTextColor;
    public Sprite defaultIcon;

    public Color confirmColor;
    public Color confirmTextColor;
    public Sprite confirmIcon;

    public Color declineColor;
    public Color declineTextColor;
    public Sprite declineIcon;

    public Color warningColor;
    public Color warningTextColor;
    public Sprite warningIcon;

    public Color rollDiceColor;
    public Color rollDiceTextColor;
    public Sprite rollDiceIcon;

}
