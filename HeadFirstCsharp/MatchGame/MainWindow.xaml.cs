using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.Generic;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;

        List<int> highScores = new List<int>();
        
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed--;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            
            if (matchesFound == 8)
            {
                timer.Stop();

                UpdateHighScores(tenthsOfSecondsElapsed);

                timeTextBlock.Text = timeTextBlock.Text + " - Win! Play again?";
            }
            else if (tenthsOfSecondsElapsed <= 0)
            {
                timer.Stop();
                timeTextBlock.Text = "0.0s - Timed Out! Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = GetAnimalEmojiList();

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }

            timer.Start();
            tenthsOfSecondsElapsed = 200;
            matchesFound = 0;
        }

        private static List<string> GetAnimalEmojiList()
        {
            List<string> animalEmojiPair = new List<string>();

            List<string> animalEmoji = new List<string>()
        {
            "🐙", "🐡", "🐘", "🐳", "🐪", "🦕", "🦘", "🦔", "🦇", "🦉", "🦒", "🐅", "🦏", "🦓", "🦧", "🐩"
        };

            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                string nextEmoji;

                do
                {
                    int index = random.Next(animalEmoji.Count);
                    nextEmoji = animalEmoji[index];
                } while (animalEmojiPair.Contains(nextEmoji));

                animalEmojiPair.Add(nextEmoji);
                animalEmojiPair.Add(nextEmoji);
            }

            return animalEmojiPair;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tenthsOfSecondsElapsed <= 0) return;

            TextBlock textBlock = sender as TextBlock;

            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8 || tenthsOfSecondsElapsed <= 0)
            {
                SetUpGame();
            }
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            SetUpGame();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            StartScreen.Visibility = Visibility.Collapsed;
            RecordsScreen.Visibility = Visibility.Collapsed;
            GameScreen.Visibility = Visibility.Visible;
            SetUpGame();
        }
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            GameScreen.Visibility = Visibility.Collapsed;
            RecordsScreen.Visibility = Visibility.Collapsed;
            StartScreen.Visibility = Visibility.Visible;
        }

        private void UpdateHighScores(int finalScore)
        {
            highScores.Add(finalScore);

            highScores.Sort();
            highScores.Reverse();

            if (highScores.Count > 3)
            {
                highScores.RemoveRange(3, highScores.Count - 3);
            }

            UpdateRecordsUI();
        }

        private void UpdateRecordsUI()
        {
            if (FirstPlaceTxt == null)
            {
                return;
            }
            
            if (highScores.Count >= 1)
            {
                FirstPlaceTxt.Text = "1º - " + (highScores[0] / 10F).ToString("0.0s");
            }

            if (highScores.Count >= 2)
            {
                SecondPlaceTxt.Text = "2º - " + (highScores[1] / 10F).ToString("0.0s");
            }

            if (highScores.Count >= 3)
            {
                ThirdPlaceTxt.Text = "3º - " + (highScores[2] / 10F).ToString("0.0s");
            }
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateRecordsUI();

            StartScreen.Visibility = Visibility.Collapsed;
            GameScreen.Visibility = Visibility.Collapsed;
            RecordsScreen.Visibility = Visibility.Visible;
        }
    }
}