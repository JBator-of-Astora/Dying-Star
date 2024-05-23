using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pool", menuName = "Item Pool")]
public class ItemPool : ScriptableObject
{
    public List<string> commonItems;
    public List<string> uncommonItems;
    public List<string> rareItems;
    public List<string> bossItems;
}
