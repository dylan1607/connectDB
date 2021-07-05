using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;


namespace Get_Drawing
{
    public partial class Form1 : Form
    {

        private OleDbConnection connACC = new OleDbConnection();

        private OdbcConnection connPART = new OdbcConnection();

        DataGridViewButtonColumn New, Print, Drawing, Old, Copy;

        DataTable dt_drawing_list = new DataTable();

        string path_image, path_drawing, olderVersion, sql, abc, division, price, amount, input;

        string fileToCopy;

        int a, oldVersion, curRow, length_string, drawDate;

        string[] line;

        string[] type_Drawing = {   "dbo_T_Draw_DrawingList", 
                                    "dbo_T_Draw_JIG_Drawing_List", 
                                    "dbo_T_Draw_Specail_Drawing", 
                                    "dbo_Machine_Drawing_List", 
                                    "dbo_General_Drawing_List", 
                                    "dbo_T_Draw_TEST_DRAWING_LIST",
                                    "FIND CODE T",
                                    "FIND PART NAME"};

        string[] pathImage = {  @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\DR-TE",      //0
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\DR-TE-JG",   //1
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\DR-TE-SC",   //2
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\DR-TE-MA",   //3
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\DR-TE-GR",   //4
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\DR-TE-TS",   //5
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS\Ban ve",     //6           
                                @"\\192.168.0.6\f2_te\CONTROL\DRAWING\SCANNED DRAWINGS" };          //7

