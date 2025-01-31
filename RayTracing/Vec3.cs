using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Vec3
    {
        double[] e;
        public Vec3(double e0 = 0, double e1 = 0, double e2 = 0) => e = [e0, e1, e2];
        public Vec3(Vec3 v) => e = (double[])v.e.Clone();
        public double x { get { return e[0]; } }
        public double y { get { return e[1]; } }
        public double z { get { return e[2]; } }
        public double this[int i] { get => e[i]; set => e[i] = value; }
        public static Vec3 operator -(Vec3 v) => new Vec3(-v.x, -v.y, -v.z);
        public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vec3 operator -(Vec3 a, Vec3 b) => a + (-b);
        public static Vec3 operator *(Vec3 a, double d) => new Vec3(a.x * d, a.y * d, a.z * d);
        public static Vec3 operator *(double d, Vec3 a) => a * d;
        public static Vec3 operator /(Vec3 a, double d) => (1 / d) * a;
        public double LengthSquared() => e.Select(e => e * e).Sum();
        public double Length() => Math.Sqrt(LengthSquared());
        public static double Dot(Vec3 a, Vec3 b) => a.e.Zip(b.e, (x, y) => x * y).Sum();
        public static Vec3 Cross(Vec3 a, Vec3 b) => new Vec3(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x);
        public static Vec3 UnitVector(Vec3 a) => a / a.Length();
        public override string? ToString() => $"{x} {y} {z}";
    }
}
