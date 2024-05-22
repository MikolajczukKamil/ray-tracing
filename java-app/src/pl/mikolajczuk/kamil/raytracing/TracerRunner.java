package pl.mikolajczuk.kamil.raytracing;

import pl.mikolajczuk.kamil.raytracing.lib.RayTracer;
import pl.mikolajczuk.kamil.raytracing.lib.scene.Scene;

import java.awt.image.BufferedImage;
import java.util.stream.IntStream;

public class TracerRunner implements Runnable {
    private final int threads;

    private final BufferedImage image;
    private final RayTracer rayTracer;

    public App app;
    public long startTime;

    public int width;
    public int height;

    public TracerRunner(Scene scene, int Threads, BufferedImage Image) {
        threads = Threads;
        image = Image;

        rayTracer = new RayTracer(scene);
    }

    @Override
    public void run() {
        ThreadRunner[] runners = IntStream.range(0, threads)
                .mapToObj((fragment) -> {
                    var run = new ThreadRunner(rayTracer, fragment, threads, width, height, image);
                    run.thread.start();

                    return run;
                }).toArray(ThreadRunner[]::new);

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
