package pl.mikolajczuk.kamil.raytracing;

import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;

public class RenderCanvas extends JPanel {
    private BufferedImage image;

    public void updateImage(BufferedImage i) {
        image = i;

        repaint();
    }

    @Override
    protected void paintComponent(Graphics g) {
        if (image != null) {
//            g.drawImage(image, 0, 0, this);
        }

        super.paintComponent(g);
    }
}
