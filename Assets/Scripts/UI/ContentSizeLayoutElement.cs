using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class ContentSizeLayoutElement : LayoutElement
{
    public override void CalculateLayoutInputHorizontal() {
        base.CalculateLayoutInputHorizontal();
        var parent = transform.parent.GetComponent<RectTransform>();
        var sz = Mathf.Min(parent.rect.width, parent.rect.height);
        var child = transform.Children()[0].GetComponent<RectTransform>();
        preferredWidth = LayoutUtility.GetPreferredWidth(child) / LayoutUtility.GetPreferredHeight(child) * parent.rect.width;
    }

    public override void CalculateLayoutInputVertical() {
        base.CalculateLayoutInputVertical();
    }
}