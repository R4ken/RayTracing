using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point3 = RayTracing.Vec3;

namespace RayTracing
{
    public class HitRecord
    {
        public Point3 P { get; set; }
        public Vec3 Normal { get; set; }
        public double T { get; set; }
        public bool FrontFace { get; set; }


        public void SetFaceNormal(Ray ray, Vec3 outwardNormal)
        {
            FrontFace = Vec3.Dot(ray.Direction, outwardNormal) < 0;
            Normal = FrontFace ? outwardNormal : -outwardNormal;
        }
    }
}
