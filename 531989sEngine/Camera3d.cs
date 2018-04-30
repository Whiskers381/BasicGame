using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace BasicEngine
{
    #region <NotMine href="https://github.com/xamarin/monodroid-samples/blob/master/MonoGame3DCamera/CameraProject/Camera.cs">
    /// <summary>
    /// Just another 3D camera. The controls use a spaceship flying in space
    /// analogy.
    ///
    /// By Superbest, http://seabasealpha.wordpress.com/
    /// </summary>
    class Camera3d
    {
        public Vector3 Position { get; private set; }
        public Vector3 Up { get; private set; }
        public Vector3 Forward { get; private set; }

        /// <summary>
        /// Construct a view matrix corresponding to this camera.
        /// </summary>
        public Matrix ViewMatrix
        {
            get
            {
                return Matrix.CreateLookAt(Position, Forward + Position, Up);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="position">Position of the camera</param>
        /// <param name="forward">Direction which the camera looks in, equal to target - position</param>
        /// <param name="up">Up direction of the camera</param>
        public Camera3d(Vector3 position, Vector3 forward, Vector3 up)
        {
            Position = position;
            Forward = forward;
            Up = up;
        }

        /// <summary>
        /// Move forward with respect to camera
        /// </summary>
        /// <param name="amount"></param>
        public void Thrust(float amount)
        {
            Forward.Normalize();
            Position += Forward * amount;
        }

        /// <summary>
        /// Strafe left with respect to camera
        /// </summary>
        /// <param name="amount"></param>
        public void StrafeHorz(float amount)
        {
            var left = Vector3.Cross(Up, Forward);
            left.Normalize();
            Position += left * amount;
        }

        /// <summary>
        /// Strafe up with respect to camera
        /// </summary>
        /// <param name="amount"></param>
        public void StrafeVert(float amount)
        {
            Up.Normalize();
            Position += Up * amount;
        }

        /// <summary>
        /// Roll (around forward axis) clockwise with respect to camera
        /// TODO: Is it CW or CCW?
        /// </summary>
        /// <param name="amount">Angle in degrees</param>
        public void Roll(float amount)
        {
            Up.Normalize();
            var left = Vector3.Cross(Up, Forward);
            left.Normalize();

            Up = Vector3.Transform(Up, Matrix.CreateFromAxisAngle(Forward, MathHelper.ToRadians(amount)));
        }

        /// <summary>
        /// Yaw (turn/steer around up vector) to the left
        /// </summary>
        /// <param name="amount">Angle in degrees</param>
        public void Yaw(float amount)
        {
            Forward.Normalize();

            Forward = Vector3.Transform(Forward, Matrix.CreateFromAxisAngle(Up, MathHelper.ToRadians(amount)));
        }

        /// <summary>
        /// Pitch (around leftward axis) upward
        /// </summary>
        /// <param name="amount"></param>
        public void Pitch(float amount)
        {
            Forward.Normalize();
            var left = Vector3.Cross(Up, Forward);
            left.Normalize();

            Forward = Vector3.Transform(Forward, Matrix.CreateFromAxisAngle(left, MathHelper.ToRadians(amount)));
            Up = Vector3.Transform(Up, Matrix.CreateFromAxisAngle(left, MathHelper.ToRadians(amount)));
        }
    }
    #endregion
}