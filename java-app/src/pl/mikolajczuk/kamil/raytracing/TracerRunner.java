package pl.mikolajczuk.kamil.raytracing;

import pl.mikolajczuk.kamil.raytracing.lib.RayTracer;
import pl.mikolajczuk.kamil.raytracing.lib.scene.Scene;

import java.awt.image.BufferedImage;
import java.util.stream.Stream;

public class TracerRunner implements Runnable {
    private final Scene scene;
    private final int threads;

    private final BufferedImage image;
    private final RayTracer rayTracer;

    public App app;
    public long startTime;

    public int width;
    public int height;

    public TracerRunner(Scene Scene, int Threads, BufferedImage Image) {
        scene = Scene;
        threads = Threads;
        image = Image;

        rayTracer = new RayTracer(scene);
    }

    @Override
    public void run() {
        ThreadRunner[] runners = Stream.of(new Object[threads])
                .map((i, fragment) -> {
            var run = new ThreadRunner(rayTracer, fragment, threads, width, height);
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

        Task.WhenAll(
                range(threads).Select((_, fragment) ->
                        Task.Run(() ->
                        {
                            var renderedFragment = rayTracer.fragmentRender(width, height, fragment, threads);

                            Invoke(new Action(() -> {
                                showFragment(image, renderedFragment, fragment, threads);
                                renderedImage.Refresh();
                            }));
                        })
                )).Wait();

        end(startTime);
    }

    private void end(double startTime) {
        var time = System.currentTimeMillis() - startTime;

        app.timeLabel.setText(Double.toString(time / 1000.0));

        app.startButton.setEnabled(true);
    }
}
