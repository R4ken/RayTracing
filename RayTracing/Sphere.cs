using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point3 = RayTracing.Vec3;

namespace RayTracing
{
    internal class Sphere(Point3 center, double radius) : IHittable
    {
        Point3 Center = new Point3(center);
        double Radius = Math.Max(0, radius);

        public bool Hit(Ray ray, double ray_tmin, double ray_tmax, HitRecord rec)
        {
            Vec3 oc = center - ray.Origin;
            double a = Vec3.Dot(ray.Direction, ray.Direction);
            double h = Vec3.Dot(oc, ray.Direction);
            double c = Vec3.Dot(oc, oc) - radius * radius;
            double discriminant = h * h - a * c;
            if (discriminant < 0)
                return false;
            double sqrtd = Math.Sqrt(discriminant);
            double root = (h - sqrtd) / a;
            if(root <= ray_tmin || root >= ray_tmax)
            {
                root = (h + sqrtd) / a;
                if (root <= ray_tmin || root >= ray_tmax)
                    return false;
            }
            rec.T = root;
            rec.P = ray.at(root);
            Vec3 outwardNormal = (rec.P - Center) / Radius;
            rec.SetFaceNormal(ray, outwardNormal);
            return true;
        }
    }
}
