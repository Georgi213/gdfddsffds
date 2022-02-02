using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinoteatr_bilet
{
    public partial class Administrator : Form
    {
        
        Label authorization;
        Label login_lbl;
        TextBox login_txt;
        Label password_lbl;
        TextBox password_txt;
        Button accept_admin;
        //-------------
        Label title;
        Label lbl1;
        Label lbl3;
        Label lbl4;
        TextBox text1;
        TextBox text2;
        TextBox text3;
        TextBox text4;
        Button add;
        //-------------
        Label title_UP;
        Label lbl1_UP;
        Label lbl3_UP;
        Label lbl4_UP;
        TextBox text1_UP;
        TextBox text3_UP;
        TextBox text4_UP;

        Button add_UP;

        int Id_film;
        //-------------
        Button add_DL;

        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Kino_-main\AppData\Kino_DB.mdf;Integrated Security=True";
        /*Надо менять            ↑ ↑ ↑ ↑ ↑ ↑ ↑  вот это, если ты пересел за другой комп!!!!!!!!!*/
        SqlConnection connect_to_DB = new SqlConnection(conn);

        SqlCommand command;
        SqlDataAdapter adapter;
        DataGridView dataGridView;
        DataGridView dataGridView1;
        DataGridView dataGridView2;
        public Administrator()
        {
            this.ClientSize = new System.Drawing.Size(720, 500);


            Button naita = new Button
            {
                Text = "Naitamine",
                Location = new System.Drawing.Point(520, 150),//Point(x,y)
                Height = 50,
                Width = 120,
                BackColor = Color.LightGreen
            };
            naita.Click += Film_naita_Click;

            this.Controls.Add(naita);
            /*TextBox nimi = new TextBox
            {
                Location = new System.Drawing.Point(50, 40),//Point(x,y)
                Height = 80,
                Width = 150,
            };

            TextBox film = new TextBox
            {
                Location = new System.Drawing.Point(50, 80),//Point(x,y)
                Height = 80,
                Width = 150,
            };
            this.Controls.Add(nimi);
            this.Controls.Add(film);*/
            authorization = new Label()
            {
                Text = "Log in:",
                Size = new Size(185, 35),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(140, 280),
                BackColor = Color.Green,
                ForeColor = Color.White
            };

            login_lbl = new Label()
            {
                Text = "Login: ",
                Size = new Size(50, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(150, 325),
                BackColor = Color.Green,
                ForeColor = Color.White
            };

            login_txt = new TextBox()
            {
                Size = new Size(100, 20),
                Location = new Point(210, 325)
            };

            password_lbl = new Label()
            {
                Text = "Password: ",
                Size = new Size(80, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(120, 355),
                BackColor = Color.Green,
                ForeColor = Color.White
            };

            password_txt = new TextBox()
            {
                Size = new Size(100, 20),
                Location = new Point(210, 355),
                PasswordChar = '*'
            };

            accept_admin = new Button()
            {
                Text = "Confirm",
                Size = new Size(100, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Location = new Point(170, 395),
                Font = new Font(Font.FontFamily, 10)
            };

            accept_admin.Click += Accept_admin_Click;

            this.Controls.Add(authorization);
            this.Controls.Add(login_lbl);
            this.Controls.Add(password_lbl);
            this.Controls.Add(login_txt);
            this.Controls.Add(password_txt);
            this.Controls.Add(accept_admin);
        }
        private void Accept_admin_Click(object sender, EventArgs e)
        {
            if (login_txt.Text == "admin" && password_txt.Text == "admin")
            {
                login_lbl.Hide();
                login_txt.Hide();
                password_lbl.Hide();
                password_txt.Hide();
                accept_admin.Hide();
                authorization.Hide();

                this.Size = new Size(700, 600);

                Button select = new Button()
                {
                    Text = "Select",
                    Size = new Size(100, 40),
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    Location = new Point(50, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                select.Click += select_Click;

                Button insert = new Button()
                {
                    Text = "Insert",
                    Size = new Size(100, 40),
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    Location = new Point(210, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                insert.Click += Insert_Click;

                Button update = new Button()
                {
                    Text = "Update",
                    Size = new Size(100, 40),
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    Location = new Point(375, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                update.Click += Update_Click;

                Button delete = new Button()
                {
                    Text = "Delete",
                    Size = new Size(100, 40),
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    Location = new Point(530, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                delete.Click += Delete_Click;

                this.Controls.Add(select);
                this.Controls.Add(insert);
                this.Controls.Add(update);
                this.Controls.Add(delete);
            }
            else
            {
                login_txt.Text = "";
                password_txt.Text = "";
                MessageBox.Show("Error, uncorrect login or password");
            }
        }
        private void select_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 600);
            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select Id_film,Nimi, Aasta,Pilt from [dbo].[Film]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new Point(210, 175);
            dataGridView.Size = new Size(240, 200);
            this.Controls.Add(dataGridView);
            connect_to_DB.Close();

            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();
            }


            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }
        }
        private void Film_naita_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            DataGridView dataGridView = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id-film,Nimi,Aasta,Pilt FROM [dbo].[Film]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new System.Drawing.Point(10, 75);
            dataGridView.Size = new System.Drawing.Size(400, 200);
            this.Controls.Add(dataGridView);
            connect_to_DB.Close();
            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text2.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();
            }


            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 600);

            if (dataGridView != null)
            {
                dataGridView.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();
            }

            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }

            title = new Label()
            {
                Text = "Add data:",
                Size = new Size(130, 35),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(260, 100),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl1 = new Label()
            {
                Text = "Name: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 200),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };


            lbl3 = new Label()
            {
                Text = "Date: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 240),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl4 = new Label()
            {
                Text = "Image: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 280),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            text1 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 200)
            };


            text3 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 240)
            };

            text4 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 280)
            };

            add = new Button()
            {
                Text = "Add",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 320),
                Font = new Font(Font.FontFamily, 10)
            };

            add.Click += Add_Click;

            this.Controls.Add(title);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl3);
            this.Controls.Add(lbl4);
            this.Controls.Add(text1);
            this.Controls.Add(text3);
            this.Controls.Add(text4);
            this.Controls.Add(add);
        }
        private void Add_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("insert into Film(Nimi, Aasta, Pilt) values(@Nimi, @Aasta, @Pilt)", connect_to_DB);
            command.Parameters.AddWithValue("@Nimi", text1.Text);
            command.Parameters.AddWithValue("@Aasta", text3.Text);
            command.Parameters.AddWithValue("@Pilt", text4.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Insert is completed.");

            connect_to_DB.Close();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 500);

            if (dataGridView != null)
            {
                dataGridView.Hide();
            }

            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();
            }

            add_DL = new Button()
            {
                Text = "Delete",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 140),
                Font = new Font(Font.FontFamily, 10)
            };

            add_DL.Click += Add_DL_Click;

            DataTable tabel = new DataTable();
            dataGridView2 = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select Id_film,Nimi, Aasta,Pilt from [dbo].[Film]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView2.DataSource = tabel;
            dataGridView2.Location = new Point(150, 200);
            dataGridView2.Size = new Size(355, 150);

            dataGridView2.RowHeaderMouseClick += DataGridView2_RowHeaderMouseClick;

            this.Controls.Add(dataGridView2);

            this.Controls.Add(add_DL);
        }
        private void Update_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 600);

            if (dataGridView != null)
            {
                dataGridView.Hide();
            }

            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }

            title_UP = new Label()
            {
                Text = "Update data:",
                Size = new Size(180, 35),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(230, 100),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl1_UP = new Label()
            {
                Text = "Name: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 200),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };


            lbl3_UP = new Label()
            {
                Text = "Date: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 240),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl4_UP = new Label()
            {
                Text = "Picture: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 280),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            text1_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 200)
            };


            text3_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 240)
            };

            text4_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 280)
            };

            add_UP = new Button()
            {
                Text = "Update",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 310),
                Font = new Font(Font.FontFamily, 10)
            };

            add_UP.Click += Add_UP_Click;

            DataTable tabel = new DataTable();
            dataGridView1 = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select  Id_film,Nimi, Aasta,Pilt from [dbo].[Film]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView1.DataSource = tabel;
            dataGridView1.Location = new Point(50, 370);
            dataGridView1.Size = new Size(545, 150);

            dataGridView1.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;

            this.Controls.Add(dataGridView1);

            this.Controls.Add(title_UP);
            this.Controls.Add(lbl1_UP);
            this.Controls.Add(lbl3_UP);
            this.Controls.Add(lbl4_UP);
            this.Controls.Add(text1_UP);
            this.Controls.Add(text3_UP);
            this.Controls.Add(text4_UP);
            this.Controls.Add(add_UP);
        }
        private void DataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id_film = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void Add_DL_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("delete from Film where Id_film = @Id_film", connect_to_DB);
            command.Parameters.AddWithValue("@Id_film", Id_film);
            command.ExecuteNonQuery();

            MessageBox.Show("Delete is completed.");

            connect_to_DB.Close();
        }

        private void Add_UP_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("update Film set Nimi = @Nimi, Aasta = @Aasta, Pilt = @Pilt where Id_film = @Id_film", connect_to_DB);
            command.Parameters.AddWithValue("@Id_film", Id_film);
            command.Parameters.AddWithValue("@Nimi", text1.Text);
            command.Parameters.AddWithValue("@Aasta", text3.Text);
            command.Parameters.AddWithValue("@Pilt", text4.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Update is completed.");

            connect_to_DB.Close();
        }
        private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id_film = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            text1_UP.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            text3_UP.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "")
            {
                text4_UP.Text = "null";
            }
            else
            {
                text4_UP.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
