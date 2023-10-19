using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using ray_tracer;
using ray_tracer.common;
using ray_tracer.scene;
using ray_tracer.elements.things;
using ray_tracer.elements.surfaces;

namespace ray_tracing_cs
{
    public partial class Form1 : Form
    {
        private bool started = false;

        public Form1()
        {
            InitializeComponent();
            start(null, null);
        }

        private void start(object sender, EventArgs e)
        {
            if (started) return;
            started = true;

            renderedImage.Image = new Bitmap(renderedImage.Width, renderedImage.Height);

            var rayTracer = new RayTracer(getScene(), renderedImage.Width, renderedImage.Height, 1.5);

            renderedImage.Image = rayTracer.render();

            started = false;
        }

        Scene getScene()
        {
            Thing[] things = {
                new Plane (new Vector( 0.0, 1.0,  0.00), 0.0, new Checkerboard()),
                new Sphere(new Vector( 0.0, 1.0, -0.25), 1.0, new Shiny()),
                new Sphere(new Vector(-1.0, 0.5,  1.50), 0.5, new Matt())
            };

            var red   = RColor.from(125,  18,  18);
            var green = RColor.from( 18, 125,  18);
            var blue  = RColor.from( 18,  18, 125);
            var blue2 = RColor.from( 54,  54,  89);
          
            Light[] lights =
            {
                new Light(new Vector(-2.0, 2.5,  0.0), red),
                new Light(new Vector( 1.5, 2.5,  1.5), blue),
                new Light(new Vector( 1.5, 2.5, -1.5), green),
                new Light(new Vector( 0.0, 3.5,  0.0), blue2)
            };

            var camera = new Camera(new Vector(3.0, 2.0, 5.0), new Vector(-1.0, 0.5, 0.0));

            return new Scene(things, lights, camera);
        }
    }
}
