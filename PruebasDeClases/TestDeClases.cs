using Control_de_ingresos;

namespace PruebasDeClases
{
    public class TestDeClases
    {
        /// <summary>
        /// Verifica si dos productos del tipo Arroz son iguales.
        /// </summary
        [Test]
        public void MismoProductoArrozOK()
        {
            // Se crea dos instancias de Arroz con los mismos atributos 
            Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");
            Arroz arroz2 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");

            // Se compara las dos instancias de Arroz para verificar si son iguales
            bool resultado = arroz1 == arroz2;

            // Verifica que el resultado sea verdadero, ya que se espera que los productos sean iguales
            Assert.IsTrue(resultado);   
        }
        /// <summary>
        /// Verifica si dos productos del tipo Arroz son diferentes.
        /// </summary
        [Test]
        public void MismoProductoArrozNo()
        {
            // Se crea dos instancias de Arroz con los atributos diferentes
            Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");
            Arroz arroz2 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 5, 600f, "Argentina", "Chacra Gonzalez");

            // Se compara las dos instancias de Arroz para verificar si son iguales
            bool resultado = arroz1 == arroz2;

            // Verifica que el resultado sea falso, ya que se espera que los productos sean diferentes
            Assert.IsFalse(resultado);
        }





        /// <summary>
        /// Verifica si dos productos del tipo Gaseosa son iguales.
        /// </summary
        [Test]
        public void MismoProductoGaseosaOK()
        {
            // Se crea dos instancias de Gaseosa con los mismos atributos
            Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");
            Gaseosa gaseosa2 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");

            // Se compara las dos instancias de Gaseosa para verificar si son iguales
            bool resultado = gaseosa1 == gaseosa2;

            // Verifica que el resultado sea verdadero, ya que se espera que los productos sean iguales
            Assert.IsTrue(resultado);
        }
        /// <summary>
        /// Verifica si dos productos del tipo Gaseosa son diferentes.
        /// </summary
        [Test]
        public void MismoProductoGaseosaNo()
        {
            // Se crea dos instancias de Gaseosa con los atributos diferentes
            Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");
            Gaseosa gaseosa2 = new Gaseosa("Pepsi", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "Pepsi"), 3, 500f, 3f, "Cola");

            // Se compara las dos instancias de Gaseosa para verificar si son iguales
            bool resultado = gaseosa1 == gaseosa2;

            // Verifica que el resultado sea falso, ya que se espera que los productos sean diferentes
            Assert.IsFalse(resultado);
        }





        /// <summary>
        /// Verifica si dos productos del tipo GaseosaPorMayor son iguales.
        /// </summary
        [Test]
        public void MismoProductoGaseosaMayorOK()
        {
            // Se crea dos instancias de GaseosaPorMayor con los mismos atributos
            GaseosaPorMayor gaseosaPorMayor1 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 0.500f, "Uva", 1000, "Si");
            GaseosaPorMayor gaseosaPorMayor2 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 0.500f, "Uva", 1000, "Si");

            // Se compara las dos instancias de gaseosaPorMayor para verificar si son iguales
            bool resultado = gaseosaPorMayor1 == gaseosaPorMayor2;

            // Verifica que el resultado sea verdadero, ya que se espera que los productos sean iguales
            Assert.IsTrue(resultado);
        }
        /// <summary>
        /// Verifica si dos productos del tipo GaseosaPorMayor son diferentes.
        /// </summary
        [Test]
        public void MismoProductoGaseosaMayorNo()
        {
            // Se crea dos instancias de GaseosaPorMayor con atributos diferentes
            GaseosaPorMayor gaseosaPorMayor1 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 0.500f, "Uva", 1000, "Si");
            GaseosaPorMayor gaseosaPorMayor2 = new GaseosaPorMayor("Don Antonio", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Swift"), 4, 150f, 0.500f, "Naranja", 500, "No");
            
            // Se compara las dos instancias de gaseosaPorMayor para verificar si son iguales
            bool resultado = gaseosaPorMayor1 == gaseosaPorMayor2;

            // Verifica que el resultado sea falso, ya que se espera que los productos sean distintos
            Assert.IsFalse(resultado);
        }






        /// <summary>
        /// Verifica si dos productos del tipo Milanesas son iguales.
        /// </summary>
        [Test]
        public void MismoProductoMilanesaOK()
        {
            // Se crea dos instancias de Milanesas con los mismos atributos

            Milanesas milanesa1 = new Milanesas("Fernando", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Vacuno", "Brasil");
            Milanesas milanesa2 = new Milanesas("Fernando", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Vacuno", "Brasil");

            // Se compara las dos instancias de Milanesas para verificar si son iguales

            bool resultado = milanesa1 == milanesa2;

            // Verifica que el resultado sea verdadero, ya que se espera que los productos sean iguales
            Assert.IsTrue(resultado);
        }
        /// <summary>
        /// Verifica si dos productos del tipo Milanesas son diferentes.
        /// </summary>
        [Test]
        public void MismoProductoMilanesaNo()
        {
            // Se crea dos instancias de Milanesas con distintos atributos

            Milanesas milanesa1 = new Milanesas("Fernando", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Vacuno", "Brasil");
            Milanesas milanesa2 = new Milanesas("Franco", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Bovino", "Argentino");

            // Se compara las dos instancias de Milanesas para verificar si son diferentes

            bool resultado = milanesa1 == milanesa2;

            // Verifica que el resultado sea falso, ya que se espera que los productos sean distintos

            Assert.IsFalse(resultado);
        }
    }
}