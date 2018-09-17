using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realEngineStarter
{
    static class surroundAudio
    {
        public static float CalculateStereo(Entity ent)
        {
            Vector3 lDir = Quaternion.Euler(GameplayCamera.Rotation) * Vector3.RelativeRight;
            Vector3 rDir = -lDir;
            Vector3 relativeDir = ent.Position - GameplayCamera.Position;
            relativeDir.Normalize();

            float lf = Vector3.Angle(lDir, relativeDir);
            float volumeL = lf / 180f;
            float rf = Vector3.Angle(rDir, relativeDir);
            float volumeR = rf / 180f;

            return volumeR - volumeL;
        }
    }
}