        public Form1()
        {
            InitializeComponent();

            cb_Type_Drawing.Items.AddRange(type_Drawing);

            //String to connect to DRAWING LIST

            line = System.IO.File.ReadAllLines(Application.StartupPath + "/SETTING.txt");

            connACC.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + line[0].Split(':').Last() + "";

            connPART.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)};DBQ=" + line[1].Split(':').Last() + "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_Type_Drawing.SelectedIndex = 0;
        }      

        private void Connect_ACCESS()
        {   
            //CONNECT SERVER DRAWING LIST
            if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0] || cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[1] || cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[2] || cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[3] || cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[4] || cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[5])
            {
                try
                {
                    connACC.Open();
                }
                catch
                {
                    MessageBox.Show("Can Not Connect To DRAWING Server !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //CONNECT SERVER PUR_SHARE
            else
            {
                try
                {
                    connPART.Open();
                }
                catch
                {
                    MessageBox.Show("Can Not Connect To DTM_STOCK Server !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
            {
                a = 1;
                abc = "";
                division = "";

                //  CHOOSE PROCESS
                if (!chb_Inspec.Checked)
                    abc = string.Empty;
                else
                    abc = " and Processe like '%inspection%'";

                // CHOOSE DIVISION
                if (!chb_press.Checked)
                    if (!chb_mold.Checked)
                        if (!chb_guide.Checked)
                        {
                            division = string.Empty;
                        }
                        else
                        {
                            division = " and Division like '%GUIDE%'";
                        }
                    else
                    {
                        division = " and Division like '%MOLD%'";
                    }
                else
                {
                    division = " and Division like '%PRESS%'";
                }

                sql = "select NewDrawingNo, ProductName, Processe, ProductType, EffectDate, drawdate, Drawer, Division " +
                     "from " + type_Drawing[0] + " " +
                     "where (NewDrawingNo like '%" + txt_Search.Text + "%' " +
                     "or ProductName like '%" + txt_Search.Text + "%' " +
                     "or ProductType like '%" + txt_Search.Text + "%')" +
                     "" + abc + 
                     "" + division + "";

                dataGridView1.Size = new Size(1148, 480);
                dataGridView2.Visible = false;
                path_image = pathImage[0];
            }
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[2])
            {
                a = 0;
                sql = "select DRAWING_NUNBER, PRODUCT_NAME, EffectDate, CLASSIFICATION, Drawer, Division  " +
                    "from " + type_Drawing[2] + " " +
                    "where PRODUCT_NAME like '%" + txt_Search.Text + "%' " +
                    "or DRAWING_NUNBER like '%" + txt_Search.Text + "%' " +
                    "or CLASSIFICATION like '%" + txt_Search.Text + "%'";
                dataGridView1.Size = new Size(1148, 480);
                dataGridView2.Visible = false;
                path_image = pathImage[2];
            }
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[1])
            {
                a = 0;

                sql = "select `DRAWING NAME`, `PART NAME`, `FOR GROUP`, Division,EffectDate, TILE " +
                    "from " + type_Drawing[1] + " " +
                    "where TILE like '%" + txt_Search.Text + "%' " +
                    "or `DRAWING NAME` like '%" + txt_Search.Text + "%' " +
                    "or `FOR GROUP` like '%" + txt_Search.Text + "%' ";
                dataGridView1.Size = new Size(1148, 480);
                dataGridView2.Visible = false;
                path_image = pathImage[1];
            }
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[3])
            {
                a = 0;

                sql = "select `DRAWING_NAME`, `Part_Name`, `Title`, `Division`, EffectDate, Group " +
                    "from " + type_Drawing[3] + " " +
                    "where `DRAWING_NAME` like '%" + txt_Search.Text + "%' " +
                    "or `Part_Name` like '%" + txt_Search.Text + "%' " +
                    "or `Title` like '%" + txt_Search.Text + "%' " +
                    "or `Division` like '%" + txt_Search.Text + "%' ";
                dataGridView1.Size = new Size(1148, 480);
                dataGridView2.Visible = false;
                path_image = pathImage[3];
            }
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[4])
            {
                a = 0;

                sql = "select `Drawing_Name`, `Part_Name`, `Title`, EffectDate " +
                    "from " + type_Drawing[4] + " " +
                    "where  `Drawing_Name`  like '%" + txt_Search.Text + "%' " +
                    "or     `Title`         like '%" + txt_Search.Text + "%' " +
                    "or     `Part_Name`     like '%" + txt_Search.Text + "%' ";
                dataGridView1.Size = new Size(1148, 480);
                dataGridView2.Visible = false;
                path_image = pathImage[4];
            }

            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[5])
            {
                a = 0;

                sql = "select `Drawing_Name`, `Part_Name`, `Title`, EffectDate, Drawdate, Processe  " +
                    "from " + type_Drawing[5] + " " +
                    "where  `Drawing_Name`  like '%" + txt_Search.Text + "%' " +
                    "or     `Title`         like '%" + txt_Search.Text + "%' " +
                    "or     `Part_Name`     like '%" + txt_Search.Text + "%' ";
                dataGridView1.Size = new Size(1148, 480);
                dataGridView2.Visible = false;
                path_image = pathImage[5];
            }

            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[6])
            {
                a = 0;
                string month = DateTime.Now.ToString("MM");
                string year = DateTime.Now.ToString("yyyy");

                
                sql = "select MATNR, LFGJA, LFMON, LABST_612I, STOCK_PRICE " +
                    "from SNKTR2K_DTM_STOCK " +
                    "where MATNR like '%" + txt_Search.Text + "%' " +
                    "and LFGJA like '" + year + "' " +
                    "and LFMON like '" + month + "' ";
                dataGridView2.Visible = true;
            }

            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[7])
            {
                a = 0;
                sql = "select MATNR, MAKTX " +
                    "from SNKTR2K_DTM_PART " +
                    "where MATNR like '%" + input + "%' " +
                    "or MAKTX like '%" + input + "%' " +
                    "or MAKTX like UCASE('%" + input + "%') " +
                    "or MAKTX like LCASE('%" + input + "%') ";
                dataGridView2.Visible = true;
            }

            if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[6])
            {
                
                if (txt_Search.Text != string.Empty)
                {
                    OdbcCommand cmd = new OdbcCommand(sql, connPART);
                    OdbcDataAdapter data = new OdbcDataAdapter(cmd);
                    DataTable record = new DataTable();
                    data.Fill(record);
                    DataTable record_temp = new DataTable();
                    if (record.Rows.Count >= 1)
                    {
                        price = record.Rows[0]["STOCK_PRICE"].ToString();
                        amount = record.Rows[0]["LABST_612I"].ToString();

                        string[] list = price.Split('.');
                        price = list[0];
                        list = amount.Split('.');
                        amount = list[0];

                        record_temp.Columns.Add("MÃ KHO");
                        record_temp.Columns.Add("SỐ LƯỢNG");
                        record_temp.Columns.Add("TỔNG TIỀN");
                        var dr = record_temp.NewRow();
                        dr["MÃ KHO"] = txt_Search.Text;
                        dr["SỐ LƯỢNG"] = amount;
                        dr["TỔNG TIỀN"] = price;
                        record_temp.Rows.Add(dr);
                    }
                    else
                        MessageBox.Show("OUT STOCK.\nMã kho đã hết", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //dataGridView1.DataSource = record1;
                    dataGridView2.Columns.Clear();
                    dataGridView2.DataSource = record_temp;
                    //dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                }
            }
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[7])
            {
                if (txt_Search.Text != string.Empty)
                {
                    dataGridView1.Columns.Clear();
                    OdbcCommand cmd = new OdbcCommand(sql, connPART);
                    OdbcDataAdapter data = new OdbcDataAdapter(cmd);
                    DataTable record = new DataTable();
                    data.Fill(record);
                    if (record.Rows.Count >= 0)
                    {
                        dataGridView1.DataSource = record;
                        dataGridView1.Columns[1].Width = 300;
                    }
                    else
                        MessageBox.Show("OUT STOCK.\nMã kho đã hết", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dataGridView1.Columns.Clear();
                OleDbCommand cmd = new OleDbCommand(sql, connACC);
                OleDbDataAdapter data = new OleDbDataAdapter(cmd);
                DataTable record = new DataTable();
                data.Fill(record);
                dataGridView1.DataSource = record;
                addButtonsToDgv(dataGridView1);
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                
            }

            //Close Connection to Server
            connACC.Close();
            connPART.Close();
        }
        //Add Button OPEN and PRINT to Datagridvew
        private void addButtonsToDgv(DataGridView dgv)
        {            
                New = new DataGridViewButtonColumn();
                New.Text = "New";
                New.UseColumnTextForButtonValue = true;
                New.Width = 45;
                dgv.Columns.Add(New);

                if (a == 1)
                {
                    Old = new DataGridViewButtonColumn();
                    Old.Text = "Old";
                    Old.UseColumnTextForButtonValue = true;
                    Old.Width = 45;
                    dgv.Columns.Add(Old);
                }

                Copy = new DataGridViewButtonColumn();
                Copy.Text = "Copy";
                Copy.UseColumnTextForButtonValue = true;
                Copy.Width = 45;
                dgv.Columns.Add(Copy);

                Print = new DataGridViewButtonColumn();
                Print.Text = "Print";
                Print.UseColumnTextForButtonValue = true;
                Print.Width = 45;
                dgv.Columns.Add(Print);

                Drawing = new DataGridViewButtonColumn();
                Drawing.Text = "Drawing";
                Drawing.UseColumnTextForButtonValue = true;
                Drawing.Width = 60;
                dgv.Columns.Add(Drawing);
        }
        // Event when button in cell content clicked 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            curRow = int.Parse(e.RowIndex.ToString());
            int curClm = int.Parse(e.ColumnIndex.ToString());

            Process photoViewer = new Process();

            //Event when NEW button clicked
            if (curClm == dataGridView1.ColumnCount - (a + 4))
            {
                try
                {
                    photoViewer.StartInfo.FileName = Get_Path_Of_Image(path_image);
                    photoViewer.Start();
                }
                catch
                {
                    if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
                        path_image = pathImage[6];
                    else
                        path_image = pathImage[7];
                    try
                    {
                        photoViewer.StartInfo.FileName = Get_Path_Of_Image(path_image);
                        photoViewer.Start();
                    }
                    catch
                    {
                        MessageBox.Show("Image File Not Exist !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //Event when OLD button clicked
            if (a == 1)
            {
                if (curClm == dataGridView1.ColumnCount - 4)
                {
                    path_image = pathImage[6]; ;

                    string fileName = dataGridView1.Rows[curRow].Cells[0].Value.ToString();

                    oldVersion = Convert.ToInt16(fileName.Substring(12, 2)) - 1;

                    if (oldVersion < 10)
                    {
                        olderVersion = fileName.Substring(0, 12) + "0" + Convert.ToString(oldVersion) + ".tif";
                    }
                    else olderVersion = fileName.Substring(0, 12) + Convert.ToString(oldVersion) + ".tif";

                    string[] directoryImageFile_1st = Directory.GetFiles(path_image, olderVersion, SearchOption.AllDirectories);

                    try
                    {
                        photoViewer.StartInfo.FileName = directoryImageFile_1st[0];
                        photoViewer.Start();
                    }
                    catch
                    {
                        MessageBox.Show("Image File Not Exist !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            //Event when PRINT button clicked
            if (curClm == dataGridView1.ColumnCount - 2)
            {
                try
                {
                    //PrintDocument pd = new PrintDocument();
                    //pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    //pd.PrintPage += PrintPage;
                    //pd.Print();
                }
                catch
                {
                    //MessageBox.Show("Image File Not Exist !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Event when DRAWING button clicked
            if (curClm == dataGridView1.ColumnCount - 1)
                Get_Path_Of_Drawing_File_By_Window_Search();

            //Event when COPY button clicked
            if (curClm == dataGridView1.ColumnCount - 3)
            {
                try
                {
                    fileToCopy = Get_Path_Of_Image(path_image);
                }
                catch
                {
                    if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
                        path_image = pathImage[6];
                    else
                        path_image = pathImage[7];
             
                    try
                    {
                        fileToCopy = Get_Path_Of_Image(path_image);
                    }
                    catch
                    {
                        MessageBox.Show("Image File Not Exist. !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                string destinationDirectory = txtBoxPath.Text+"\\";

                if (destinationDirectory == "\\")
                    MessageBox.Show("Choose Destination Folder. Click button Browser Folder !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    try
                    {
                        File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));
                    }
                    catch
                    {
                        MessageBox.Show("Image Already Exists. !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img;
            //Load the image from the file
            try
            {
                img = System.Drawing.Image.FromFile(Get_Path_Of_Image(path_image));
            }
            catch
            {
                if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
                    path_image = pathImage[6];
                else
                    path_image = pathImage[7];

                img = System.Drawing.Image.FromFile(Get_Path_Of_Image(path_image));
            }

            //rotate image if image is horizontal
            if (img.Height < img.Width)
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            //Adjust the size of the image, to print the full image without loosing any part of it
            Rectangle m = new Rectangle(0, 0, e.PageBounds.Width - 20, e.PageBounds.Height - 35);

            e.Graphics.DrawImage(img, m);

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        //Get path string of scanned image in data server
        private string Get_Path_Of_Image(string path_of_image)
        {
            string fileName = dataGridView1.Rows[curRow].Cells[0].Value.ToString() + ".tif";

            string[] file = Directory.GetFiles(path_of_image, fileName, SearchOption.AllDirectories);

            return file[0];
        }
        // Not use this one
        private string[] Get_Path_Of_Drawing_File()
        {
            string path;

            int drawDate = Convert.ToInt16((dataGridView1.Rows[curRow].Cells[5].Value.ToString().Split(' ').First()).Split('/')[2]);

            if (drawDate < 2009)
                path = @"\\192.168.0.6\f2_te\DESIGN\PRODUCT DRAWINGS";
            else
                path = @"\\192.168.0.6\f2_te\DESIGN\NEW PROJECTS\" + drawDate + "-DRAWINGS";

            string fileName = dataGridView1.Rows[curRow].Cells[0].Value.ToString().Substring(0, 11);

            var file = Directory.GetFiles(path, "*" + fileName + "*", SearchOption.AllDirectories).Where(name => name.EndsWith(".dft"));

            return file.ToArray();
        }
        //Start window search
        private void Get_Path_Of_Drawing_File_By_Window_Search()
        {

            if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
            {
                // check existence of drawDate
                if (dataGridView1.Rows[curRow].Cells[5].Value.ToString() == string.Empty)
                    drawDate = 2000;
                else
                    drawDate = Convert.ToInt16(dataGridView1.Rows[curRow].Cells[5].Value.ToString().Substring(
                                                dataGridView1.Rows[curRow].Cells[5].Value.ToString().LastIndexOf("20"), 4));

                if (drawDate < 2009)
                    path_drawing = @"\\192.168.0.6\f2_te\DESIGN\PRODUCT DRAWINGS";
                else
                    path_drawing = @"\\192.168.0.6\f2_te\DESIGN\NEW PROJECTS\" + drawDate + "-DRAWINGS";
            }
            // find JIG drawings 
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[1])
            {
                path_drawing = @"\\192.168.0.6\f2_te\TECHNICAL\JIG DRAWINGS";
            }
            // find SPECIAL drawings 
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[2])
            {
                path_drawing = @"\\192.168.0.6\f2_te\DESIGN\SPECIAL DRAWINGS";
            }
            // find MACHINE drawing 
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[3])
            {
                if (dataGridView1.Rows[curRow].Cells[3].Value.ToString() == "PRESS")
                    path_drawing = @"\\192.168.0.6\f2_te\TECHNICAL\MACHINE DRAWINGS\PRESS";
                else if (dataGridView1.Rows[curRow].Cells[3].Value.ToString() == "MOLD")
                    path_drawing = @"\\192.168.0.6\f2_te\TECHNICAL\MACHINE DRAWINGS\MOLD";
                else
                    path_drawing = @"\\192.168.0.6\f2_te\TECHNICAL\MACHINE DRAWINGS";
            }
             // find GENERAL drawings 
            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[4])
            {
                path_drawing = @"\\192.168.0.6\f2_te\TECHNICAL\GENERAL DRAWINGS";
            }

            else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[5])
            {
                path_drawing = @"\\192.168.0.6\f2_te\TECHNICAL\GENERAL DRAWINGS";
            }

            if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[5])
            {
                // check existence of drawDate
                if (dataGridView1.Rows[curRow].Cells[4].Value.ToString() == string.Empty)
                    drawDate = 2000;
                else
                    drawDate = Convert.ToInt16(dataGridView1.Rows[curRow].Cells[4].Value.ToString().Substring(
                                                dataGridView1.Rows[curRow].Cells[4].Value.ToString().LastIndexOf("20"), 4));

                if (drawDate < 2009)
                    path_drawing = @"\\192.168.0.6\f2_te\DESIGN\TEST DRAWINGS";
                else
                    path_drawing = @"\\192.168.0.6\f2_te\DESIGN\TEST DRAWINGS\" + drawDate +"";
            }

            if (cb_Type_Drawing.SelectedItem.ToString() != type_Drawing[0])
            {
                length_string = 14;
            }

            else length_string = 11;

            if (cb_Type_Drawing.SelectedItem.ToString() != type_Drawing[6] && cb_Type_Drawing.SelectedItem.ToString() != type_Drawing[7])
            {
                string fileName = dataGridView1.Rows[curRow].Cells[0].Value.ToString().Substring(0, length_string);

                string folder = Uri.EscapeDataString(path_drawing);

                string uri = "search:query=" + fileName + "&crumb=location:" + folder;

                Process.Start(new ProcessStartInfo(uri));
            }

        }



        // Not use this one
        private void updatetodatagridview()
        {
            dt_drawing_list.Columns.Add("Result");

            for (int i = 0; i <= (Get_Path_Of_Drawing_File().Count() - 1); i++)
            {
                dt_drawing_list.Rows.Add();

                int a = Get_Path_Of_Drawing_File()[i].LastIndexOf("\\DR-TE");

                dt_drawing_list.Rows[i][0] = Get_Path_Of_Drawing_File()[i].Substring(a + 1);
            }

            //dgv_result.DataSource = dt_drawing_list;

            //dgv_result.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        // event when enter key pressed
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[7])
                {
                    string temp1, temp2;
                    temp1 = txt_Search.Text.ToString().ToLower();
                    temp2 = temp1[0].ToString().ToUpper();
                    temp1 = temp1.Substring(1);
                    input = temp1.Insert(0, temp2);
                }
                btn_Search_Click(sender, e);
            }
        }

        private void cb_Type_Drawing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[7] || cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[6])
            {
                chb_press.Hide();
                chb_mold.Hide();
                chb_guide.Hide();
                chb_Inspec.Hide();
                txtBoxPath.Hide();
                button4.Hide();
                btnCopyAll.Hide();
            }
            else
            {
                chb_press.Show();
                chb_mold.Show();
                chb_guide.Show();
                chb_Inspec.Show();
                txtBoxPath.Show();
                button4.Show();
                btnCopyAll.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.Clear();
            txt_Search.Focus();
            dt_drawing_list.Columns.Clear();
        }

        private void chb_Inspec_CheckedChanged(object sender, EventArgs e)
        {
            btn_Search_Click(sender, e);
        }

        private void chb_press_CheckedChanged(object sender, EventArgs e)
        {
            btn_Search_Click(sender, e);
        }
        private void chb_mold_CheckedChanged(object sender, EventArgs e)
        {
            btn_Search_Click(sender, e);
        }

        private void chb_guide_CheckedChanged(object sender, EventArgs e)
        {
            btn_Search_Click(sender, e);
        }
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            txt_Search.CharacterCasing = CharacterCasing.Upper;
        }

        private void dgv_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());

            Process.Start(Get_Path_Of_Drawing_File()[curRow]);

        }

        private void chb_Drawing_CheckedChanged(object sender, EventArgs e)
        {
            btn_Search_Click(sender, e);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //dataGridView1.Columns.Clear();
            Connect_ACCESS();
        }
        //LAST RECORD
        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        //FIRST RECORD
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = 0;

        }
        //Browse Folder
        //
        private void button4_Click(object sender, EventArgs e)
        {
            string folderpath = "";

            FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            
            fbd.ShowNewFolderButton = true;
            fbd.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;

            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                folderpath = fbd.SelectedPath;
            }

            if (folderpath != "")
            {
                txtBoxPath.Text = folderpath;
            }

        }
        //COPY ALL
        private void btnCopyAll_Click(object sender, EventArgs e)
        {
             string destinationDirectory = txtBoxPath.Text + "\\";

             if (destinationDirectory == "\\")
                 MessageBox.Show("Destination Directory Not Exist !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else
             {
                 for (curRow = 0; curRow < dataGridView1.RowCount - 1; curRow++)
                 {
                     if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
                         path_image = pathImage[0];

                     else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[2])
                         path_image = pathImage[2];

                     else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[1])
                         path_image = pathImage[1];

                     else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[3])
                         path_image = pathImage[3];

                     else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[4])
                         path_image = pathImage[4];

                     else if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[5])
                         path_image = pathImage[5];

                     try
                     {
                         fileToCopy = Get_Path_Of_Image(path_image);
                     }
                     catch
                     {
                         try
                         {
                             if (cb_Type_Drawing.SelectedItem.ToString() == type_Drawing[0])
                                 path_image = pathImage[6];
                             else
                                 path_image = pathImage[7];

                             fileToCopy = Get_Path_Of_Image(path_image);
                         }
                         catch
                         {
                             //MessageBox.Show("Image File Not Exist !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             continue;
                         }
                     }
                     try
                     {
                         File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));
                     }
                     catch
                     {
                         continue;
                     }
                 }
             }

        }

    }
}
