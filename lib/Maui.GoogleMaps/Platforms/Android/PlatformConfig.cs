﻿using Maui.GoogleMaps.Android.Factories;

namespace Maui.GoogleMaps.Android;

public sealed class PlatformConfig
{
    public IBitmapDescriptorFactory BitmapDescriptorFactory { get; set; }

    public IBitmapDescriptorFactory GetBitmapdescriptionFactory()
    {
        return BitmapDescriptorFactory ?? DefaultBitmapDescriptorFactory.Instance;
    }
}