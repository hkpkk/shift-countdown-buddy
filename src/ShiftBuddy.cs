using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ShiftCountdownBuddy
{
    public class CatCouplePanel : Panel
    {
        public bool HeartUp { get; set; }

        public CatCouplePanel()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(92, 66);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (Brush shadow = new SolidBrush(Color.FromArgb(120, 245, 208, 222)))
            {
                g.FillEllipse(shadow, 10, 56, 72, 7);
            }

            using (Pen orangeTail = new Pen(Color.FromArgb(235, 134, 52), 5.5f))
            using (Pen blackTail = new Pen(Color.FromArgb(35, 32, 42), 3.8f))
            {
                orangeTail.StartCap = LineCap.Round;
                orangeTail.EndCap = LineCap.Round;
                blackTail.StartCap = LineCap.Round;
                blackTail.EndCap = LineCap.Round;
                g.DrawBezier(orangeTail, new Point(16, 52), new Point(3, 46), new Point(3, 31), new Point(13, 28));
                g.DrawBezier(blackTail, new Point(68, 54), new Point(84, 48), new Point(86, 30), new Point(74, 25));
            }

            // 1. MATURE COMPOSED BLACK CAT
            using (Brush blackTorso = new SolidBrush(Color.FromArgb(35, 32, 42)))
            using (Brush blackHead = new SolidBrush(Color.FromArgb(42, 39, 50)))
            using (Brush innerEar = new SolidBrush(Color.FromArgb(74, 53, 64)))
            using (Brush goldEye = new SolidBrush(Color.FromArgb(245, 197, 66)))
            using (Brush pupil = new SolidBrush(Color.FromArgb(24, 21, 28)))
            using (Pen lidPen = new Pen(Color.FromArgb(22, 19, 26), 1.8f))
            using (Pen smirkPen = new Pen(Color.FromArgb(143, 134, 158), 1.3f))
            {
                g.FillEllipse(blackTorso, 44, 28, 27, 32);
                Point[] earL = { new Point(44, 20), new Point(46, 5), new Point(55, 15) };
                Point[] earR = { new Point(59, 15), new Point(69, 4), new Point(69, 20) };
                g.FillPolygon(blackTorso, earL);
                g.FillPolygon(blackTorso, earR);
                Point[] inL = { new Point(46, 18), new Point(47, 8), new Point(53, 15) };
                Point[] inR = { new Point(61, 15), new Point(67, 8), new Point(67, 18) };
                g.FillPolygon(innerEar, inL);
                g.FillPolygon(innerEar, inR);

                g.FillEllipse(blackHead, 44, 11, 26, 22);

                g.FillEllipse(goldEye, 49, 18, 6, 5);
                g.FillEllipse(goldEye, 59, 18, 6, 5);
                g.FillEllipse(pupil, 50.5f, 18.5f, 2, 4);
                g.FillEllipse(pupil, 60.5f, 18.5f, 2, 4);
                g.FillRectangle(blackHead, 48, 16, 18, 3);
                g.DrawLine(lidPen, 48, 19, 55, 20);
                g.DrawLine(lidPen, 59, 20, 66, 19);

                g.DrawArc(smirkPen, 54, 24, 8, 4, 10, 160);
                g.DrawLine(smirkPen, 61, 26, 63, 24);
            }

            // 2. CHUBBY ORANGE CAT
            using (Brush chonkyBody = new SolidBrush(Color.FromArgb(242, 148, 65)))
            using (Brush creamBelly = new SolidBrush(Color.FromArgb(253, 227, 200)))
            using (Brush chubbyHead = new SolidBrush(Color.FromArgb(247, 162, 84)))
            using (Brush pawWhite = new SolidBrush(Color.FromArgb(255, 245, 235)))
            using (Brush blush = new SolidBrush(Color.FromArgb(160, 240, 98, 146)))
            using (Pen stripePen = new Pen(Color.FromArgb(201, 101, 24), 1.8f))
            using (Pen happyEye = new Pen(Color.FromArgb(66, 36, 18), 1.8f))
            {
                GraphicsState state = g.Save();
                g.TranslateTransform(28, 45);
                g.RotateTransform(-18);
                g.FillEllipse(chonkyBody, -18, -14, 36, 28);
                g.FillEllipse(creamBelly, -8, -8, 20, 17);
                g.Restore(state);

                Point[] earL = { new Point(21, 22), new Point(23, 10), new Point(31, 17) };
                Point[] earR = { new Point(37, 16), new Point(44, 9), new Point(45, 20) };
                g.FillPolygon(chonkyBody, earL);
                g.FillPolygon(chonkyBody, earR);

                g.FillEllipse(chubbyHead, 20, 15, 27, 22);
                g.FillEllipse(chubbyHead, 35, 21, 13, 12);

                g.DrawLine(stripePen, 31, 16, 33, 20);
                g.DrawLine(stripePen, 36, 16, 34, 20);

                g.FillEllipse(pawWhite, 44, 31, 10, 7);
                g.FillEllipse(pawWhite, 40, 38, 10, 7);
                g.FillEllipse(blush, 49, 33, 3, 3);
                g.FillEllipse(blush, 45, 40, 3, 3);

                g.DrawArc(happyEye, 26, 23, 6, 5, 180, 180);
                g.DrawArc(happyEye, 36, 22, 6, 5, 180, 180);
                g.FillEllipse(blush, 23, 27, 5, 3);
                g.FillEllipse(blush, 40, 26, 5, 3);
            }

            using (Font heartFont = new Font("Georgia", 9.5f, FontStyle.Bold))
            using (Brush heartBrush = new SolidBrush(Color.FromArgb(224, 83, 124)))
            {
                int hy = HeartUp ? 0 : 3;
                g.DrawString("♥", heartFont, heartBrush, new PointF(40, hy));
            }
        }
    }

    public class MainForm : Form
    {
        private Timer tickTimer;
        private string serifFamily;
        private Label lblClock;
        private Label lblLunchTitle;
        private Label lblLunchTimer;
        private Label lblHomeTitle;
        private Label lblHomeTimer;
        private Panel progressBg;
        private Panel progressFill;
        private Label lblProgressPct;
        private CatCouplePanel catCanvas;
        private Label lblCoupleHeader;
        private Label lblCatSpeech;
        private CheckBox chkTopMost;
        private Button btnCompact;
        private bool isCompact = false;
        private int fullHeight = 238;
        private int compactHeight = 76;
        private int petCount = 0;

        private readonly string[] coupleQuotes = new string[]
        {
            "Mèo Đen: “Nặng quá đấy cục bông cam kia... nhưng thôi, cứ tựa vào đi.”",
            "Mèo Cam: “Ngồi thẳng lưng lên nào, thả lỏng hai vai cho đỡ mỏi nhé!”",
            "Mèo Đen: “Nhấp một ngụm nước ấm đi, giữ cho tâm trí luôn thư thái.”",
            "Mèo Cam: “Chiều trôi êm ả lắm, từng khắc đồng hồ đang nhẹ nhàng qua.”",
            "Mèo Đen: “Mỏi mắt rồi kìa, phóng tầm mắt ra xa mười giây nghỉ ngơi chút đi.”",
            "Mèo Cam: “Hít vào một hơi thật sâu, thở ra thật nhẹ, mọi việc đều ổn thỏa.”",
            "Mèo Đen: “Đừng quên ăn uống điều độ, hai đứa vẫn ngồi canh giờ cho bạn đây.”"
        };

        public MainForm()
        {
            serifFamily = PickClassicSerifFont();
            this.Text = "🐈‍⬛🐈 17:00";
            this.Size = new Size(325, fullHeight);
            this.MinimumSize = new Size(300, compactHeight);
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(workingArea.Width - this.Width - 20, workingArea.Height - this.Height - 20);

            this.BackColor = Color.FromArgb(255, 245, 248);
            this.ForeColor = Color.FromArgb(74, 37, 51);
            this.Font = new Font(serifFamily, 10f, FontStyle.Regular);
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            BuildUI();

            tickTimer = new Timer();
            tickTimer.Interval = 1000;
            tickTimer.Tick += (s, e) => UpdateTimers();
            tickTimer.Start();

            UpdateTimers();
        }

        private string PickClassicSerifFont()
        {
            string[] preferred = { "Baskerville Old Face", "Garamond", "Palatino Linotype", "Georgia", "Times New Roman" };
            foreach (string name in preferred)
            {
                using (Font test = new Font(name, 10f, FontStyle.Regular))
                {
                    if (string.Equals(test.Name, name, StringComparison.OrdinalIgnoreCase))
                        return name;
                }
            }
            return "Georgia";
        }

        private void BuildUI()
        {
            Color roseDeep = Color.FromArgb(184, 74, 110);
            Color roseBorder = Color.FromArgb(229, 152, 178);
            Color berryText = Color.FromArgb(74, 37, 51);
            Color mutedRose = Color.FromArgb(140, 90, 109);
            Color cardWhite = Color.FromArgb(255, 255, 255);

            lblClock = new Label
            {
                Location = new Point(10, 8),
                Size = new Size(120, 20),
                Font = new Font("Garamond", 11f, FontStyle.Italic | FontStyle.Bold),
                ForeColor = roseDeep,
                Text = "00:00:00"
            };
            this.Controls.Add(lblClock);

            chkTopMost = new CheckBox
            {
                Text = "📌",
                Checked = true,
                Location = new Point(226, 8),
                Size = new Size(42, 22),
                ForeColor = roseDeep,
                Font = new Font("Segoe UI Emoji", 8.5f, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            chkTopMost.CheckedChanged += (s, e) => { this.TopMost = chkTopMost.Checked; };
            this.Controls.Add(chkTopMost);

            btnCompact = new Button
            {
                Text = "▴",
                Location = new Point(270, 6),
                Size = new Size(28, 22),
                FlatStyle = FlatStyle.Flat,
                BackColor = cardWhite,
                ForeColor = roseDeep,
                Font = new Font("Garamond", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCompact.FlatAppearance.BorderColor = roseBorder;
            btnCompact.Click += ToggleCompact;
            this.Controls.Add(btnCompact);

            // Minimalist Main Card: Row 1 [17:00 ... 63.9%], Row 2 [03:13:45]
            Panel homePanel = new Panel
            {
                Location = new Point(10, 32),
                Size = new Size(288, 52),
                BackColor = cardWhite,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(homePanel);

            lblHomeTitle = new Label
            {
                Location = new Point(10, 5),
                Size = new Size(80, 16),
                Font = new Font("Garamond", 10f, FontStyle.Italic | FontStyle.Bold),
                ForeColor = roseDeep,
                Text = "17:00"
            };
            homePanel.Controls.Add(lblHomeTitle);

            lblProgressPct = new Label
            {
                Location = new Point(195, 5),
                Size = new Size(82, 16),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Garamond", 10f, FontStyle.Italic | FontStyle.Bold),
                ForeColor = Color.FromArgb(201, 91, 130),
                Text = "0.0%"
            };
            homePanel.Controls.Add(lblProgressPct);

            lblHomeTimer = new Label
            {
                Location = new Point(10, 21),
                Size = new Size(268, 26),
                Font = new Font(serifFamily, 16f, FontStyle.Bold),
                ForeColor = berryText,
                Text = "00:00:00"
            };
            homePanel.Controls.Add(lblHomeTimer);

            // Progress Bar
            progressBg = new Panel
            {
                Location = new Point(10, 89),
                Size = new Size(288, 5),
                BackColor = Color.FromArgb(248, 220, 230)
            };
            this.Controls.Add(progressBg);

            progressFill = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(0, 5),
                BackColor = Color.FromArgb(217, 107, 144)
            };
            progressBg.Controls.Add(progressFill);

            // Minimalist Lunch Row: [12:00]                   [00:00:00]
            Panel lunchPanel = new Panel
            {
                Location = new Point(10, 99),
                Size = new Size(288, 26),
                BackColor = Color.FromArgb(252, 238, 243),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lunchPanel);

            lblLunchTitle = new Label
            {
                Location = new Point(8, 4),
                Size = new Size(60, 18),
                Font = new Font("Garamond", 10f, FontStyle.Italic),
                ForeColor = mutedRose,
                Text = "12:00"
            };
            lunchPanel.Controls.Add(lblLunchTitle);

            lblLunchTimer = new Label
            {
                Location = new Point(130, 4),
                Size = new Size(148, 18),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font(serifFamily, 10f, FontStyle.Bold),
                ForeColor = roseDeep,
                Text = "00:00:00"
            };
            lunchPanel.Controls.Add(lblLunchTimer);

            // Couple Mèo Cam & Mèo Đen Box
            Panel catPanel = new Panel
            {
                Location = new Point(10, 131),
                Size = new Size(288, 74),
                BackColor = cardWhite,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };
            this.Controls.Add(catPanel);

            catCanvas = new CatCouplePanel
            {
                Location = new Point(2, 4),
                Cursor = Cursors.Hand
            };
            catPanel.Controls.Add(catCanvas);

            lblCoupleHeader = new Label
            {
                Location = new Point(96, 5),
                Size = new Size(184, 16),
                Font = new Font("Garamond", 8.5f, FontStyle.Bold),
                ForeColor = roseDeep,
                Text = "🐈 & 🐈‍⬛   ✦",
                Cursor = Cursors.Hand
            };
            catPanel.Controls.Add(lblCoupleHeader);

            lblCatSpeech = new Label
            {
                Location = new Point(96, 21),
                Size = new Size(184, 48),
                Font = new Font("Garamond", 9.5f, FontStyle.Italic),
                ForeColor = berryText,
                Text = "“Chạm nhẹ xoa đầu hai đứa...”",
                Cursor = Cursors.Hand
            };
            catPanel.Controls.Add(lblCatSpeech);

            EventHandler petHandler = (s, e) => PetTheCouple();
            catPanel.Click += petHandler;
            catCanvas.Click += petHandler;
            lblCoupleHeader.Click += petHandler;
            lblCatSpeech.Click += petHandler;
        }

        private void PetTheCouple()
        {
            petCount++;
            lblCoupleHeader.Text = string.Format("🐈 & 🐈‍⬛   ♥ ×{0}", petCount);
            lblCatSpeech.Text = coupleQuotes[petCount % coupleQuotes.Length];
            catCanvas.HeartUp = (petCount % 2 == 1);
            catCanvas.Invalidate();
        }

        private void ToggleCompact(object sender, EventArgs e)
        {
            isCompact = !isCompact;
            if (isCompact)
            {
                this.Height = compactHeight + 36;
                btnCompact.Text = "▾";
            }
            else
            {
                this.Height = fullHeight;
                btnCompact.Text = "▴";
            }
        }

        private void UpdateTimers()
        {
            DateTime now = DateTime.Now;
            lblClock.Text = now.ToString("HH:mm:ss");

            DateTime shiftStart = now.Date.AddHours(8);
            DateTime lunchStart = now.Date.AddHours(12);
            DateTime lunchEnd = now.Date.AddHours(13);
            DateTime shiftEnd = now.Date.AddHours(17);

            if (now < lunchStart)
            {
                TimeSpan toLunch = lunchStart - now;
                lblLunchTimer.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)toLunch.TotalHours, toLunch.Minutes, toLunch.Seconds);
                lblLunchTimer.ForeColor = Color.FromArgb(184, 74, 110);
            }
            else if (now >= lunchStart && now < lunchEnd)
            {
                TimeSpan leftLunch = lunchEnd - now;
                lblLunchTimer.Text = string.Format("00:{0:D2}:{1:D2}", leftLunch.Minutes, leftLunch.Seconds);
                lblLunchTimer.ForeColor = Color.FromArgb(217, 107, 144);
            }
            else
            {
                lblLunchTimer.Text = "00:00:00";
                lblLunchTimer.ForeColor = Color.FromArgb(140, 90, 109);
            }

            if (now < shiftEnd)
            {
                TimeSpan toHome = shiftEnd - now;
                lblHomeTimer.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)toHome.TotalHours, toHome.Minutes, toHome.Seconds);

                double totalWorkSeconds = (shiftEnd - shiftStart).TotalSeconds;
                double elapsedSeconds = Math.Max(0, (now - shiftStart).TotalSeconds);
                double pct = Math.Min(100.0, (elapsedSeconds / totalWorkSeconds) * 100.0);
                lblProgressPct.Text = string.Format("{0:0.0}%", pct);
                progressFill.Width = (int)Math.Round((pct / 100.0) * progressBg.Width);
            }
            else
            {
                lblHomeTimer.Text = "00:00:00";
                lblProgressPct.Text = "100%";
                progressFill.Width = progressBg.Width;
            }

            catCanvas.HeartUp = (now.Second % 2 == 0);
            catCanvas.Invalidate();

            if (petCount == 0 || now.Second % 20 == 0)
            {
                if (now.Hour == 11 && now.Minute >= 45)
                {
                    lblCatSpeech.Text = "“Sắp tới giờ nghỉ trưa rồi, chuẩn bị thưởng thức bữa trưa ngon miệng nhé.”";
                }
                else if (now.Hour == 15 && now.Minute >= 20 && now.Minute <= 50)
                {
                    lblCatSpeech.Text = "“Giờ trà chiều điểm rồi — dùng chút đồ uống ấm hoặc bữa phụ nhẹ nhàng nhé!”";
                }
                else if (now.Hour == 16 && now.Minute >= 45)
                {
                    lblCatSpeech.Text = "“Chỉ còn chưa đầy mười lăm phút nữa, thong thả thu xếp đồ đạc chuẩn bị về thôi!”";
                }
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
