/*
 * Author: Jozef Vendel , Date:02/2024
 * 
 * Simple game where you try to guess the word and not hang the man.
 * 
 * Simple demonstration of my work in C#. After turning on the game, 
 * you have 11 lives to guess the word that was randomly generated for you. 
 * If you succeed, you can add yourself to the list of players, 
 * if you don't guess, hang the guy and you can repeat the game.
 * 
 */


using System.Windows;
using System.Windows.Input;

namespace theHangedManWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}