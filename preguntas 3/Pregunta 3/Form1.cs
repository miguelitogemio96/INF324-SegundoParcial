using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Pregunta_3
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;
        int r_bd, g_bd, b_bd;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(10, 10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cR = c.R;
            cG = c.G;
            cB = c.B;*/

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x, y, mR = 0, mG = 0, mB = 0;
            x = e.X; y = e.Y;
            for (int i = x; i < x + 10; i ++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            cR = mR;
            cG = mG;
            cB = mB;
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox2.Image = cpoa;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(c.R,0,0));
                }
            pictureBox2.Image = cpoa;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (cR - 10 <= c.R && c.R <= cR + 10 && cG - 10 <= c.G && c.G <= cG + 10 && cB - 10 <= c.B && c.B <= cB + 10)
                        cpoa.SetPixel(i, j, Color.Black);
                    else
                        cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width -10 ; i+=10)
                for (int j = 0; j < bmp.Height - 10; j+=10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;
                    for (int k = i; k<i+10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    meR = meR/100;
                    meG = meG / 100;
                    meB = meB / 100;
                    if (cR - 10 <= meR && meR <= cR + 10 && cG - 10 <= meG && meG <= cG + 10 && cB - 10 <= meB && meB <= cB + 10)
                        for (int k = i; k<i+10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Black);
                            }
                        
                    else
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }
                        
                }
            pictureBox2.Image = cpoa;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            label2.Text = pictureBox1.Image.ToString();
            insertarImagen();
        }
        private void insertarImagen()
        {         
            ImageConverter converter = new ImageConverter();
            Byte[] imagenOriginal = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlDataReader SqlDataReader;
            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = imagenes_bd";
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "INSERT INTO imagenes(imagen,titulo) Values(@imagen,@titulo)";
            SqlCommand.Parameters.Add("@imagen", SqlDbType.Image).Value = imagenOriginal;
            SqlCommand.Parameters.Add("@titulo", SqlDbType.Text).Value = "prueba";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;
            SqlCommand.Connection.Open();
            SqlDataReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);                        

            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlDataReader SqlDataReader;

            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = texturas_bd";

            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT * FROM texturas where id = 2";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;

            SqlCommand.Connection.Open();
            SqlDataReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (SqlDataReader.Read())
            {
                r_bd = SqlDataReader.GetInt32(2);
                g_bd = SqlDataReader.GetInt32(3);
                b_bd = SqlDataReader.GetInt32(4);
                textBox1.Text = r_bd.ToString();
                textBox2.Text = g_bd.ToString();
                textBox3.Text = b_bd.ToString();

                int meR, meG, meB;
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i += 10)
                    for (int j = 0; j < bmp.Height - 10; j += 10)
                    {
                        meR = 0;
                        meG = 0;
                        meB = 0;
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                meR = meR + c.R;
                                meG = meG + c.G;
                                meB = meB + c.B;
                            }
                        meR = meR / 100;
                        meG = meG / 100;
                        meB = meB / 100;
                        if (r_bd - 10 <= meR && meR <= r_bd + 10 && g_bd - 10 <= meG && meG <= g_bd + 10 && b_bd - 10 <= meB && meB <= b_bd + 10)
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    cpoa.SetPixel(k, l, Color.Black);
                                }

                        else
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    c = bmp.GetPixel(k, l);
                                    cpoa.SetPixel(k, l, c);
                                }

                    }
                pictureBox2.Image = cpoa;

            }
            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
                       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = texturas_bd";
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "UPDATE texturas set nombre = @nombre, r = @r, g = @g, b = @b where id = 1";
            SqlCommand.Parameters.Add("@nombre", SqlDbType.Text).Value = textBox4.Text.ToString();
            SqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = int.Parse(textBox1.Text.ToString());
            SqlCommand.Parameters.Add("@g", SqlDbType.Int).Value = int.Parse(textBox2.Text.ToString());
            SqlCommand.Parameters.Add("@b", SqlDbType.Int).Value = int.Parse(textBox3.Text.ToString());
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;
            SqlCommand.Connection.Open();
            SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
            button14.Text = textBox4.Text.ToString();
            textBox4.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = texturas_bd";
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "UPDATE texturas set nombre = @nombre, r = @r, g = @g, b = @b where id = 2";
            SqlCommand.Parameters.Add("@nombre", SqlDbType.Text).Value = textBox4.Text.ToString();
            SqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = int.Parse(textBox1.Text.ToString());
            SqlCommand.Parameters.Add("@g", SqlDbType.Int).Value = int.Parse(textBox2.Text.ToString());
            SqlCommand.Parameters.Add("@b", SqlDbType.Int).Value = int.Parse(textBox3.Text.ToString());
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;
            SqlCommand.Connection.Open();
            SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
            button13.Text = textBox4.Text.ToString();
            textBox4.Text = "";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = texturas_bd";
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "UPDATE texturas set nombre = @nombre, r = @r, g = @g, b = @b where id = 3";
            SqlCommand.Parameters.Add("@nombre", SqlDbType.Text).Value = textBox4.Text.ToString();
            SqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = int.Parse(textBox1.Text.ToString());
            SqlCommand.Parameters.Add("@g", SqlDbType.Int).Value = int.Parse(textBox2.Text.ToString());
            SqlCommand.Parameters.Add("@b", SqlDbType.Int).Value = int.Parse(textBox3.Text.ToString());
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;
            SqlCommand.Connection.Open();
            SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
            button12.Text = textBox4.Text.ToString();
            textBox4.Text = "";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlDataReader SqlDataReader;

            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = texturas_bd";

            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT * FROM texturas where id = 1";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;

            SqlCommand.Connection.Open();
            SqlDataReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (SqlDataReader.Read())
            {                
                r_bd = SqlDataReader.GetInt32(2);
                g_bd = SqlDataReader.GetInt32(3);
                b_bd = SqlDataReader.GetInt32(4);
                textBox1.Text = r_bd.ToString();
                textBox2.Text = g_bd.ToString();
                textBox3.Text = b_bd.ToString();

                int meR, meG, meB;
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i += 10)
                    for (int j = 0; j < bmp.Height - 10; j += 10)
                    {
                        meR = 0;
                        meG = 0;
                        meB = 0;
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                meR = meR + c.R;
                                meG = meG + c.G;
                                meB = meB + c.B;
                            }
                        meR = meR / 100;
                        meG = meG / 100;
                        meB = meB / 100;
                        if (r_bd - 10 <= meR && meR <= r_bd + 10 && g_bd - 10 <= meG && meG <= g_bd + 10 && b_bd - 10 <= meB && meB <= b_bd + 10)
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    cpoa.SetPixel(k, l, Color.Black);
                                }

                        else
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    c = bmp.GetPixel(k, l);
                                    cpoa.SetPixel(k, l, c);
                                }

                    }
                pictureBox2.Image = cpoa;

            }  
            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
                       
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            SqlConnection SqlConnection;
            SqlCommand SqlCommand;
            SqlDataReader SqlDataReader;

            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = "server = (local); user = user324; pwd = 123456; database = texturas_bd";

            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT * FROM texturas where id = 3";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.Connection = SqlConnection;

            SqlCommand.Connection.Open();
            SqlDataReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (SqlDataReader.Read())
            {
                r_bd = SqlDataReader.GetInt32(2);
                g_bd = SqlDataReader.GetInt32(3);
                b_bd = SqlDataReader.GetInt32(4);
                textBox1.Text = r_bd.ToString();
                textBox2.Text = g_bd.ToString();
                textBox3.Text = b_bd.ToString();

                int meR, meG, meB;
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                for (int i = 0; i < bmp.Width - 10; i += 10)
                    for (int j = 0; j < bmp.Height - 10; j += 10)
                    {
                        meR = 0;
                        meG = 0;
                        meB = 0;
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                meR = meR + c.R;
                                meG = meG + c.G;
                                meB = meB + c.B;
                            }
                        meR = meR / 100;
                        meG = meG / 100;
                        meB = meB / 100;
                        if (r_bd - 10 <= meR && meR <= r_bd + 10 && g_bd - 10 <= meG && meG <= g_bd + 10 && b_bd - 10 <= meB && meB <= b_bd + 10)
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    cpoa.SetPixel(k, l, Color.Black);
                                }

                        else
                            for (int k = i; k < i + 10; k++)
                                for (int l = j; l < j + 10; l++)
                                {
                                    c = bmp.GetPixel(k, l);
                                    cpoa.SetPixel(k, l, c);
                                }

                    }
                pictureBox2.Image = cpoa;

            }
            SqlCommand.Dispose();
            SqlConnection.Dispose();
            SqlConnection.Close();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {

        }



    }
}
