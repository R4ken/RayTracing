using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public interface IHittable
    {
        public bool Hit(Ray r, double ray_tmin, double ray_tmax, HitRecord rec);
    }
}
