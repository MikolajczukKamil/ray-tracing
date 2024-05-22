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
    public JComboBox thredsControl;
    public JComboBox zoomControll;
    public JCheckBox hugeBallControl;
    public JCheckBox smallBallControl;
    public JCheckBox bigBallControl;
    public JCheckBox groundControl;
    public JCheckBox redLightControl;
    public JCheckBox blueLightControl;
    public JCheckBox grayLightControl;
    public JCheckBox greenLightControl;
    public JLabel timeLabel;
    public JButton startButton;
    public JPanel renderedImage;
    public JPanel allContainer;

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

        groundControl.setSelected(true);
        bigBallControl.setSelected(true);
        smallBallControl.setSelected(true);
        hugeBallControl.setSelected(true);

        redLightControl.setSelected(true);
        blueLightControl.setSelected(true);
        greenLightControl.setSelected(true);
        grayLightControl.setSelected(true);

        zoomControll.setSelectedItem("1,5");
        thredsControl.setSelectedItem("8");

        setVisible(true);
    }

    private void start() {
        if (!startButton.isEnabled()) return;
        startButton.setEnabled(false);

        var startTime = System.currentTimeMillis();
        timeLabel.setText("...");

        var width = renderedImage.getWidth();
        var height = renderedImage.getHeight();

        var refresher = new ImageRefresh(renderedImage, this);

        refresher.refresh();

        var runner = new TracerRunner(getScene(), getThreads(), refresher);
        runner.startTime = startTime;
        runner.app = this;
        runner.width = width;
        runner.height = height;

        var runThread = new Thread(runner);
        runThread.start();
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
        var zoom = zoomSelected != null && zoomSelected.length() > 0 ? Double.parseDouble(zoomSelected.replace(",", ".")) : 1.0;
        var camera = new Camera(new Vector(3.0, 2.0, 5.0), new Vector(-1.0, 0.5, 0.0), zoom);

        return new Scene(things, lights, camera);
    }

    private static Object[] range(int max) {
        return new Object[max];
    }
}
