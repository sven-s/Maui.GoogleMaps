﻿
namespace MauiGoogleMapSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            buttonBasicMap.Clicked += (_, e) => Navigation.PushAsync(new BasicMapPage());
            buttonCamera.Clicked += (_, e) => Navigation.PushAsync(new CameraPage());
            buttonPins.Clicked += (_, e) => Navigation.PushAsync(new PinsPage());
            buttonShapes.Clicked += (_, e) => Navigation.PushAsync(new ShapesPage());
            buttonClustering.Clicked += (_, e) => Navigation.PushAsync(new ClusteringPage());
            buttonShapes2.Clicked += (_, e) => Navigation.PushAsync(new Shapes2Page());
            buttonTiles.Clicked += (_, e) => Navigation.PushAsync(new TilesPage());
            buttonCustomPins.Clicked += (_, e) => Navigation.PushAsync(new CustomPinsPage());
            buttonPinItemsSource.Clicked += (_, e) => Navigation.PushAsync(new PinItemsSourcePage());
            buttonShapesWithInitialize.Clicked += (_, e) => Navigation.PushAsync(new ShapesWithInitializePage());
            buttonBindingPin.Clicked += (_, e) => Navigation.PushAsync(new BindingPinViewPage());
            buttonGroundOverlays.Clicked += (_, e) => Navigation.PushAsync(new GroundOverlaysPage());
            buttonMapStyles.Clicked += (_, e) => Navigation.PushAsync(new MapStylePage());
            buttonMapId.Clicked+= (_, e) => Navigation.PushAsync(new MapIdPage());
            buttonPinIconsCaching.Clicked += (_, e) => Navigation.PushAsync(new MultiplePinsIconsCaching());

        }
    }
}
