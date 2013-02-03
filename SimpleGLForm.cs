using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace OpenGLParticles
{
    public partial class SimpleGLForm : Form
    {
        Stopwatch timer = new Stopwatch();
        GLApplication app;

        private delegate void FrameUpdateDelegate();

        public SimpleGLForm()
        {
            InitializeComponent();
			app = new DummyApplication();
        }

        public SimpleGLForm(GLApplication application)
        {
            InitializeComponent();
            app = application;
        }


        private void ResizeViewport(uint height, uint width)
        {
			app.Resize(height, width);
		}

        private void glControl1_Load(object sender, EventArgs e)
        {
            ResizeViewport((uint)glControl1.Size.Height, (uint)glControl1.Size.Width);

            Application.Idle += new EventHandler(Application_Idle);

			app.Initialize();
            timer.Start();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            Update();
        }

        new void Update()
        {

            timer.Stop();
                       
            app.Update((float)timer.Elapsed.TotalMilliseconds);

            timer.Restart();

            glControl1.Invalidate();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            app.Render();

            glControl1.SwapBuffers();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            ResizeViewport((uint)glControl1.Height, (uint)glControl1.Width);

			Console.WriteLine("shit");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //((ParticleSystemApplication)app).StartSimulation((uint)trackbarNumberOfHumans.Value);
        }

    }
}
