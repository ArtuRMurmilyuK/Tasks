using System.Windows;

namespace EventExampleWpf
{
    public class Presenter
    {
        private Model model;
        private MainWindow mainWindow;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.model = new Model();
            this.mainWindow.SomeEvent += MainWindow_SomeEvent;
        }

        private void MainWindow_SomeEvent(object? sender, System.EventArgs e)
        {
            this.mainWindow.TextBox1.Text = this.model.Сoncatenation(this.mainWindow.TextBox1.Text);
        }
    }
}