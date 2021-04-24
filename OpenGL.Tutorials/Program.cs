using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;

var samples = new Dictionary<int, Func<GameWindow>> { 
    [0] = () => new SampleWindow(1024, 768, "OpenGL Tutorial : Open Window"),
    [1] = () => new RedTriangle(),
};

using var game = samples[1]();
game.Run();
