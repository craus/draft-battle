using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[ExecuteInEditMode]
public class TextBestFitSetFontSize : LayoutElement
{
    public override void CalculateLayoutInputVertical() {
        base.CalculateLayoutInputVertical();
        var text = GetComponent<Text>();
        text.fontSize = text.cachedTextGenerator.fontSizeUsedForBestFit;
    }
}