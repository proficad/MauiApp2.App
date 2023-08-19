using Microsoft.Maui.Controls.Shapes;
using SkiaSharp;

namespace MauiApp2;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
	}



    private void skiaView_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
    {
        SKSurface surface = e.Surface;
        // then we get the canvas that we can draw on
        SKCanvas canvas = surface.Canvas;
        // clear the canvas / view
        canvas.Clear(SKColors.White);


        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SkiaSharp.SKColors.Chocolate,
            StrokeWidth = 5
        };



        canvas.DrawCircle(100, 100, 20, paint);

        paint.Color = SkiaSharp.SKColors.Crimson;
        canvas.DrawCircle(200, 300, 30, paint);

        string ls_has_stream = (MyContext.m_stream != null) ? "yes" : "no";

        SKPaint l_paint_text = paint.Clone();
        l_paint_text.StrokeWidth = 1;
        l_paint_text.Color = SkiaSharp.SKColors.Blue;
        canvas.DrawText(ls_has_stream, 100, 200, l_paint_text);

    }


    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        double x = 0, y = 0;
        switch (e.StatusType)
        {
            case GestureStatus.Running:
                // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                Content.TranslationX = Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - DeviceDisplay.MainDisplayInfo.Width));
                Content.TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - DeviceDisplay.MainDisplayInfo.Height));
                break;

            case GestureStatus.Completed:
                // Store the translation applied during the pan
                x = Content.TranslationX;
                y = Content.TranslationY;
                break;
        }

        System.Diagnostics.Debug.WriteLine("x=" + x);
        System.Diagnostics.Debug.WriteLine("y=" + y);
    }





}

