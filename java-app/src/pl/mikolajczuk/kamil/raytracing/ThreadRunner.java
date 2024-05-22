package pl.mikolajczuk.kamil.raytracing;

import pl.mikolajczuk.kamil.raytracing.lib.RayTracer;

import java.awt.image.BufferedImage;

public class ThreadRunner implements Runnable {
    public ImageRefresh refresh;
    public final RayTracer rayTracer;

    public int fragment;
    public int threads;

    public int width;
    public int height;

    public Thread thread = new Thread(this);

    private static final Object joinImageLock = new Object();

    public ThreadRunner(RayTracer RayTracer, int Fragment, int Threads, int Width, int Height, ImageRefresh Refresh) {
        rayTracer = RayTracer;
        fragment = Fragment;
        threads = Threads;
        width = Width;
        height = Height;
        refresh = Refresh;
    }

    @Override
    public void run() {
        var renderedFragment = rayTracer.fragmentRender(width, height, fragment, threads);

        synchronized (joinImageLock) {
            var g = refresh.image.getGraphics();
            g.drawImage(renderedFragment,  0, fragment * (refresh.image.getHeight() / threads), null);
            g.dispose();

            refresh.refresh();
        }
    }
}
