using System;
using System.IO;
using OpenTK.Graphics.OpenGL4;
public class Shaders
{
    public static int Load(string vertexFilePath, string fragmentFilePath)
    {
        var vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
        var fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);

        var vertexShaderSource = File.ReadAllText(vertexFilePath);
        var fragmentShaderSource = File.ReadAllText(fragmentFilePath);

        CheckShader(vertexFilePath, vertexShaderId, vertexShaderSource);
        CheckShader(fragmentFilePath, fragmentShaderId, fragmentShaderSource);


        Console.WriteLine("Linking the program");
        var programId = GL.CreateProgram();
        GL.AttachShader(programId, vertexShaderId);
        GL.AttachShader(programId, fragmentShaderId);
        GL.LinkProgram(programId);

        // Check the program
        GL.GetProgram(programId, GetProgramParameterName.LinkStatus, out var result);
        GL.GetProgram(programId, GetProgramParameterName.InfoLogLength, out var infoLogLength);
        if (infoLogLength > 0)
        {
            var errorMessage = GL.GetShaderInfoLog(programId);
            LogError(errorMessage);
        }

        // clearing
        GL.DetachShader(programId, vertexShaderId);
        GL.DetachShader(programId, fragmentShaderId);
        GL.DeleteShader(vertexShaderId);
        GL.DeleteShader(fragmentShaderId);

        return programId;
    }

    static void CheckShader(string filePath, int shaderId, string shaderSource)
    {
        // Compile Vertex Shader
        Console.WriteLine($"Compiling shader : {filePath}");
        GL.ShaderSource(shaderId, shaderSource);
        GL.CompileShader(shaderId);

        GL.GetShader(shaderId, ShaderParameter.CompileStatus, out var result);
        GL.GetShader(shaderId, ShaderParameter.InfoLogLength, out var infoLogLength);

        if (infoLogLength > 0)
        {
            var errorMessage = GL.GetShaderInfoLog(shaderId);
            LogError(errorMessage);
        }
    }

    static void LogError(string errorMessage)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ForegroundColor = oldColor;
    }
}
