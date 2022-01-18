using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{

    [SerializeField] float alphaTrasparency = 0.5f;
    [SerializeField] bool transparency = true;

    private Material material;
    private Color originalColor;
    private Color currentColor;

    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    private void FixedUpdate()
    {
        if (transparency)
        {
            ActivateTransparency();
            Debug.Log("ActivateTransparency");
            Debug.Log(currentColor);
        }
        else
        {
            DeactivateTransparency();
            Debug.Log("DeactivateTransparency");
            Debug.Log(currentColor);
        }
    }

    public void ActivateTransparency()
    {
        currentColor = new Color(originalColor.r, originalColor.g, originalColor.b, alphaTrasparency);
        material.SetColor("_Color", currentColor);
    }

    public void DeactivateTransparency()
    {
        currentColor = originalColor;
        material.SetColor("_Color", currentColor);
    }

}
