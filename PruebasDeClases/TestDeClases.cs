using Control_de_ingresos;

namespace PruebasDeClases
{
    public class TestDeClases
    {

        [Test]
        public void MismoProductoArrozOK()
        {
            Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");
            Arroz arroz2 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");

            bool resultado = arroz1 == arroz2;

            Assert.IsTrue(resultado);   
            // Arroz arroz2 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 5, 600f, "Argentina", "Chacra Gonzalez");
        }

        [Test]
        public void MismoProductoArrozNo()
        {
            Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");
            Arroz arroz2 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 5, 600f, "Argentina", "Chacra Gonzalez");

            bool resultado = arroz1 == arroz2;

            Assert.IsFalse(resultado);
        }

        [Test]
        public void MismoProductoGaseosaOK()
        {
            Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");
            Gaseosa gaseosa2 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");

            bool resultado = gaseosa1 == gaseosa2;

            Assert.IsTrue(resultado);
        }

        [Test]
        public void MismoProductoGaseosaNo()
        {
            Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");
            Gaseosa gaseosa2 = new Gaseosa("Pepsi", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "Pepsi"), 3, 500f, 3f, "Cola");

            bool resultado = gaseosa1 == gaseosa2;

            Assert.IsFalse(resultado);
        }
    }
}