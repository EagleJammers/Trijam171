using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private bool isVisible;
    private bool hasMine;
    private bool hasFlag;
    private int value;
    private bool collapsed;
    [SerializeField]
    private GameObject FlagSprite;
    [SerializeField]
    private Text ValueText;

    public void Awake()
    {
        hasFlag = false;
        isVisible = false;
        collapsed = false;

        value = 0;
        UpdateText();
    }
    public bool PlayerMoveCheck() //false denotes a game over due to stepping on a mine
    {
        if (hasMine && hasFlag) //Tile is mined but flagged, so it's travelable
            return true;

        if (hasMine) //Game over!
            return false;

        if (!collapsed) //Tile is stepped on, and has never been traveled on before
            collapsed = true;

        return true;
    }

    public void DisplayValueToggle()
    {
       isVisible = !isVisible;
        FlagSprite.SetActive(isVisible);
       
    }

    public void FlagToggle()
    {
        
        hasFlag = !hasFlag;
        FlagSprite.SetActive(hasFlag);
    }

    public void IncrementValue() //Called by board manager when an adjacent mine is discovered
    {
        value++;
        UpdateText();
    }

    private void UpdateText()
    {
        ValueText.text = value.ToString();
    }
}
