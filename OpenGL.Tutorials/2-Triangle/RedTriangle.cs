using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

public class RedTriangle : Window
{
    // This will identify our vertex buffer
    int vertexBuffer;
    // This will identify our program shader
    int programId;

    public override void Start()
    {
        GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);
        // An array of 3 vectors which represents 3 vertices
        var vertexBufferData = new[]
        {
          -1.0f, -1.0f, 0.0f,
           1.0f, -1.0f, 0.0f,
           0.0f,  1.0f, 0.0f,
        };

        // Generate 1 buffer, put the resulting identifier in vertexbuffer
        GL.GenBuffers(1, out vertexBuffer);
        // The following commands will talk about our 'vertexbuffer' buffer
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
        // Give our vertices to OpenGL.
        GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertexBufferData.Length, vertexBufferData, BufferUsageHint.StaticDraw);
        programId = Shaders.Load(
            "2-Triangle/SimpleVertexShader.glsl",
            "2-Triangle/SimpleFragmentShader.glsl");

    }
    public override void Draw(double deltaTime)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.UseProgram(programId);
        // 1st attribute buffer : vertices
        GL.EnableVertexAttribArray(0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
        GL.VertexAttribPointer(
           0,                              // attribute 0. No particular reason for 0, but must match the layout in the shader.
           3,                              // size
           VertexAttribPointerType.Float,  // type
           false,                          // normalized?
           0,                              // stride
           0                               // array buffer offset
        );

        // Draw the triangle !
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3); // Starting from vertex 0; 3 vertices total -> 1 triangle
        GL.DisableVertexAttribArray(0);

        SwapBuffers();
    }

    public override void Update(double deltaTime) { }
}
