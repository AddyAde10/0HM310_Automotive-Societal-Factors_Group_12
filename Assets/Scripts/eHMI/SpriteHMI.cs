using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simple sprite swapping implementation of HMI base class
public class SpriteHMI : HMI
{
    [SerializeField]
    SpriteRenderer _renderer;
    [SerializeField]
    Sprite stop;
	[SerializeField]
	Sprite walk;
	[SerializeField]
	Sprite disabled;
    // Added these two sprites for the merge states
    [SerializeField]
    Sprite merge_left;
    [SerializeField]
    Sprite merge_right;

	public override void Display(HMIState state)
    {
        base.Display(state);
        Sprite spr = null;
        switch (state)
        {
            case HMIState.STOP:
                spr = stop;
                break;
            case HMIState.WALK:
                spr = walk;
                break;
    // Added these two cases for the merge states
            case HMIState.MERGE_LEFT:
                spr = merge_left;
                break;
            case HMIState.MERGE_RIGHT:
                spr = merge_right;
                break;
            default:
                spr = disabled;
                break;
        }
        _renderer.sprite = spr;
    }
}

