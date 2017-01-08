using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class PreferredAspectRatio : MonoBehaviour
{
    public float preferredAspectRatio;
    public float preferredWidth;
    public float preferredHeight;

    public void Update() {
        var rect = GetComponent<RectTransform>();
        preferredWidth = LayoutUtility.GetPreferredWidth(rect);
        preferredHeight = LayoutUtility.GetPreferredHeight(rect);
        preferredAspectRatio = preferredWidth / preferredHeight;
    }
}