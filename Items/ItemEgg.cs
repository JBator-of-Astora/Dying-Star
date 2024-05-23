using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemEgg : Interactable
{   

    // 0: Common
    // 1: Uncommon
    // 2: Rare
    // 3: Boss

    public static Action<int> itemPickedUp;
    public override bool Display() {

        turnOnInteraction?.Invoke("Press E to gain item");
        return true;
    }

    public override void Interact() {

        itemPickedUp?.Invoke(0);
        Destroy(gameObject);
    }
}
