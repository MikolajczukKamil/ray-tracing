package pl.mikolajczuk.kamil.raytracing;

import javax.swing.*;
import java.awt.image.BufferedImage;

public class ImageRefresh {
    public BufferedImage image;
    public JPanel renderedImage;
    public JFrame frame;

    public ImageRefresh(JPanel RenderedImage, JFrame Frame) {
        image = new BufferedImage(RenderedImage.getWidth(), RenderedImage.getHeight(), BufferedImage.TYPE_INT_ARGB);
        renderedImage = RenderedImage;
        frame = Frame;
    }

    public void refresh() {
        synchronized (this) {
            var picLabel = new JLabel(new ImageIcon(image));
            picLabel.setSize(renderedImage.getSize());

            renderedImage.removeAll();
            renderedImage.add(picLabel);
            frame.repaint();
        }
    }
}
