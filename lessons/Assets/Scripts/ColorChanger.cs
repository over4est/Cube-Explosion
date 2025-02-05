using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Awake()
    {
        Material material = GetComponent<MeshRenderer>().material;
        material.color = Random.ColorHSV();
    }
}
