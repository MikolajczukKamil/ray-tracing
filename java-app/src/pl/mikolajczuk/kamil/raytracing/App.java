package pl.mikolajczuk.kamil.raytracing;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;

public class App extends JFrame {
    private JComboBox iloscWatkow;
    private JComboBox zoomValue;
    private JCheckBox wielkaKulaCheckBox;
    private JCheckBox małaKulaCheckBox;
    private JCheckBox dużaKulaCheckBox;
    private JCheckBox podłogaCheckBox;
    private JCheckBox czerwoneCheckBox;
    private JCheckBox niebieskieCheckBox;
    private JCheckBox szareCheckBox;
    private JCheckBox zieloneCheckBox;
    private JLabel time;
    private JButton startButton;
    private JPanel somePanel;
    private JPanel allContainer;

    public App() {
        super();

        setTitle("Ray tracer - Kamil Mikołajczuk, Karol Kowalski");
        setSize(1784, 961);
        setContentPane(allContainer);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setVisible(true);

        BufferedImage image = new BufferedImage(getWidth(), getHeight(), BufferedImage.TYPE_INT_ARGB);
        Graphics g = image.getGraphics();

        g.setColor(Color.blue);
        g.fillRect(50, 50, 150, 500);

        somePanel.paint(g);
        somePanel.repaint();
//        somePanel.update(g);
        startButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                super.mouseClicked(e);
            }
        });
    }
}
