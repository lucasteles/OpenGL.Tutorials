using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class SampleWindow : GameWindow
{
    public SampleWindow(int width, int height, string title) :
        base(new() { UpdateFrequency = 60, RenderFrequency = 60 }, new() { Size = new(width, height), Title = title } ) 
    { }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        if (KeyboardState.WasKeyDown(Keys.Escape))
            this.DestroyWindow();

        GL.Clear(ClearBufferMask.ColorBufferBit);


        SwapBuffers();
        base.OnUpdateFrame(args);
    }
}
