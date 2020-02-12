using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace Image_Processing
{
    public partial class Form1 : Form
    {
        VideoCapture video = new VideoCapture(0);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_default.xml");

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Mat frame = new Mat();
            //Mat hough = new Mat();
            //video.Read(frame);
            //video.Read(hough);
            //Cv2.CvtColor(hough, hough, ColorConversionCodes.BGR2GRAY);
            //Cv2.Canny(hough, hough, 50, 100);

            //LineSegmentPolar[] lines = Cv2.HoughLines(hough, 1, Math.PI / 180, 100);


            //for (int i = 0; i < lines.Length; i++)
            //{
            //    float rho = lines[i].Rho;
            //    float theta = lines[i].Theta;
            //    double c = Math.Cos(theta);
            //    double s = Math.Sin(theta);
            //    int x0 = (int)(c * rho);
            //    int y0 = (int)(s * rho);
            //    int x1 = (int)(x0 + 1000 * (-s));
            //    int y1 = (int)(y0 + 1000 * (c));
            //    int x2 = (int)(x0 - 1000 * (-s));
            //    int y2 = (int)(y0 - 1000 * (c));
            //    Cv2.Line(frame, x1, y1, x2, y2, Scalar.Red);
            //}

            //pictureBoxIpl1.ImageIpl = frame;



            /************************************************************************************************************/



            Mat frame = new Mat();
            video.Read(frame);

            
            if(classifier.Empty())
            {
                MessageBox.Show("읽기 실패");
                return;
            }

            try
            {
                Rect[] faces = classifier.DetectMultiScale(frame);

                for (int i = 0; i < faces.Length; i++)
                {
                    Rect face = faces[i];
                    Cv2.Rectangle(frame, face, Scalar.Red, 2);
                }
            }
            catch { }
            pictureBoxIpl1.ImageIpl = frame;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            video.Release();
        }
    }
}
