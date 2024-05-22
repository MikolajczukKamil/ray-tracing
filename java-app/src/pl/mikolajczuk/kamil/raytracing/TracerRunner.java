package pl.mikolajczuk.kamil.raytracing;

import pl.mikolajczuk.kamil.raytracing.lib.RayTracer;
import pl.mikolajczuk.kamil.raytracing.lib.scene.Scene;

import java.awt.image.BufferedImage;
import java.util.ArrayList;
import java.util.stream.IntStream;

public class TracerRunner implements Runnable {
    private final int threads;

    private final ImageRefresh refresh;
    private final RayTracer rayTracer;

    public App app;
    public long startTime;

    public int width;
    public int height;

    public TracerRunner(Scene scene, int Threads, ImageRefresh Refresh) {
        threads = Threads;
        refresh = Refresh;

        rayTracer = new RayTracer(scene);
    }

    @Override
    public void run() {
        var runners = new ArrayList<ThreadRunner>();

        for (int fragment = 0; fragment < threads; fragment++) {
            var run = new ThreadRunner(rayTracer, fragment, threads, width, height, refresh);
            run.thread.start();
            runners.add(run);
        }

        for (ThreadRunner run : runners) {
            try {
                run.thread.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        var time = System.currentTimeMillis() - startTime;

        app.timeLabel.setText(Double.toString(time / 1000.0));
        app.startButton.setEnabled(true);
    }
}
