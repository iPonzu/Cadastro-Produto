using Models;
using Controllers;

namespace Views
{
    public class Produto : Form {
        ListView list;
        public static void store() {

        }
        public void RefreshList() {
            list.Items.Clear();
            foreach (Models.Produto p in Controllers.Produto.index()) {
                ListViewItem item = new ListViewItem(p.Nome);
                item.SubItems.Add(p.Preco.ToString());
                list.Items.Add(item);
            }
        }
        public Produto(){
            this.Text = "Produto";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            list = new ListView();
            list.Size = new Size(400, 250);
            list.Location = new Point(50, 50);
            list.View = View.Details;
            list.Columns.Add("Nome");
            list.Columns.Add("Preço");

            this.RefreshList();

            Button btnAdd = new Button();
            btnAdd.Text = "Confirmar";
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(50, 300);
            btnAdd.Click += (sender, e) => {
                new CadastrarProduto();
                this.RefreshList(); 
                this.Show();
                Produto.store();
            };

            Button btnExcluir = new Button();
            btnExcluir.Text = "Excluir";
            btnExcluir.Size = new Size(100, 30);
            btnExcluir.Location = new Point(170, 300);
            btnExcluir.Click += (sender, e) => {
                ExcluirProduto.index();
                this.Show();
            };

            Button btnVoltar = new Button();
            btnVoltar.Text = "Sair";
            btnVoltar.Size = new Size(100, 30);
            btnVoltar.Location = new Point(350, 300);
            btnVoltar.Click += (sender, e) => {
                this.Close();
            };

            this.Controls.Add(list);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
            this.ShowDialog();
        }
    }
}
