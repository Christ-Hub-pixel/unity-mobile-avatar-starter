using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Header("UI References")]
    public RectTransform background; // set to the background image RectTransform
    public RectTransform handle; // set to the joystick handle RectTransform
    public float handleRange = 100f; // max distance in pixels the handle can move

    private Vector2 input = Vector2.zero;
    public bool IsTouched { get; private set; }
    public float Horizontal => input.x;
    public float Vertical => input.y;

    public void OnPointerDown(PointerEventData eventData)
    {
        IsTouched = true;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out pos);
        Vector2 clamped = Vector2.ClampMagnitude(pos, handleRange);
        handle.anchoredPosition = clamped;
        input = clamped / handleRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsTouched = false;
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
