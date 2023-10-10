using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ray_tracer;
using ray_tracer.common;
using ray_tracer.scene;
using ray_tracer.elements.things;
using ray_tracer.elements.surfaces;

namespace ray_tracing_cs
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            var rayTracer = new RayTracer(getScene(), 256, 256);

            rayTracer.render();
        }

        static Scene getScene()
        {
            Thing[] things = {
                new Plane(new Vector(0.0, 1.0, 0.0), 0.0, new Checkerboard()),
                new Sphere(new Vector(0.0, 1.0, -0.25), 1.0, new Shiny()),
                new Sphere(new Vector(-1.0, 0.5, 1.5), 0.5, new Shiny())
            };

            Color red = new Color(0.49, 0.07, 0.07);
            Color green = new Color(0.7, 0.49, 0.07);
            Color blue = new Color(0.7, 0.07, 0.49);

            Light[] lights =
            {
                new Light(new Vector(-2.0, 2.5, 0.0), red),
                new Light(new Vector(1.5, 2.5, 1.5), blue),
                new Light(new Vector(1.5, 2.5, -1.5), green),
                new Light(new Vector(0.0, 3.5, 0.0), new Color(0.21, 0.21, 0.35))
            };

            var camera = new Camera(new Vector(3.0, 2.0, 4.0), new Vector(-1.0, 0.5, 0.0));

            return new Scene(things, lights, camera);
        }
    }
}
