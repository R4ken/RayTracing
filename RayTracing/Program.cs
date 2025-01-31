using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Color = RayTracing.Vec3;
using Point3 = RayTracing.Vec3;

namespace RayTracing
{
    public class Program
    {
        public static void Main()
        {
            // Image
            double aspectRatio = 16.0d / 9.0d;
            int imageWidth = 800;
            int imageHeight = (int) (imageWidth / aspectRatio);
            imageWidth = imageWidth < 1 ? 1 : imageWidth;
            // Camera
            double focalLength = 1.0d;
            double viewportHeight = 2.0d;
            double viewportWidth = viewportHeight * ((double)imageWidth / imageHeight);
            Point3 cameraCenter = new Point3(0,0,0);

            Vec3 viewportU = new Vec3(viewportWidth, 0, 0);
            Vec3 viewportV = new Vec3(0, -viewportHeight, 0);

            Vec3 pixelDeltaU = viewportU / imageWidth;
            Vec3 pixelDeltaV = viewportV / imageHeight;
            Point3 viewportUpperLeft = cameraCenter - new Vec3(0, 0, focalLength) - 0.5d * viewportU - 0.5 * viewportV;
            Point3 pixel00Loc = viewportUpperLeft + 0.5 * pixelDeltaU + 0.5 * pixelDeltaV;
            int maxColor = 255;
            using FileStream file = File.Open("normal-colored-sphere.ppm", FileMode.Create, FileAccess.Write);
            using StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("P3");
            sw.WriteLine($"{imageWidth} {imageHeight}");
            sw.WriteLine($"{maxColor}");
            for (int i = 0; i < imageHeight; i++)
            {
                Console.Error.WriteLine("Scanlines remaining {0}", imageHeight - i);
                for (int j = 0; j < imageWidth; j++)
                {
                    Point3 pixelCenter = pixel00Loc + i * pixelDeltaV + j * pixelDeltaU;
                    Vec3 rayDirection = pixelCenter - cameraCenter;
                    Ray ray = new Ray(cameraCenter, rayDirection);
                    Color pixelColor = ColorUtilities.RayColor(ray);
                    sw.WriteLine(ColorUtilities.ColorString(pixelColor));
                }
            }
        }
    }
}
