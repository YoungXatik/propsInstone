using UnityEngine;

[CreateAssetMenu(fileName = "ClickObject",menuName = "ClickObject/Create click object")]
public class ClickObjectData : ScriptableObject
{
   [SerializeField] public string objectName;
   [SerializeField] public int weight;
}
