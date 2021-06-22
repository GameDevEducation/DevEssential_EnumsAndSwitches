using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchesDemo : MonoBehaviour
{
    public enum ECategory
    {
        LevelGeometry,
        StaticDecorations,
        Characters,
        InteractableItems,
        Pickups
    }

    public ECategory Category = ECategory.LevelGeometry;

    // Start is called before the first frame update
    void Start()
    {
        switch(Category)
        {
            case ECategory.LevelGeometry:
                Debug.Log("Level geometry");
            break; // closes off the case - switch exits at this point

            case ECategory.InteractableItems: // this one has no break so it falls through to the next case
            case ECategory.Pickups:
                Debug.Log("Interactable or pickup");
            break;

            default: // runs if none of the other cases matched
                Debug.LogError("No handling for if Category is " + Category);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
