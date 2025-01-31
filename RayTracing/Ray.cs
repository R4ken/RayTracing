using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = RayTracing.Vec3;
using Point3 = RayTracing.Vec3;

namespace RayTracing
{
    public class Ray
    {
        public Point3 Origin { get; }
        public Vec3 Direction { get; }
        public Ray(Vec3 origin, Vec3 direction)
        {
            Origin = origin;
            Direction = direction;
        }
        public Point3 at(double t) => Origin + t * Direction;
    }
}
