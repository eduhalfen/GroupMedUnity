using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AspectRatioFitterHacked : AspectRatioFitter
{
    protected override void Start()
    {
        base.Start();
        SetDirty();
    }
}