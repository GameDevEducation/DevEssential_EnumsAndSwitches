using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumsDemo : MonoBehaviour
{
    public enum EMovementType
    {
        SlowBounce, // 0
        FastBounce, // 1
        SlowPulse,  // 2
        FastPulse,  // 3

        NumMovementTypes
    }

    // 0 =    0
    // 1 =    1 *
    // 2 =   10 *
    // 3 =   11
    // 4 =  100 *
    // 5 =  101
    // 6 =  110
    // 7 =  111
    // 8 = 1000 *

    // << is the left shift operator
    public enum EMovementCapabilities
    {
        OnGround        = 1 << 0,   // 1 = 0001
        InAir           = 1 << 1,   // 2 = 0010
        InWater         = 1 << 2,   // 4 = 0100
        BelowGround     = 1 << 3    // 8 = 1000
    }

    public EMovementType Movement = EMovementType.SlowBounce;
    public int MovementCapabilities = (int)EMovementCapabilities.OnGround | (int)EMovementCapabilities.InAir; // 0001 | 0010 => 0011

    // Start is called before the first frame update
    void Start()
    {
        // debug log the enum - convert from enum to int
        Debug.Log(EMovementType.SlowBounce + " is " + (int)EMovementType.SlowBounce);

        // debug log - convert from int to enum
        Debug.Log(3 + " is " + (EMovementType)3);

        // dump all enum values
        for (int enumIndex = 0; enumIndex < (int)EMovementType.NumMovementTypes; ++enumIndex)
        {
            Debug.Log("Enum index " + enumIndex + " is " + (EMovementType)enumIndex);
        }

        // gets all enum values as their enum type (eg. EMovementType)
        // good for iterating over all values of an enum
        var enumValues = System.Enum.GetValues(typeof(EMovementType));
        foreach(var value in enumValues)
        {
            Debug.Log(value + " as " + value.GetType().Name);
        }

        // gets all enum names as strings
        // good for displaying to users (eg. custom inspector)
        var enumValuesAsStrings = System.Enum.GetNames(typeof(EMovementType));
        foreach(var value in enumValuesAsStrings)
        {
            // convert from enum name to enum value
            var enumValue = System.Enum.Parse(typeof(EMovementType), value);

            Debug.Log(value + " as " + value.GetType().Name + " is " + enumValue);
        }

        // log out movement
        Debug.Log("Movement Caps is " + MovementCapabilities);

        // check if can fly
        // 1111 & 0010 => 0010
        if ((MovementCapabilities & (int)EMovementCapabilities.InAir) == (int)EMovementCapabilities.InAir)
        {
            Debug.Log("Can fly!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
