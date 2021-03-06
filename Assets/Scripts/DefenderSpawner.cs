﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    bool youCanPlaceHim;
    Defender defender;

    private void OnMouseDown()
    {

        AttemptToPlaceDefenderAt(GetSquareClicked());
    }


    public void SetSelectedDefender(Defender defenderToSelect)
    {
        //Grab from DefenderButton which prefab is currently selected.
        defender = defenderToSelect;

    }

    bool IsThereAnyoneHere()
    {
        // Check and see if there is another defender on the square.
        // FindObjectsByType Defender.  Gettransform. 

        var defenders = FindObjectsOfType<Defender>();
        foreach (Defender placedDefender in defenders)
        {
            var placedDefenderPosition = new Vector2(placedDefender.transform.position.x, placedDefender.transform.position.y);

            if (placedDefenderPosition == GetSquareClicked())
            {
                youCanPlaceHim = false;
                break;
            }
            else
            {
                youCanPlaceHim = true;
            }

        }
        return youCanPlaceHim;

    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if (StarDisplay.HaveEnoughStars(defenderCost) && IsThereAnyoneHere())
        {

            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {

        Defender newDefender = Instantiate(defender, roundedPos, transform.rotation) as Defender;
    }
}
