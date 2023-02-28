using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        DataSet ds;
        public MainWindow()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect1"].ConnectionString);
            ds = new DataSet();
            ComboBox1.SelectedIndex = 0;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            tabs.Items.RemoveAt(tabs.SelectedIndex);
        }

        private void Table_Selected(object sender, RoutedEventArgs e)
        {
            SqlCommand s = new SqlCommand();
            TreeViewItem t = (TreeViewItem)sender;
            t.Items.Clear();
            if (t.Header.ToString() == "Таблиці")
            {
                s.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where Not(TABLE_NAME like 'sysdiagrams')";
                s.Connection = con;
            }
            if (t.Header.ToString() == "Процедури")
            {
                s.CommandText = "SELECT name FROM sys.objects o WHERE o.[Type] = 'P' and not(name like 'sp%')";
                s.Connection = con;
            }
            con.Open();
            SqlDataReader R = s.ExecuteReader();
            if ((R.HasRows) & (t.Header.ToString() == "Таблиці"))
            {
                while (R.Read())
                {
                    TreeViewItem ts = new TreeViewItem();
                    ts.Header = R[0].ToString();
                    ts.Selected += Table_Selected1;
                    t.Items.Add(ts);
                }
            }
            if ((R.HasRows) & (t.Header.ToString() == "Процедури"))
            {
                while (R.Read())
                {
                    TreeViewItem ts = new TreeViewItem();
                    ts.Header = R[0].ToString();
                    ts.Selected += Proc_Selected;
                    t.Items.Add(ts);
                }
            }
            con.Close();
        }

        private void Table_Selected1(object sender, RoutedEventArgs e)
        {
            TreeViewItem t = (TreeViewItem)sender;
            SqlCommand s = new SqlCommand("SELECT * from " + t.Header.ToString(), con);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter(s);
            DA.Fill(ds, t.Header.ToString());
            DataGrid d = new DataGrid();
            d.AutoGenerateColumns = true;
            d.ItemsSource = ds.Tables[t.Header.ToString()].DefaultView;
            ContextMenu c = new ContextMenu();
            MenuItem m = new MenuItem();
            m.Header = "Закрити";
            m.Click += MenuItem_Click;
            c.Items.Add(m);
            tabs.Items.Add(
            new TabItem
            {
                Header = t.Header.ToString(),
                Content = d,
                ContextMenu = c
            });
            con.Close();
            Status.Text = "Завантажено таблицю " + t.Header.ToString();
        }

        private void Proc_Selected(object sender, RoutedEventArgs e)
        {

            TreeViewItem t = (TreeViewItem)sender;
            string proc = t.Header.ToString();

            SqlCommand s = new SqlCommand();
            s.CommandType = CommandType.StoredProcedure;
            s.CommandText = proc;
            s.Connection = con;

            switch (proc)
            {
                case "proc_view_user":
                case "proc_delete_user":
                case "proc_view_articles":
                    {
                        s.Parameters.Add("@id", SqlDbType.Int, 20);
                        s.Parameters["@id"].Value = Convert.ToInt32(VarField1.Text);
                        break;
                    }
                case "proc_view_languages":
                    {
                        s.Parameters.Add("@lang_code", SqlDbType.VarChar, 20);
                        s.Parameters["@lang_code"].Value = Convert.ToString(VarField1.Text);
                        break;
                    }
                case "proc_add_user":
                    {
                        s.Parameters.Add("@name", SqlDbType.VarChar, 255);
                        s.Parameters.Add("@email", SqlDbType.VarChar, 255);
                        s.Parameters.Add("@password", SqlDbType.VarChar, 255);
                        s.Parameters["@name"].Value = Convert.ToString(VarField1.Text);
                        s.Parameters["@email"].Value = Convert.ToString(VarField2.Text);
                        s.Parameters["@password"].Value = Convert.ToString(VarField3.Text);

                        break;
                    }
                case "proc_add_language":
                    {
                        s.Parameters.Add("@lang_code", SqlDbType.VarChar, 3);
                        s.Parameters.Add("@lang_name", SqlDbType.VarChar, 30);
                        s.Parameters["@lang_code"].Value = Convert.ToString(VarField1.Text);
                        s.Parameters["@lang_name"].Value = Convert.ToString(VarField2.Text);
    
                        break;
                    }
                default:
                    return;
            }

            con.Open();


            SqlDataAdapter DA = new SqlDataAdapter(s);
            DA.Fill(ds, proc);
            DataGrid d = new DataGrid();
            d.AutoGenerateColumns = true;

                var b = ds.Tables[proc];
                if(b != null)
                    d.ItemsSource = b.DefaultView;
                else
                    MessageBox.Show("Запит виконано!", "Успіх", MessageBoxButton.OK);

            ContextMenu c = new ContextMenu();
            MenuItem m = new MenuItem();
            m.Header = "Закрити";
            m.Click += MenuItem_Click;
            c.Items.Add(m);

            tabs.Items.Add(
            new TabItem
            {
                Header = t.Header.ToString(),
                Content = d,
                ContextMenu = c
            });
            con.Close();
            Status.Text = "Завантажено таблицю " + t.Header.ToString();
        }








        private void Window_Closed(object sender, EventArgs e)
        {

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Insert(object sender, RoutedEventArgs e)
        {
            SqlCommand s = new SqlCommand("ins_abs_type", con);
            con.Open();
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(s);
                s.CommandType = CommandType.StoredProcedure;
                s.Parameters.Add("@type", SqlDbType.VarChar, 50);
                s.Parameters["@type"].Value = Convert.ToString(TextBox2.Text);
                DA.InsertCommand = s;
                SqlCommandBuilder comandbuilder = new SqlCommandBuilder(DA);
                DA.TableMappings.Add("Table", "AbsenceType");
                DA.Update(ds);
                DA.Fill(ds);
                DataTable st = ds.Tables["AbsenceType"];
                ds.AcceptChanges();

                MessageBox.Show("Запис додано", "Увага", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Увага", MessageBoxButton.OK);
            }
            finally
            {
                con.Close();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            SqlCommand s = new SqlCommand("del", con);
            con.Open();
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(s);
                s.CommandType = CommandType.StoredProcedure;
                s.Parameters.Add("@id", SqlDbType.Int);
                s.Parameters["@id"].Value = Convert.ToString(TextBox3.Text);
                DA.UpdateCommand = s;
                DA.TableMappings.Add("Table", "AbsenceType");
                DA.Update(ds);
                DA.Fill(ds);
                ds.AcceptChanges();

                MessageBox.Show("Запис видалено", "Увага", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Увага", MessageBoxButton.OK);
            }
            finally
            {
                con.Close();
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            SqlCommand s = new SqlCommand("upd", con);
            con.Open();
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(s);
                s.CommandType = CommandType.StoredProcedure;
                s.Parameters.Add("@id1", SqlDbType.Int);
                s.Parameters["@id1"].Value = Convert.ToString(TextBox4.Text);
                s.Parameters.Add("@type1", SqlDbType.VarChar, 50);
                s.Parameters["@type1"].Value = Convert.ToString(TextBox5.Text);
                DA.UpdateCommand = s;
                DA.TableMappings.Add("Table", "AbsenceType");
                DA.Update(ds);
                DA.Fill(ds);
                ds.AcceptChanges();

                MessageBox.Show("Запис оновлено", "Увага", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Увага", MessageBoxButton.OK);
            }
            finally
            {
                con.Close();
            }
        }

        private void VarField1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
