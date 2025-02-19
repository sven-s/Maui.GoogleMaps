﻿using System.ComponentModel;
using Foundation;
using Google.Maps;
using Maui.GoogleMaps.iOS;
using NativeTileLayer = Google.Maps.TileLayer;
using NativeUrlTileLayer = Google.Maps.UrlTileLayer;

namespace Maui.GoogleMaps.Logics.iOS;

public class TileLayerLogic : DefaultLogic<TileLayer, NativeTileLayer, MapView>
{
    protected override IList<TileLayer> GetItems(Map map) => map.TileLayers;

    protected override NativeTileLayer CreateNativeItem(TileLayer outerItem)
    {
        NativeTileLayer nativeTileLayer;

        if (outerItem.MakeTileUri != null)
        {
            nativeTileLayer = NativeUrlTileLayer.FromUrlConstructor((nuint x, nuint y, nuint zoom) =>
            {
                var uri = outerItem.MakeTileUri((int)x, (int)y, (int)zoom);
                return new NSUrl(uri.AbsoluteUri);
            });
            nativeTileLayer.TileSize = (nint)outerItem.TileSize;
        }
        else if (outerItem.TileImageSync != null)
        {
            nativeTileLayer = new TouchSyncTileLayer(outerItem.TileImageSync);
            nativeTileLayer.TileSize = (nint)outerItem.TileSize;
        }
        else
        {
            nativeTileLayer = new TouchAsyncTileLayer(outerItem.TileImageAsync);
            nativeTileLayer.TileSize = (nint)outerItem.TileSize;
        }

        nativeTileLayer.ZIndex = outerItem.ZIndex;

        outerItem.NativeObject = nativeTileLayer;
        nativeTileLayer.Map = NativeMap;

        return nativeTileLayer;
    }

    protected override NativeTileLayer DeleteNativeItem(TileLayer outerItem)
    {
        var nativeTileLayer = outerItem.NativeObject as NativeTileLayer;
        nativeTileLayer.Map = null;
        return nativeTileLayer;
    }

    protected override void CheckCanCreateNativeItem(TileLayer outerItem)
    {
    }

    protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnItemPropertyChanged(sender, e);
        
        if (sender is not TileLayer { NativeObject: NativeTileLayer nativeItem } outerItem)
        {
            return;
        }

        if (e.PropertyName == TileLayer.ZIndexProperty.PropertyName)
        {
            OnUpdateZIndex(outerItem, nativeItem);
        }
    }

    private void OnUpdateZIndex(TileLayer outerItem, NativeTileLayer nativeItem)
    {
        nativeItem.ZIndex = outerItem.ZIndex;
    }
}