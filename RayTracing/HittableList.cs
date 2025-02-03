using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class HittableList : IHittable
    {
        readonly List<IHittable> objects;

        public HittableList()
        {
            objects = new List<IHittable>();
        }
        public HittableList(IHittable obj)
        {
            objects = new List<IHittable> { obj };
        }
        public void Clear() => objects.Clear();
        public void Add(IHittable obj) => objects.Add(obj);

        public bool Hit(Ray r, double ray_tmin, double ray_tmax, HitRecord rec)
        {
            HitRecord miniHR;
            var rr = objects.AsParallel().Select(obj =>
            {
                HitRecord hr = new();
                return (obj.Hit(r, ray_tmin, ray_tmax, hr), hr);
            }).Where(t => t.Item1);
            if (rr.Any())
            {
                miniHR = rr.MinBy(t => t.Item2.T).Item2;
                rec.P = miniHR.P;
                rec.Normal = miniHR.Normal;
                rec.T = miniHR.T;
                rec.FrontFace = miniHR.FrontFace;
                return true;
            }
            return false;
        }
    }
}
