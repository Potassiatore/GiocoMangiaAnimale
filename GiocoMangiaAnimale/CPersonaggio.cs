using System;
using System.Drawing;  // Necessario per Color

namespace GiocoMangiaAnimale
{
    public enum AnimalType
    {
        Gazzella,
        Leone,
        Lepre
    }

    public abstract class CPersonaggio
    {
        public string Name { get; protected set; }
        public int Energy { get; set; }
        public int Speed { get; set; }

        public int Riga { get; set; } = -1;
        public int Colonna { get; set; } = -1;

        public AnimalType TipoAnimale { get; protected set; }

        public Color ColoreSfondo { get; protected set; }

        protected CPersonaggio(string name, int energy, int speed, AnimalType tipo)
        {
            Name = name;
            Energy = energy;
            Speed = speed;
            TipoAnimale = tipo;

            ColoreSfondo = tipo switch
            {
                AnimalType.Gazzella => Color.FromArgb(205, 133, 222),   
                AnimalType.Leone => Color.FromArgb(255, 140, 0),    
                AnimalType.Lepre => Color.FromArgb(139, 139, 139),  
                _ => Color.Purple
            };
        }

        public void Sposta(int nuovaRiga, int nuovaColonna)
        {
            Riga = nuovaRiga;
            Colonna = nuovaColonna;
        }

        public abstract string Move();
        public abstract string Eat();

        public override string ToString() => $"{Name} ({TipoAnimale})";
    }

    // === CLASSI FIGLIE ===
    public class Gazzella : CPersonaggio
    {
        public Gazzella(string name = "Gazzella")
            : base(name, energy: 80, speed: 90, AnimalType.Gazzella)
        {
        }
        public override string Move() => "La gazzella scappa velocissima!";
        public override string Eat() => "La gazzella mangia erba.";
    }

    public class Leone : CPersonaggio
    {
        public Leone(string name = "Leone")
            : base(name, energy: 100, speed: 70, AnimalType.Leone)
        {
        }
        public override string Move() => "Il leone avanza minaccioso...";
        public override string Eat() => "Il leone divora la preda!";

        public void LeoneMangiato()
        {
            
        }
    }

    public class Lepre : CPersonaggio
    {
        public Lepre(string name = "Lepre")
            : base(name, energy: 60, speed: 85, AnimalType.Lepre)
        {
        }
        public override string Move() => "La lepre fa zig-zag!";
        public override string Eat() => "La lepre rosicchia carote.";
    }
}