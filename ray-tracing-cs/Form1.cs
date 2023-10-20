using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using ray_tracer;
using ray_tracer.common;
using ray_tracer.scene;
using ray_tracer.elements.things;
using ray_tracer.elements.surfaces;

namespace ray_tracing_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start(object sender, EventArgs e)
        {
            if (!startButton.Enabled) return;
            startButton.Enabled = false;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            timeLabel.Text = "...";

            Task.Run(() =>
            {
                var scene = getScene();
                var rayTracer = new RayTracer(scene);
                var width = renderedImage.Width;
                var height = renderedImage.Height;
                var image = new Bitmap(width, height);

                renderedImage.Image = image;

                var threads = getThreads();

                var random = new Random();

                Task.WhenAll(
                    range(threads).Select((_, fragmentIndex) =>
                    Task.Run(() =>
                    {
                        var fragment = rayTracer.fragmentRender(width, height, fragmentIndex, threads);

                        Invoke(new Action(delegate ()
                        {
                            showFragment(image, fragment, fragmentIndex, threads);
                            renderedImage.Refresh();
                        }));
                    })
                )).Wait();

                stopwatch.Stop();

                Invoke(new Action(delegate ()
                {
                    timeLabel.Text = (stopwatch.ElapsedMilliseconds / 1000.0).ToString();
                    startButton.Enabled = true;
                }));
            });
        }

        private int getThreads()
        {
            string threamsValue = null;

            Invoke(new Action(delegate ()
            {
                threamsValue = (string)thredsControl.SelectedItem;
            }));

            return threamsValue != null && threamsValue.Length > 0 ? Int32.Parse(threamsValue) : 8;
        }

        Scene getScene()
        {
            Thing[] things = new List<Thing> {
                groundControl.Checked    ? new Plane (new Vector( 0.0, 1.0,  0.00), 0.0, new Checkerboard()) : null,
                bigBallControl.Checked   ? new Sphere(new Vector( 0.0, 1.0, -0.25), 1.0, new Shiny())        : null,
                smallBallControl.Checked ? new Sphere(new Vector(-1.0, 0.5,  1.50), 0.5, new Matt())         : null
            }.Where(x => x != null).ToArray();

            var red = RColor.from(125, 18, 18);
            var green = RColor.from(18, 125, 18);
            var blue = RColor.from(18, 18, 125);
            var gray = RColor.from(54, 54, 89);

            Light[] lights = new List<Light> {
                redLightControl.Checked   ? new Light(new Vector(-2.0, 2.5,  0.0), red)   : null,
                blueLightControl.Checked  ? new Light(new Vector( 1.5, 2.5,  1.5), blue)  : null,
                greenLightControl.Checked ? new Light(new Vector( 1.5, 2.5, -1.5), green) : null,
                grayLightControl.Checked  ? new Light(new Vector( 0.0, 3.5,  0.0), gray)  : null
            }.Where(x => x != null).ToArray();

            string zoomSelected = null;

            Invoke(new Action(delegate ()
            {
                zoomSelected = (string)zoomControll.SelectedItem;
            }));

            double zoom = zoomSelected != null && zoomSelected.Length > 0 ? Double.Parse(zoomSelected) : 1.0;

            var camera = new Camera(new Vector(3.0, 2.0, 5.0), new Vector(-1.0, 0.5, 0.0), zoom);

            return new Scene(things, lights, camera);
        }

        private void showFragment(Bitmap image, Bitmap fragment, int fragmentIndex, int threads)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawImage(fragment, 0, fragmentIndex * (image.Height / threads));
            }
        }

        private object[] range(int max)
        {
            return new object[max];
        }
    }
}
