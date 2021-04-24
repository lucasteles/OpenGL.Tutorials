using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

public abstract class Window : GameWindow
{
    public Window(int width, int height, string title) :
        base(new() { UpdateFrequency = 60, RenderFrequency = 60 }, new() { Size = new(width, height), Title = title }) { }
    public Window(string title) : this(1024,768, title) { }
    public Window() : this("Open GL Tutorial") { }

    protected override void OnLoad()
    {

        // Need to create a Vertex Array Object and set it as the current one
        //Do this once your window is created (= after the OpenGL Context creation) and before any other OpenGL call.
        //If you really want to know more about VAOs, there are a few other tutorials out there, but this is not very important.
        GL.GenVertexArrays(1, out int vertexArrayID);
        GL.BindVertexArray(vertexArrayID);

        Start();
        base.OnLoad();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        if (KeyboardState.WasKeyDown(Keys.Escape))
            this.DestroyWindow();

        Update(args.Time);
        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        //GL.Viewport(0, 0, Size.X, Size.Y);
        Draw(args.Time);
        base.OnRenderFrame(args);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);
        base.OnResize(e);
    }

    public abstract void Start();
    public abstract void Update(double deltaTime);
    public abstract void Draw(double deltaTime);

}
