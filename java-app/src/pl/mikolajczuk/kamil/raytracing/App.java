package pl.mikolajczuk.kamil.raytracing;

import pl.mikolajczuk.kamil.raytracing.lib.RayTracer;
import pl.mikolajczuk.kamil.raytracing.lib.elements.surfaces.*;
import pl.mikolajczuk.kamil.raytracing.lib.elements.things.*;
import pl.mikolajczuk.kamil.raytracing.lib.scene.*;
import pl.mikolajczuk.kamil.raytracing.lib.common.*;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.util.Arrays;
import java.util.Objects;

public class App extends JFrame {
    private JComboBox thredsControl;
    private JComboBox zoomControll;
    private JCheckBox hugeBallControl;
    private JCheckBox smallBallControl;
    private JCheckBox bigBallControl;
    private JCheckBox groundControl;
    private JCheckBox redLightControl;
    private JCheckBox blueLightControl;
    private JCheckBox grayLightControl;
    private JCheckBox greenLightControl;
    private JLabel timeLabel;
    private JButton startButton;
    private JPanel renderedImage;
    private JPanel allContainer;

    public App() {
        super();

        setTitle("Ray tracer - Kamil Mikołajczuk, Karol Kowalski");
        setSize(1784, 961);
        setContentPane(allContainer);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        App app = this;
        startButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                app.start();
            }
        });

        setVisible(true);
    }

    private void start() {
        if (!startButton.isEnabled()) return;
        startButton.setEnabled(false);

        BufferedImage image = new BufferedImage(renderedImage.getWidth(), renderedImage.getHeight(), BufferedImage.TYPE_INT_ARGB);
        Graphics g = image.getGraphics();

//        g.setPaintMode();
        g.setColor(Color.blue);
        g.fillRect(50, 50, 150, 500);
        g.dispose();

        JLabel picLabel = new JLabel(new ImageIcon(image));
        picLabel.setSize(renderedImage.getSize());

        renderedImage.removeAll();
        renderedImage.add(picLabel);
        renderedImage.repaint();

        //

        var startTime = System.currentTimeMillis();

        timeLabel.setText("...");

        var scene = getScene();
        var threads = getThreads();
        var width = renderedImage.getWidth();
        var height = renderedImage.getHeight();

        Task.Run(() -> {
            var rayTracer = new RayTracer(scene);
            var image = new Bitmap(width, height);

            renderedImage.Image = image;

            Task.WhenAll(
                    range(threads).Select((_, fragment) = >
                    Task.Run(() = >
                    {
                            var renderedFragment = rayTracer.fragmentRender(width, height, fragment, threads);

            Invoke(new Action(() -> {
                showFragment(image, renderedFragment, fragment, threads);
                renderedImage.Refresh();
            }));
                    })
                )).Wait();

            end(startTime);
        });
    }

    private void end(double startTime) {
        var time = System.currentTimeMillis() - startTime;

        timeLabel.setText(Double.toString(time / 1000.0));

        startButton.setEnabled(true);
    }

    private int getThreads() {
        var threadsValue = (String) thredsControl.getSelectedItem();

        return threadsValue != null && threadsValue.length() > 0 ? Integer.parseInt(threadsValue) : 8;
    }

    private Scene getScene() {
        var things = Arrays.stream(new Thing[]{
                groundControl.isSelected() ? new Plane(new Vector(0.0, 1.0, 0.00), 0.0, new Checkerboard()) : null,
                bigBallControl.isSelected() ? new Sphere(new Vector(0.0, 1.0, -0.25), 1.0, new Shiny()) : null,
                smallBallControl.isSelected() ? new Sphere(new Vector(-1.0, 0.5, 1.50), 0.5, new Matt()) : null,
                hugeBallControl.isSelected() ? new Sphere(new Vector(-9.0, 3.0, -4.5), 3.0, new Shiny()) : null,
        }).filter(Objects::nonNull).toArray(Thing[]::new);

        var red = RColor.from(125, 18, 18);
        var green = RColor.from(18, 125, 18);
        var blue = RColor.from(18, 18, 125);
        var gray = RColor.from(54, 54, 89);

        var lights = Arrays.stream(new Light[]{
                redLightControl.isSelected() ? new Light(new Vector(-2.0, 2.5, 0.0), red) : null,
                blueLightControl.isSelected() ? new Light(new Vector(1.5, 2.5, 1.5), blue) : null,
                greenLightControl.isSelected() ? new Light(new Vector(1.5, 2.5, -1.5), green) : null,
                grayLightControl.isSelected() ? new Light(new Vector(0.0, 3.5, 0.0), gray) : null
        }).filter(Objects::nonNull).toArray(Light[]::new);

        var zoomSelected = (String) zoomControll.getSelectedItem();
        var zoom = zoomSelected != null && zoomSelected.length() > 0 ? Double.parseDouble(zoomSelected) : 1.0;
        var camera = new Camera(new Vector(3.0, 2.0, 5.0), new Vector(-1.0, 0.5, 0.0), zoom);

        return new Scene(things, lights, camera);
    }

//    private void showFragment(Graphics image, Bitmap fragmentImage, int fragment, int fragments) {
//        using(Graphics g = Graphics.FromImage(image))
//        g.DrawImage(fragmentImage, 0, fragment * (image.Height / fragments));
//    }

    private static Object[] range(int max) {
        return new Object[max];
    }

    private void createUIComponents() {
        // TODO: place custom component creation code here
    }
}
