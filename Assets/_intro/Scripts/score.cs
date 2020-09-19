using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
   public int scores = 0;
   public void UpdateScore()
   {
       GetComponent<Text>().text = "Score: " + scores;
   }

}
