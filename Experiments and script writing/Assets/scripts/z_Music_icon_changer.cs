using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class z_Music_icon_changer : MonoBehaviour {

    RawImage ImageComponent;
    public Slider MusicSlider;
    public Texture Mute_texture;
    public Texture active_texture;

    // Use this for initialization
    void Start()
    {
        ImageComponent = GetComponent<RawImage>();
        MusicSlider.onValueChanged.AddListener(delegate { Change_icon(); });
    }
    void Change_icon()
    {
        if (MusicSlider.value == 0)
            ImageComponent.texture = Mute_texture;
        else 
            ImageComponent.texture = active_texture;
    }

}
