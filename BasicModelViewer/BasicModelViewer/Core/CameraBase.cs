using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicModelViewer
{
  public abstract class CameraBase
  {
    private Matrix view;
    private Matrix projection;

    public Matrix Projection
    {
      get { return projection; }
      protected set
      {
        projection = value;
        generateFrustum();
      }
    }

    public Matrix View
    {
      get { return view; }
      protected set
      {
        view = value;
        generateFrustum();
      }
    }

    public BoundingFrustum Frustum { get; private set; }

    protected GraphicsDevice GraphicsDevice { get; set; }

    public CameraBase(GraphicsDevice graphicsDevice)
    {
      this.GraphicsDevice = graphicsDevice;

      generatePerspectiveProjectionMatrix(MathHelper.PiOver4);
    }

    private void generatePerspectiveProjectionMatrix(float FieldOfView)
    {
      PresentationParameters pp = GraphicsDevice.PresentationParameters;

      float aspectRatio = (float)pp.BackBufferWidth /
          (float)pp.BackBufferHeight;

      this.Projection = Matrix.CreatePerspectiveFieldOfView(
          MathHelper.ToRadians(45), aspectRatio, 0.1f, 1000000.0f);
    }

    public virtual void Update()
    {
    }

    private void generateFrustum()
    {
      var viewProjection = View * Projection;
      Frustum = new BoundingFrustum(viewProjection);
    }

    public bool BoundingVolumeIsInView(BoundingSphere sphere)
    {
      return (Frustum.Contains(sphere) != ContainmentType.Disjoint);
    }

    public bool BoundingVolumeIsInView(BoundingBox box)
    {
      return (Frustum.Contains(box) != ContainmentType.Disjoint);
    }
  }
}
