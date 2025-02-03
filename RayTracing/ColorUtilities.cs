using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    using Color = Vec3;
    using Point3 = Vec3;
    public static class ColorUtilities
    {
        public static string ColorString(Color pixelColor)
        {
            var r = pixelColor.x;
            var g = pixelColor.y;
            var b = pixelColor.z;
            byte rbyte = (byte)(255.999 * r);
            byte gbyte = (byte)(255.999 * g);
            byte bbyte = (byte)(255.999 * b);
            return $"{rbyte} {gbyte} {bbyte}";
        }

        public static double HitSphere(Point3 center, double radius, Ray r)
        {
            Vec3 oc = center - r.Origin;
            double a = Vec3.Dot(r.Direction, r.Direction);
            double h = Vec3.Dot(oc, r.Direction);
            double c = Vec3.Dot(oc, oc) - radius * radius;
            double discriminant = h * h - a * c;
            return discriminant < 0.0d ? -1.0d : ((h - Math.Sqrt(discriminant)) / a);
        }
        public static Color RayColor(Ray ray, IHittable hittable)
        {
            HitRecord hit = new();
            if (hittable.Hit(ray, 0, double.PositiveInfinity, hit))
            {
                return 0.5d * (hit.Normal + new Color(1, 1, 1));
            }
            Vec3 unitDirection = Vec3.UnitVector(ray.Direction);
            double a = 0.5d * unitDirection.y + 0.5d;
            return (1 - a) * new Color(1.0d, 1.0d, 1.0d) + a * new Color(0.5, 0.7, 1);
        }
    }
}
