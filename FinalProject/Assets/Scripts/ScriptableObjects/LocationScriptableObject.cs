using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

[CreateAssetMenu (
   fileName = "New Location",
   menuName = "ScriptableObjects/Location",
   order = 0
   )]

public class LocationScriptableObject : ScriptableObject
{
   public string locationName;
   public Sprite backdrop;
   
   public Button gameButton;

   public LocationScriptableObject left;
   public LocationScriptableObject right;
}