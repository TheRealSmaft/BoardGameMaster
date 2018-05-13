using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Text))]
public class FlexibleUIButton : FlexibleUI {

    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning
    }

    Image image;
    Image icon;
    Text text;
    Button button;

    public ButtonType buttonType;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        image = GetComponent<Image>();
        icon = transform.Find("Icon").GetComponent<Image>();
        text = transform.Find("Text").GetComponent<Text>();
        button = GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = skinData.buttonSpriteState;

        switch(buttonType)
        {
            case ButtonType.Default:
                image.color = skinData.defaultColor;
                icon.sprite = skinData.defaultIcon;
                text.color = skinData.defaultTextColor;
                break;
            case ButtonType.Confirm:
                image.color = skinData.confirmColor;
                icon.sprite = skinData.confirmIcon;
                text.color = skinData.confirmTextColor;
                break;
            case ButtonType.Decline:
                image.color = skinData.declineColor;
                icon.sprite = skinData.declineIcon;
                text.color = skinData.declineTextColor;
                break;
            case ButtonType.Warning:
                image.color = skinData.warningColor;
                icon.sprite = skinData.warningIcon;
                text.color = skinData.warningTextColor;
                break;
        }
    }
}
