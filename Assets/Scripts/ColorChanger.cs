using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
    

    public static void SetRandomColor(Player player)
    {
        string current = player.currColor;
        int color = Random.Range(0, 4);

        switch (color)
        {
            case 0:
                player.currColor = "Red";
                player.sr.color = player.red;
                break;
            case 1:
                player.currColor = "Blue";
                player.sr.color = player.blue;

                break;
            case 2:
                player.currColor = "Green";
                player.sr.color = player.green;

                break;
            case 3:
                player.currColor = "Yellow";
                player.sr.color = player.yellow;

                break;
        }
        if (current == player.currColor)
        {
            SetRandomColor(player);
        }
        else return;
    }
}
