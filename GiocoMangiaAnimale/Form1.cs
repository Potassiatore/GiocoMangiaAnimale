
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GiocoMangiaAnimale
{
    public delegate void MorteLeoniHandler();
    public partial class Application : Form
    {
        public event MorteLeoniHandler? MorteLeoni;
        private PictureBox[,] celle = new PictureBox[6, 6];
        private List<CPersonaggio> animaliInVita = new List<CPersonaggio>();
        private ToolTip toolTip = new ToolTip();
        private int turniSenzaMangiare = 0;

        public Application()
        {
            InitializeComponent();
            InizializzaGriglia();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 300;
            toolTip.ShowAlways = true;
        }

        private void InizializzaGriglia()
        {
            MatriceDiGioco.Controls.Clear();

            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 6; c++)
                {
                    var pic = new PictureBox
                    {
                        Name = $"pic_{r}_{c}",
                        Dock = DockStyle.Fill,
                        Margin = new Padding(3),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.LightGray,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new int[] { r, c }
                    };
                    pic.Click += Cella_Click;
                    MatriceDiGioco.Controls.Add(pic, c, r);
                    celle[r, c] = pic;
                }
            }
        }

        private void Cella_Click(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            var pos = (int[])pic.Tag;
            if (pic.Tag is CPersonaggio p)
            {
                MessageBox.Show($"{p.Name}\nTipo: {p.TipoAnimale}\nEnergia: {p.Energy} | Velocità: {p.Speed}",
                                "Informazioni Animale");
            }
            else
            {
                MessageBox.Show($"Cella vuota [{pos[0]},{pos[1]}]");
            }
        }

        private void PulisciGriglia()
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 6; c++)
                {
                    var pic = celle[r, c];
                    pic.BackColor = Color.LightGray;
                    pic.Image = null;
                    pic.Tag = new int[] { r, c };
                    toolTip.SetToolTip(pic, null);
                }
        }

        private void PosizionaPersonaggio(CPersonaggio p, int riga, int col)
        {
            var pic = celle[riga, col];
            pic.BackColor = p.ColoreSfondo;
            pic.Tag = p;
            p.Sposta(riga, col);
            toolTip.SetToolTip(pic, $"{p.Name}\n{p.TipoAnimale}\nEnergia: {p.Energy} | Velocità: {p.Speed}");
        }

        // ====================== START GAME ======================
        private void StartGame_Click(object sender, EventArgs e)
        {
            animaliInVita.Clear();
            animaliInVita.AddRange(new[]
            {
                CFactory.Crea(AnimalType.Gazzella),
                CFactory.Crea(AnimalType.Gazzella),
                CFactory.Crea(AnimalType.Leone),
                CFactory.Crea(AnimalType.Leone),
                CFactory.Crea(AnimalType.Lepre),
                CFactory.Crea(AnimalType.Lepre)
            });

            turniSenzaMangiare = 0;
            PulisciGriglia();

            var posizioni = Enumerable.Range(0, 36)
                .OrderBy(_ => Guid.NewGuid())
                .Take(6)
                .Select(i => new Point(i / 6, i % 6))
                .ToList();

            for (int i = 0; i < 6; i++)
                PosizionaPersonaggio(animaliInVita[i], posizioni[i].X, posizioni[i].Y);

            AggiungiMessaggioChat("PARTITA INIZIATA – 6 animali in campo!");
        }

        // ====================== MUOVI ANIMALI ======================
        private void MuoviGliAnimali_Click(object sender, EventArgs e)
        {
            if (animaliInVita.Count == 0)
            {
                MessageBox.Show("Avvia prima una partita!");
                return;
            }

            Random rnd = new Random();
            bool qualcunoHaMangiato = false;

            PulisciGriglia();

            var destinazioni = new Dictionary<Point, List<CPersonaggio>>();

            foreach (var animale in animaliInVita.Where(a => a.Energy > 0).ToList())
            {
                int passi = Math.Clamp(animale.Speed / 20, 1, 5);
                int nr = Math.Clamp(animale.Riga + rnd.Next(-passi, passi + 1), 0, 5);
                int nc = Math.Clamp(animale.Colonna + rnd.Next(-passi, passi + 1), 0, 5);

                var punto = new Point(nr, nc);
                if (!destinazioni.ContainsKey(punto))
                    destinazioni[punto] = new List<CPersonaggio>();
                destinazioni[punto].Add(animale);
                animale.Sposta(nr, nc);
            }

          
            foreach (var gruppo in destinazioni)
            {
                var animali = gruppo.Value;
                if (animali.Count > 1 && animali.Any(a => a.TipoAnimale == AnimalType.Leone))
                {
                    var leone = animali.First(a => a.TipoAnimale == AnimalType.Leone);
                    qualcunoHaMangiato = true;

                    foreach (var preda in animali.Where(a => a != leone))
                    {
                        preda.Energy = 0;
                        animaliInVita.Remove(preda);
                        AggiungiMessaggioChat($"LEONE {leone.Name} ha MANGIATO {preda.Name}!");
                    }
                    PosizionaPersonaggio(leone, gruppo.Key.X, gruppo.Key.Y);
                }
                else
                {
                    foreach (var a in animali)
                        if (a.Energy > 0)
                            PosizionaPersonaggio(a, gruppo.Key.X, gruppo.Key.Y);
                }
            }

            // GESTIONE FAME LEONI
            if (qualcunoHaMangiato)
                turniSenzaMangiare = 0;
            else
                turniSenzaMangiare++;

            if (turniSenzaMangiare >= 10)
            {
                var leoni = animaliInVita.Where(a => a.TipoAnimale == AnimalType.Leone && a.Energy > 0).ToList();
                foreach (var leone in leoni)
                {
                    leone.Energy = 0;
                    animaliInVita.Remove(leone);
                    AggiungiMessaggioChat($"LEONE {leone.Name} È MORTO DI FAME dopo {turniSenzaMangiare} turni!");
                    
                    for (int r = 0; r < 6; r++)
                        for (int c = 0; c < 6; c++)
                            if (celle[r, c].Tag == leone)
                                celle[r, c].BackColor = Color.LightGray;
                }
                turniSenzaMangiare = 0;
            }

            int vivi = animaliInVita.Count(a => a.Energy > 0);
            AggiungiMessaggioChat($"Turno finito • Animali vivi: {vivi} • Fame leoni: {turniSenzaMangiare}/10");

            if (vivi <= 1)
            {
                var vincitore = animaliInVita.FirstOrDefault(a => a.Energy > 0);
                AggiungiMessaggioChat(vincitore != null
                    ? $"HA VINTO {vincitore.Name.ToUpper()}!!!"
                    : "TUTTI MORTI – Pareggio!");
            }
            // Controlla fine partita DOPO fame
            int leoniVivi = animaliInVita.Count(a => a.TipoAnimale == AnimalType.Leone && a.Energy > 0);
            int predeVive = animaliInVita.Count(a => a.TipoAnimale != AnimalType.Leone && a.Energy > 0);
            int viviTotali = leoniVivi + predeVive;

            AggiungiMessaggioChat($"Turno finito • Vivi: {viviTotali} • Leoni: {leoniVivi} • Fame: {turniSenzaMangiare}/10");

            // ===== FINE PARTITA =====
            if (leoniVivi == 0 && predeVive > 0)
            {
               
                AggiungiMessaggioChat("🏆 VINCONO LE PREDE! Tutti i leoni sono morti!");
                return; // FERMA IL GIOCO
            }
            else if (predeVive == 0 && leoniVivi > 0)
            {
                // TUTTE LE PREDE MANGIATE → VINCONO I LEONI!
                AggiungiMessaggioChat($"🦁 VINCONO I LEONI! ({leoniVivi} sopravvissuti)");
                return; // FERMA IL GIOCO
            }
            else if (viviTotali <= 1)
            {
                // CASO PARTICOLARE: solo 1 animale rimasto
                var vincitore = animaliInVita.FirstOrDefault(a => a.Energy > 0);
                if (vincitore != null)
                    AggiungiMessaggioChat($"👑 HA VINTO {vincitore.Name.ToUpper()}!!!");
                else
                    AggiungiMessaggioChat("TUTTI MORTI – Pareggio!");
                return; // FERMA IL GIOCO
            }
        }

        
        private void AggiungiMessaggioChat(string testo)
        {
            var lbl = new Label
            {
                Text = $"[{DateTime.Now:HH:mm}] {testo}",
                AutoSize = true,
                ForeColor = Color.DarkRed,
                BackColor = Color.LightYellow,
                Font = new Font("Segoe UI", 9F),
                Padding = new Padding(6),
                Margin = new Padding(3),
                MaximumSize = new Size(ChatSistema.Width - 40, 0)
            };

            ChatSistema.Controls.Add(lbl);
            ChatSistema.Controls.SetChildIndex(lbl, 0);

            if (ChatSistema.Controls.Count > 5)
            {
                var vecchio = ChatSistema.Controls[ChatSistema.Controls.Count - 1];
                ChatSistema.Controls.Remove(vecchio);
                vecchio.Dispose();
                //rimuove l'ultima label in modo da dare l'idea di 
            }

            ChatSistema.ScrollControlIntoView(lbl);
        }

       
        public void CancellaRighe()
        {
            ChatSistema.Controls.Clear();
        }

        private void Form1_Load(object sender, EventArgs e) => CancellaRighe();
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label2_Click_2(object sender, EventArgs e) { }
        private void label3_Click_1(object sender, EventArgs e) { }
        private void label4_Click_1(object sender, EventArgs e) { }
        private void label5_Click_1(object sender, EventArgs e) { }
        private void label6_Click_1(object sender, EventArgs e) { }
        private void label7_Click_1(object sender, EventArgs e) { }
        private void MatriceDiGioco_Paint(object sender, PaintEventArgs e) { }
    }
}