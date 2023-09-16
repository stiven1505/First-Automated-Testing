using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


class Program
{
    static void Main()
    {
        // Configuración de ChromeDriver
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized"); // Maximizar la ventana del navegador

        IWebDriver driver = new ChromeDriver(options);

        try
        {
            //-------------Paso 1: Ingresar al sitio----------------------------------------

            driver.Navigate().GoToUrl("https://www.ktronix.com/");


            //-------------Paso 2: En la barra de búsqueda escribe el producto “Silla Gamer"------------------


            // Encontrar barra de búsqueda
            IWebElement barraBusqueda = driver.FindElement(By.Name("text"));

            // Ingresar Texto
            barraBusqueda.SendKeys("Silla Gamer");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Habilita manualmente el botón de búsqueda a través de JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('js-search-button').removeAttribute('disabled');");

            // Haz clic en el botón de búsqueda
            IWebElement barraBusquedaBoton = driver.FindElement(By.Id("js-search-button"));
            barraBusquedaBoton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            
            //--------------Paso 3: Seleccionar el producto de menor precio---------------------------------


            // Encontrar el filtro de ordenamiento
            IWebElement selectFiltroOrdenamiento = driver.FindElement(By.Id("js-toolbar-container"));

            // clic en el filtro para abrirlo
            selectFiltroOrdenamiento.Click();

            // Encontrar opcion de filtro
            IWebElement selectFiltroOrdenamientoS = driver.FindElement(By.XPath("//li[@data-value='ktronixIndexAlgoliaPRD_price_asc']"));
            selectFiltroOrdenamientoS.Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));


            //--------------Paso 4: Agregar El producto al carrito---------------------------------

            // Encontrar boton de carro de compras en la primera posicion
            IWebElement botonCarroCompras = driver.FindElement(By.XPath("(//button[contains(@class,'js-cart-algolia')])[1]"));

            // Hacer clic en el primer botón "Agregar al carrito"
            botonCarroCompras.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));


            //--------------Paso 5: Seleccionar la opción Finalizar compra---------------------------------

            //Encontrar link con el texto Ir al carrito y pagar
            IWebElement linkCarroyPagar = driver.FindElement(By.LinkText("Ir al carrito y pagar"));

            // Hacer clic en el enlace
            linkCarroyPagar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));


            //--------------Paso 6: Aumentar la cantidad a 3 productos---------------------------------

            // Encontrar select de la cantidad de productos
            IWebElement selectCantidad = driver.FindElement(By.Id("quantity_0"));

            // Hacer clic en el elemento select para abrir las opciones
            selectCantidad.Click();

            // Encontrar la opción deseada por su valor y hacer clic en ella
            IWebElement selectCantidadS = driver.FindElement(By.XPath("//select[@id='quantity_0']/option[@value='3']"));

            selectCantidadS.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));


            // Encontrar el boton ir a pagar
            IWebElement botonPagar = driver.FindElement(By.Id("js-go-to-pay"));

            // Hacer clic en el boton ir a pagar 
            botonPagar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            //--------------Paso 7: Agregar un email y pulsar continuar---------------------------------

            // Encontrar el input de agregar correo
            IWebElement inputCorreo = driver.FindElement(By.Id("j_username"));
            inputCorreo.SendKeys("stivengr2@gmail.com");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el boton continuar
            IWebElement botonPagarContinuar = driver.FindElement(By.ClassName("js-enabled-btn-continue"));

            // Hacer clic en el boton continuar
            botonPagarContinuar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            //--------------Paso 8: Agregar los datos obligatorios y continuar hasta el “Forma de Pago”---------------------------------

            // Encontrar el input de datos-nombres
            IWebElement inputNombres = driver.FindElement(By.Id("firstName"));
            inputNombres.SendKeys("Brayan");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el input de datos-apellidos
            IWebElement inputApellidos = driver.FindElement(By.Id("lastName"));
            inputApellidos.SendKeys("Garcia");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el input por su datos-celular
            IWebElement inputCelular = driver.FindElement(By.Id("phone"));
            inputCelular.SendKeys("3151232736");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el elemento label para aceptar terminos y condiciones
            IWebElement labelAceptarTerminos = driver.FindElement(By.XPath("//label[@for='consent']"));

            labelAceptarTerminos.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el boton Continuar
            IWebElement botonDatosContinuar = driver.FindElement(By.ClassName("js-validate-length-name"));

            botonDatosContinuar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el Select para el tipo de documento
            IWebElement selectEnvioTDoc = driver.FindElement(By.Name("idTypeCode")); 

            selectEnvioTDoc.Click();

            // Encontrar y seleccionar la opción "CC" por su valor
            IWebElement selectEnvioTDocS = driver.FindElement(By.XPath("//li[@data-value='CC']"));
            selectEnvioTDocS.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el input para la cedula
            IWebElement inputEnvioNCedula = driver.FindElement(By.Id("address.idNumber"));
            inputEnvioNCedula.SendKeys("3153437736");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el Select para el Departamento
            IWebElement selectEnvioDepartamento = driver.FindElement(By.Name("provinceCode"));

            selectEnvioDepartamento.Click();

            // Encontrar y seleccionar la opción "Valle del cauca" por su valor
            IWebElement selectEnvioDepartamentoS = driver.FindElement(By.XPath("//li[@data-value='Valle del cauca']"));
            selectEnvioDepartamentoS.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el Select para el Ciudad
            IWebElement selectEnvioCiudad = driver.FindElement(By.Name("cityCode"));

            selectEnvioCiudad.Click();

            // Encontrar y seleccionar la opción "Valle del cauca" por su valor
            IWebElement selectEnvioCiudadS = driver.FindElement(By.XPath("//li[@data-value='Cali']"));
            selectEnvioCiudadS.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el input para la Direccion
            IWebElement inputEnvioDireccion = driver.FindElement(By.Id("addessLine1"));
            inputEnvioNCedula.SendKeys("Carrera 29 #8g8");
            
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el input para la Direccion
            IWebElement inputEnvioBarrio = driver.FindElement(By.Id("addessDistrict"));
            inputEnvioNCedula.SendKeys("Villa del prado");

            // Encontrar el elemento <label> por guardar direccion
            IWebElement labelGuardarDireccion = driver.FindElement(By.XPath("//label[@for='saveAddressInMyAddressBook']")); 
            labelGuardarDireccion.Click();

            // Encontrar el boton Continuar
            IWebElement botonEnvioContinuar = driver.FindElement(By.Id("continueAddress"));

            botonEnvioContinuar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Encontrar el boton Continuar
            IWebElement botonMEnvioContinuar = driver.FindElement(By.Id("deliveryMethodSubmit"));

            botonMEnvioContinuar.Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));





        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // Cierra el navegador al finalizar la prueba
            driver.Quit();
        }
    }
}
