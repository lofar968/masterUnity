using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class z_Volume_icon_changer : MonoBehaviour {

    RawImage ImageComponent;
    public Slider VolumeSlider;
    public Texture Mute_texture;
    public Texture one_arc_texture;
    public Texture two_arc_texture;
    public Texture three_arc_texture;

    // Use this for initialization
    void Start () {
        ImageComponent = GetComponent<RawImage>();
        VolumeSlider.onValueChanged.AddListener(delegate { Change_icon(); });
    }
    void Change_icon()
    {
        if (VolumeSlider.value == 0)
            ImageComponent.texture = Mute_texture;
        else if (VolumeSlider.value < 0.5)
            ImageComponent.texture = one_arc_texture;
        else if (VolumeSlider.value == 1)
            ImageComponent.texture = three_arc_texture;
        else
            ImageComponent.texture = two_arc_texture;
    }
}
