using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootHandler : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{

    private ShootingSystem shootingSystem;

    public bool isPressed;

    private void Start()
    {
        shootingSystem = FindObjectOfType<ShootingSystem>();
    }

    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            shootingSystem.ShootRaycast();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
