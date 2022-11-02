namespace _2ndProject;

public partial class Form1 : Form
{
    Bitmap backg;//Για να μενει η ζωγραφια παρα το minimize
    Graphics g, graph;
    bool paint = false;
    int? startx = null;// Απο που θα αρχιζει να γραφει η πενα
    int? starty = null;
    bool usepaintb = false;// Bool για το ποιες βουρτσες χρησιμοποιω
    bool usepencil = false;

    public Form1()
    {
        InitializeComponent();
        g = panel1.CreateGraphics();

        backg = new Bitmap(panel1.Width, panel1.Height);// Κανω το bitmap του panel απο το graph g
        graph = Graphics.FromImage(backg);
        panel1.BackgroundImage = backg;//Θετω το backg ως background image του panel
        panel1.BackgroundImageLayout = ImageLayout.Stretch;
    }


    private void colorpicker_Click(object sender, EventArgs e)// Επιλογη χρωματος
    {
        colorDialog1.ShowDialog();
        urcolor.BackColor = colorDialog1.Color;

    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (paint)
        {
            if (usepaintb)
            {
                Pen paintbrush = new Pen(urcolor.BackColor, 5.0F);
                graph.DrawLine(paintbrush, new Point(startx ?? e.X, starty ?? e.Y), new Point(e.X, e.Y));//Ζωγραφιζω στα graphics
                g.DrawLine(paintbrush, new Point(startx ?? e.X, starty ?? e.Y), new Point(e.X, e.Y));

                startx = e.X;
                starty = e.Y;


            }
            if (usepencil)
            {
                Pen pencil = new Pen(urcolor.BackColor, 2.0F);
                graph.DrawLine(pencil, new Point(startx ?? e.X, starty ?? e.Y), new Point(e.X, e.Y)); // Ζωγραφιζω στα graphics
                g.DrawLine(pencil, new Point(startx ?? e.X, starty ?? e.Y), new Point(e.X, e.Y)); ;

                startx = e.X;
                starty = e.Y;
            }
        }
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        paint = true;// Οσο παταω ζωγραφιζω
    }

    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        paint = false;// Οταν σηκωνω το mouse σταματαω να ζωγραφιζω και κανω reset στις αρχικες τιμες της πενας
        startx = null;
        starty = null;
    }

    private void brush_Click(object sender, EventArgs e)// Επιλογη βουρτσας
    {
        usepaintb = true;
        usepencil = false;
    }

    private void pencil_Click(object sender, EventArgs e)//Επιλογη μολυβιου
    {
        usepencil = true;
        usepaintb = false;

    }
}
