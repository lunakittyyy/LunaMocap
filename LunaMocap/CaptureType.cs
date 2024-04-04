using System;
using System.Collections.Generic;
using System.Text;

namespace LunaMocap
{
    public class Capture
    {
        public int Frame { get; set; }


        public float LHandPosX { get; set; }
        public float LHandPosY { get; set; }
        public float LHandPosZ { get; set; }

        public float LHandRotX { get; set; }
        public float LHandRotY { get; set; }
        public float LHandRotZ { get; set; }
        public float LHandRotW { get; set; }


        public float RHandPosX { get; set; }
        public float RHandPosY { get; set; }
        public float RHandPosZ { get; set; }

        public float RHandRotX { get; set; }
        public float RHandRotY { get; set; }
        public float RHandRotZ { get; set; }
        public float RHandRotW { get; set; }


        public float HeadPosX { get; set; }
        public float HeadPosY { get; set; }
        public float HeadPosZ { get; set; }

        public float HeadRotX { get; set; }
        public float HeadRotY { get; set; }
        public float HeadRotZ { get; set; }
        public float HeadRotW { get; set; }
    }
}
