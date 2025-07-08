using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using LibInfo;

namespace CourseworkDB
{
    public static class CustomMessageBox
    {
        // Настройки по умолчанию
        public static Color BackColor { get; set; } = HexToColor( LibInfo.ThemeColors.color1);
        public static Color TextColor { get; set; } = HexToColor(LibInfo.ThemeColors.color2);
        public static Color ButtonBackColor { get; set; } = HexToColor(LibInfo.ThemeColors.color3);
        public static Color ButtonTextColor { get; set; } = HexToColor(LibInfo.ThemeColors.color2);
        public static Font TextFont { get; set; } = SystemFonts.MessageBoxFont;
        public static Font ButtonFont { get; set; } = SystemFonts.MessageBoxFont;
        public static int MaxWidth { get; set; } = 600; // Максимальная ширина окна
        public static int MinWidth { get; set; } = 200; // Минимальная ширина окна
        public static int Padding { get; set; } = 40;    // Отступы от краев
        public static int IconPadding { get; set; } = 20; // Отступ для иконки


        public static DialogResult Show(string text)
        {
            return Show(text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(string text, string caption)
        {
            return Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(text, caption, buttons, MessageBoxIcon.None);
        }

        public static DialogResult Show(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            Form form = new Form();
            Label label = new Label();
            Button[] buttonArray = new Button[3];
            PictureBox iconPictureBox = new PictureBox();

            // Настройка текста
            label.Text = text;
            label.Font = TextFont;
            label.ForeColor = TextColor;
            label.AutoSize = true;
            label.MaximumSize = new Size(MaxWidth - Padding - 72, 0);

            // Расчет размера текста
            Size textSize = TextRenderer.MeasureText(text, TextFont, label.MaximumSize);

            // Настройка иконки (увеличиваем размер и добавляем отступы)
            if (icon != MessageBoxIcon.None)
            {
                iconPictureBox.SizeMode = PictureBoxSizeMode.AutoSize; // Автоматический размер под изображение
                iconPictureBox.Location = new Point(IconPadding, IconPadding * 2);

                switch (icon)
                {
                    case MessageBoxIcon.Error:
                        iconPictureBox.Image = SystemIcons.Error.ToBitmap();
                        break;
                    case MessageBoxIcon.Information:
                        iconPictureBox.Image = SystemIcons.Information.ToBitmap();
                        break;
                    case MessageBoxIcon.Question:
                        iconPictureBox.Image = SystemIcons.Question.ToBitmap();
                        break;
                    case MessageBoxIcon.Warning:
                        iconPictureBox.Image = SystemIcons.Warning.ToBitmap();
                        break;
                }
            }

            // Расчет ширины формы с учетом иконки
            int iconWidth = iconPictureBox.Image != null ? iconPictureBox.Width + IconPadding * 2 : 0;
            int textWidth = textSize.Width + Padding;
            int formWidth = Math.Max(MinWidth, Math.Min(MaxWidth, textWidth + iconWidth));

            // Расчет высоты формы
            int textHeight = textSize.Height;
            int iconHeight = iconPictureBox.Image != null ? iconPictureBox.Height + IconPadding * 2 : 0;
            int contentHeight = Math.Max(textHeight, iconHeight);
            int formHeight = Math.Max(100, contentHeight + 80); // 80 - место для кнопок и отступов

            // Настройка формы
            form.BackColor = BackColor;
            form.Text = caption;
            form.ClientSize = new Size(formWidth, formHeight);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            // Позиционирование текста
            int textLeft = iconPictureBox.Image != null ? iconWidth + IconPadding: Padding;
            label.Location = new Point(textLeft, IconPadding + (iconHeight - textHeight) / 2);

            // Настройка кнопок
            int buttonWidth = 75;
            int buttonHeight = 23;
            int buttonTop = formHeight - buttonHeight - IconPadding;
            int buttonLeft = formWidth - (buttonWidth + 10) * GetButtonCount(buttons) - 10;

            SetupButtons(buttons, buttonArray, buttonLeft, buttonTop, buttonWidth, buttonHeight);

            // Добавление элементов на форму
            if (iconPictureBox.Image != null)
                form.Controls.Add(iconPictureBox);

            form.Controls.Add(label);

            for (int i = 0; i < buttonArray.Length; i++)
            {
                if (buttonArray[i] != null)
                {
                    form.Controls.Add(buttonArray[i]);
                    if (i == 0) form.AcceptButton = buttonArray[i];
                }
            }

            return form.ShowDialog();
        }

        private static int GetButtonCount(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    return 1;
                case MessageBoxButtons.OKCancel:
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.RetryCancel:
                    return 2;
                case MessageBoxButtons.AbortRetryIgnore:
                case MessageBoxButtons.YesNoCancel:
                    return 3;
                default:
                    return 1;
            }
        }

        private static void SetupButtons(MessageBoxButtons buttons, Button[] buttonArray, int left, int top, int width, int height)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    buttonArray[0] = CreateButton("OK", DialogResult.OK, left, top, width, height);
                    break;
                case MessageBoxButtons.OKCancel:
                    buttonArray[0] = CreateButton("OK", DialogResult.OK, left, top, width, height);
                    buttonArray[1] = CreateButton("Cancel", DialogResult.Cancel, left + width + 10, top, width, height);
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    buttonArray[0] = CreateButton("Abort", DialogResult.Abort, left, top, width, height);
                    buttonArray[1] = CreateButton("Retry", DialogResult.Retry, left + width + 10, top, width, height);
                    buttonArray[2] = CreateButton("Ignore", DialogResult.Ignore, left + (width + 10) * 2, top, width, height);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    buttonArray[0] = CreateButton("Yes", DialogResult.Yes, left, top, width, height);
                    buttonArray[1] = CreateButton("No", DialogResult.No, left + width + 10, top, width, height);
                    buttonArray[2] = CreateButton("Cancel", DialogResult.Cancel, left + (width + 10) * 2, top, width, height);
                    break;
                case MessageBoxButtons.YesNo:
                    buttonArray[0] = CreateButton("Yes", DialogResult.Yes, left, top, width, height);
                    buttonArray[1] = CreateButton("No", DialogResult.No, left + width + 10, top, width, height);
                    break;
                case MessageBoxButtons.RetryCancel:
                    buttonArray[0] = CreateButton("Retry", DialogResult.Retry, left, top, width, height);
                    buttonArray[1] = CreateButton("Cancel", DialogResult.Cancel, left + width + 10, top, width, height);
                    break;
            }
        }

