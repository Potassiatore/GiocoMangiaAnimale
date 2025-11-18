using System;

namespace GiocoMangiaAnimale
{

    public static class CFactory
    {
        private static int contatoreGazzella = 1;
        private static int contatoreLeone = 1;
        private static int contatoreLepre = 1;

        public static CPersonaggio Crea(AnimalType tipo)
        {
            return tipo switch
            {
                AnimalType.Gazzella => new Gazzella($"Gazzella {contatoreGazzella++}"),
                AnimalType.Leone => new Leone($"Leone {contatoreLeone++}"),
                AnimalType.Lepre => new Lepre($"Lepre {contatoreLepre++}"),
                _ => throw new ArgumentException("Tipo animale non supportato: " + tipo)
            };
        }


        public static CPersonaggio Crea(AnimalType tipo, string nomePersonalizzato)
        {
            return tipo switch
            {
                AnimalType.Gazzella => new Gazzella(nomePersonalizzato),
                AnimalType.Leone => new Leone(nomePersonalizzato),
                AnimalType.Lepre => new Lepre(nomePersonalizzato),
                _ => throw new ArgumentException("Tipo animale non supportato")
            };
        }



    }
}