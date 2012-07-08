using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicModelViewer
{
  public class SimpleCamera
  {
    public Vector3 CameraTarget     { get; private set; }
    public Vector3 CameraUpVector   { get; private set; }
    public Vector3 CameraPosition   { get; set; }
    public Matrix  ProjectionMatrix { get; private set; }

    public Matrix  ViewMatrix
    {
      get { return Matrix.CreateLookAt(CameraPosition, CameraTarget, CameraUpVector); }
    }

    public SimpleCamera(GraphicsDevice graphicsDevice)
    {
      CameraPosition = Vector3.Zero;
      CameraTarget   = Vector3.Zero;
      CameraUpVector = Vector3.Up;

      float fieldOfView       = MathHelper.PiOver4;
      float aspectRatio       = graphicsDevice.Viewport.AspectRatio;
      float nearPlaneDistance = 1.0f;
      float farPlaneDistance  = 10000;
      ProjectionMatrix        = Matrix.CreatePerspectiveFieldOfView(
        fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance
      );
    }
  }
}