        private static Button CreateButton(string text, DialogResult result, int left, int top, int width, int height)
        {
            Button button = new Button();
            button.Text = text;
            button.DialogResult = result;
            button.BackColor = ButtonBackColor;
            button.ForeColor = ButtonTextColor;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Standard;
            button.Size = new Size(width, height);
            button.Location = new Point(left, top);
            return button;
        }

        private static Color HexToColor(string hexColor)
        {
            // Удаляем # если есть
            hexColor = hexColor.Replace("#", string.Empty);

            // В зависимости от длины строки обрабатываем по-разному
            if (hexColor.Length == 6)
            {
                // RRGGBB
                return Color.FromArgb(
                    int.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
            }
            else if (hexColor.Length == 8)
            {
                // AARRGGBB
                return Color.FromArgb(
                    int.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor.Substring(6, 2), System.Globalization.NumberStyles.HexNumber));
            }
            else if (hexColor.Length == 3)
            {
                // RGB -> расширяем до RRGGBB
                return Color.FromArgb(
                    int.Parse(hexColor[0].ToString() + hexColor[0].ToString(), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor[1].ToString() + hexColor[1].ToString(), System.Globalization.NumberStyles.HexNumber),
                    int.Parse(hexColor[2].ToString() + hexColor[2].ToString(), System.Globalization.NumberStyles.HexNumber));
            }

            throw new ArgumentException("Неверный формат HEX цвета. Используйте #RRGGBB, #AARRGGBB или #RGB");
        }
        public static string BackColorHex
        {
            set => BackColor = HexToColor(value);
        }

        public static string TextColorHex
        {
            set => TextColor = HexToColor(value);
        }

        public static string ButtonBackColorHex
        {
            set => ButtonBackColor = HexToColor(value);
        }

        public static string ButtonTextColorHex
        {
            set => ButtonTextColor = HexToColor(value);
        }
    }
}
