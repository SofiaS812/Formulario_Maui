namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {


        //documento
        private String Documento()
        {
            if (Documento2.SelectedItem == null)
            {
                return null;
            }
            return Documento2.SelectedItem.ToString();
        }


        //sexo
        private String Sexo(){
            if (Masculino.IsChecked) // este if verifica si el radiobutton masculino esta seleccionado
            {
                return "Masculino"; //le asigna el valor de masculino a la variable sexo
            }
            if (Femenino.IsChecked)
            {
                return "Femenino";
            }
            return null; //si ninguna de las opciones es seleccionada no se le asigna ningun valor
        }


        //edad
        private int Edad()
        {
            DateTime fecha_nacimiento = fechanacimiento.Date; // se obtiene la fecha de nacimiento y se guarda en una variable
            DateTime fecha_actual = DateTime.Today; //se obtiene la fecha actual
            int edad = fecha_actual.Year - fecha_nacimiento.Year; //se calcula la edad restando los años de la fecha actual menos los años de la fecha de nacimiento
            //ajustar si aun no ah pasado el cumpleaños en este año
            if (fecha_nacimiento.Date > fecha_actual.AddYears(-edad))
            {
                edad = edad - 1;// si no ha pasado la fecha de cumpleaños le resta un año
            }
            return edad;
        }




        //saludar
        private async Task Saludar()
        {
            string nombrep = Nombre.Text; // se obtiene el valor del nombre que se registro en el formulario
            string sexo = Sexo();//variable donde vamos a guardar el sexo
            DateTime fecha_nacimiento = fechanacimiento.Date;
            DateTime fecha_actual = DateTime.Today;
            int edad = Edad();
            string documento = Documento();




            //msjs error 
            if (documento == null)
            {
                await DisplayAlert("Error", "Por favor, seleccione un tipo de documento.", "OK");
                return;
            }

            if (nombrep ==null || nombrep == "")
            {
                await DisplayAlert("ERROR", "Por favor, ingrese su nombre", "CERRAR");
                return; // Detiene la ejecución de la función
            }

            if (fecha_nacimiento == fecha_actual)
            {
                await DisplayAlert("ERROR", "Por favor, seleccione su fecha de nacimiento", "CERRAR");
                return; // Detiene la ejecución de la función
            }

            if (sexo == null)
            {
                await DisplayAlert("ERROR", "Por favor, seleccione su sexo", "CERRAR");
                return; // Detiene la ejecución de la función
            }







            //saludo con msjs error al documento no valido
            if ((edad >= 18 && documento == "Documento identidad") || (edad < 18 && (documento == "Cedula de ciudadania")))
            {
                await DisplayAlert("Error", "El documento seleccionado no es válido para la edad ingresada. Por favor, seleccione un documento válido.", "CERRAR");
            }
            else if (edad >= 18 && (documento == "Cedula de ciudadania" || documento == "Documento extranjero"))
            {
                if (sexo == "Masculino")
                {
                    await DisplayAlert("Saludo", $"Hola señor {nombrep}, identificado con {documento} muchas gracias por su registro", "CERRAR");//muestra el mensaje correspondiente
                }
                else if (sexo == "Femenino")
                {
                    await DisplayAlert("Saludo", $"Hola señora {nombrep}, identificada con {documento} muchas gracias por su registro", "CERRAR");//muestra el mensaje correspondiente
                }
            }
            else if (edad < 18 && (documento == "Documento identidad" || documento == "Documento extranjero"))
            {
                if (sexo == "Masculino")
                {
                    await DisplayAlert("Saludo", $"Hola niño {nombrep}, identificado con {documento} muchas gracias por tu registro", "cerrar");//muestra el mensaje correspondiente
                }
                else if (sexo == "Femenino")
                {
                    await DisplayAlert("Saludo", $"Hola niña {nombrep}, identificada con {documento}  muchas gracias por tu registro", "CERRAR");//muestra el mensaje correspondiente
                }

            }
        }





        public MainPage()
        {
            InitializeComponent();
        }

        private async void Saludobtn_Clicked(object sender, EventArgs e)
        {
            await Saludar();
        }
    }
    }

