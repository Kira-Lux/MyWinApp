using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ThunghiemNeon
{
    public partial class Form1 : Form
    {
        private readonly string _connString;
        public Form1()
        {
            InitializeComponent();
            _connString = Program.AppConfig.GetConnectionString("Main") ?? throw new InvalidOperationException("Missing ConnectionStrings:Main");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using var db = new Npgsql.NpgsqlConnection(_connString);
            db.Open();

            MessageBox.Show("Kết nối Neon thành công");

            using var cmd = new NpgsqlCommand("CREATE SEQUENCE IF NOT EXISTS neon_auth.test_seq START 1", db);
            cmd.ExecuteNonQuery();
        }
    }
}
