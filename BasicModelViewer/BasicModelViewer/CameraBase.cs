using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicModelViewer
{
    public abstract class CameraBase
    {
        private Vector3 _cameraPosition;
        private Vector3 _cameraTarget;
        private Vector3 _cameraUpVector;
        private Matrix _projectionMatrix;
        
        public Vector3 CameraPosition
        {
            get { return _cameraPosition; }
            set { _cameraPosition = value; }
        }

        public Matrix ProjectionMatrix
        {
            get { return _projectionMatrix; }
        }

        public Matrix ViewMatrix
        {
            get { return Matrix.CreateLookAt(_cameraPosition, _cameraTarget, _cameraUpVector); }
        }

        public CameraBase(GraphicsDevice graphicsDevice)
        {
            _cameraPosition = Vector3.Zero;
            _cameraTarget = Vector3.Zero;
            _cameraUpVector = Vector3.Up;

            float fieldOfView = MathHelper.PiOver4;
            float aspectRatio = graphicsDevice.Viewport.AspectRatio;
            float nearPlaneDistance = 1.0f;
            float farPlaneDistance = 10000;
            _projectionMatrix = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);
        }
    }
}
