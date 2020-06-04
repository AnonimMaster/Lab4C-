using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labaratornay4VladimirovKV
{
	public partial class Form1 : Form
	{
		Bitmap bmp;
		public Form1()
		{
			InitializeComponent();
			bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Graphics graph = Graphics.FromImage(bmp);	//Создаем интерфейс Graphics для работы с изображениями
			int W = pictureBox1.ClientSize.Width;
			int H = pictureBox1.ClientSize.Height;

			Rectangle SquartOne = new Rectangle(0, 0, W , H);	//Создаём форму большого прямоугольника, который заполняет всё полотно.
			Brush BrushSquart = DrafManager.RandomColorBrush();	//Создаём кисть с случайным цветом.

			graph.FillRectangle(BrushSquart, SquartOne);	//Заполняем форму кистью

			int PaddingSquartTwoW = (W / 10);
			int PaddingSquartTwoH = (H / 10);
			Rectangle SquartTwo = new Rectangle(PaddingSquartTwoW, PaddingSquartTwoH, W-2*PaddingSquartTwoW,H - 2*PaddingSquartTwoH) ;	//Создаём форму с отступами слева сверху и снизу права.
			Brush BrushSquartTwo = DrafManager.RandomColorBrush();

			graph.FillRectangle(BrushSquartTwo, SquartTwo);

			Rectangle ElipseBG = new Rectangle(PaddingSquartTwoW + W / 10, PaddingSquartTwoH + H / 10, W - 2 * (PaddingSquartTwoW + W / 10), H - 2 * (PaddingSquartTwoH + H / 10));

			graph.FillEllipse(DrafManager.RandomColorBrush(), ElipseBG);


			int R, G, B, SizePenElipse;

			R = CorrectInputRGB(TextBoxR);	//Проверяем на ввод
			G = CorrectInputRGB(TextBoxG);	//Проверяем на ввод
			B = CorrectInputRGB(TextBoxB);	//Проверяем на ввод
			SizePenElipse = CorrectInput(TextBoxSizeLine);	//Проверяем на ввод
			Pen PenElipseLine = new Pen(Color.Gray, SizePenElipse);
			Brush BrushElepse = new SolidBrush(Color.FromArgb(R, G, B));	//Создаём кисть с параметрами указаными пользователем

			Rectangle Elipse = new Rectangle(PaddingSquartTwoW + W / 8, PaddingSquartTwoH + H / 4, W - 2 * (PaddingSquartTwoW + W / 8), H - 2 * (PaddingSquartTwoH + H / 4));		//Создаём форму с отступами

			graph.DrawEllipse(PenElipseLine, Elipse);	//отрисовываем обвотку вокруг малого эллипса
			graph.FillEllipse(BrushElepse, Elipse);	//Заливаем форму эллипса

			pictureBox1.Image = bmp;	//Выгружаем картинку в PictureBox
		}

		static int CorrectInputRGB(TextBox TextBox)
		{

			if (TextBox.Text != "")	//Проверяем не пустое ли поле
			{
				

				if (IsNum(TextBox.Text))	//Проверяем текст содержит цифры или нет
				{
					int Value;
					Value = Convert.ToInt32(TextBox.Text);

					if (Value < 0) Value = 0;	//Отсекаем отрицательные цифры
					if(Value > 255) Value = 255;
					TextBox.Text = String.Format("{0}", Value);	//Отображаем изменения

					return Value;
				}
				else
				{
					TextBox.Text = "Введите целочисленную цифру";
				}
			}

			return 0;
		}

		static int CorrectInput(TextBox TextBox)
		{

			if (TextBox.Text != "")
			{


				if (IsNum(TextBox.Text))
				{
					int Value;
					Value = Convert.ToInt32(TextBox.Text);

					if (Value < 0) Value = 0;
					TextBox.Text = String.Format("{0}", Value);

					return Value;
				}
				else
				{
					TextBox.Text = "Введите целочисленную цифру";
				}
			}

			return 0;
		}

		static bool IsNum(string s)	//Проверяем строчку состоит она из цифр или других символов
		{
			foreach (char c in s)
			{
				if (!Char.IsDigit(c)) return false;
			}
			return true;
		}
	}
}
