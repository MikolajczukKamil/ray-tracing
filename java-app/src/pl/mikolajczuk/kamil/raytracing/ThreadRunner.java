package pl.mikolajczuk.kamil.raytracing;

import pl.mikolajczuk.kamil.raytracing.lib.RayTracer;

import java.awt.image.BufferedImage;

public class ThreadRunner implements Runnable {
    public BufferedImage renderedFragment;
    public final RayTracer rayTracer;

    public int fragment;
    public int threads;

    public int width;
    public int height;

    public Thread thread = new Thread(this);

    public ThreadRunner(RayTracer RayTracer, int Fragment, int Threads, int Width, int Height) {
        rayTracer = RayTracer;
        fragment = Fragment;
        threads = Threads;
        width = Width;
        height = Height;
    }

    @Override
    public void run() {
        renderedFragment = rayTracer.fragmentRender(width, height, fragment, threads);
    }
}
