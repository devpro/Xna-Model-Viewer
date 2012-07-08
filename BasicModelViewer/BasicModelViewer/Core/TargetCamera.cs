using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicModelViewer
{
  class TargetCamera : CameraBase
  {
    public Vector3 Position { get; set; }
    public Vector3 Target   { get; set; }

    public TargetCamera(GraphicsDevice graphicsDevice)
      : base(graphicsDevice)
    {
    }

    public override void Update()
    {
      this.View = Matrix.CreateLookAt(Position, Target, Vector3.Up);
    }
  }
}
