using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            string Nombre;
            string Apellido;
            string Rut;
            string Fecha_Nacimiento;
            string Nacionalidad;
            string Cargo_Trabajador;
            string Tipo_Trabajador;
            string Sueldo;
            int Cantidad;
            string Marca;
            string Nombre_Cliente;


            Supermercado Gestor = new Supermercado();
            Console.WriteLine("Bienvenido, escoja una de las opciones antes de continuar.\n");
            while (opcion != "3")
            {

                Console.WriteLine("Presione 1 para acceder al menu del cliente.\n");
                Console.WriteLine("Presione 2 para acceder al menu del administrador.\n");
                Console.WriteLine("Presione 3 para salir del programa.\n");

                opcion = Console.ReadLine();

                Console.WriteLine("\n");
                if (opcion == "1")
                {

                    Console.WriteLine("Bienvenido al supermercado!\n");
                    bool VorF;
                    string trabajo;
                    Console.WriteLine("Ingrese su nombre:\n");
                    Nombre_Cliente = Console.ReadLine();
                    Console.WriteLine("Ingrese su apellido:\n");
                    Apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese su Rut:\n");
                    Rut = Console.ReadLine();
                    Console.WriteLine("Ingrese su fecha de nacimiento:\n");
                    Fecha_Nacimiento = Console.ReadLine();
                    Console.WriteLine("Ingrese su nacionalidad:\n");
                    Nacionalidad = Console.ReadLine();

                    VorF = Gestor.Validar_Clientes_nuevos(Rut);

                    if (VorF == true)
                    {
                        Trabajadores cliente = new Trabajadores(Rut, Nombre_Cliente, Apellido, Fecha_Nacimiento, Nacionalidad, "Cliente");
                        Gestor.Almacenar_Datos(cliente);
                        Console.WriteLine("Cliente almacenado con exito!.\n");
                        while (opcion == "1")
                        {   
                            Console.WriteLine("Presione 1 para agregar productos al carro.\n");
                            Console.WriteLine("Presione 2 para salir del menu del cliente.\n");
                            opcion = Console.ReadLine();
                            if (opcion == "1")
                            {
                                bool VorF_producto_existe;
                                string VorF_stock;
                                Console.WriteLine("Productos:\n");
                                Console.WriteLine(Gestor.Mostrar_Productos());
                                Console.WriteLine("A continuación ingrese los productos para agregar al carro\n");
                                Console.WriteLine("Ingrese el nombre del producto\n");
                                Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese la marca del producto\n");
                                Marca = Console.ReadLine();
                                Console.WriteLine("Ingrese la cantidad a comprar (N° int)");
                                Cantidad = int.Parse(Console.ReadLine());

                                // Si es true el producto ya existe
                                VorF_producto_existe = Gestor.Validador_Producto_existente(Nombre, Marca);
                                if (VorF_producto_existe == true)
                                {
                                    
                                    VorF_stock = Gestor.Validador_Stock(Nombre, Marca, Cantidad);
                                    Console.WriteLine(VorF_stock);
                                    //Cantidad es menor o igual al del stock
                                    if (VorF_stock == "1")
                                    {
                                        string opcion_carro;
                                        Console.WriteLine("¿Desea agregar este producto al carro?, ingrese SI o NO para continuar");
                                        Gestor.Mostrar_Producto_Especifico(Nombre, Marca, Cantidad);
                                        opcion_carro = Console.ReadLine();

                                        if (opcion_carro == "SI")
                                        {
                                            //Agregar al carro
                                            Console.WriteLine("Producto agregado al carro con exito!\n");
                                            string Opcion_Cancelar_TorF;
                                            Console.WriteLine("Presione 1 para cancelar en caja\n");
                                            Console.WriteLine("Presione 2 para volver al menu del cliente\n");
                                            Opcion_Cancelar_TorF = Console.ReadLine();

                                            if (Opcion_Cancelar_TorF=="1")
                                            {
                                                
                                                string texto;
                                                Gestor.Comprar_Productos(Nombre, Marca, Cantidad);
                                                Random rnd = new Random();
                                                int month = rnd.Next(1, 13);  
                                                int day = rnd.Next(1, 31);  
                                                int hora = rnd.Next(9,20);
                                                int minutos = rnd.Next(0, 61);
                                                texto = "Nombre: "+Nombre+" Marca: "+Marca+" Cantidad: "+Cantidad+" Fecha: "+day+"/"+month+"/"+"2020"+" Hora: "+hora+":"+minutos+" "+ "Cajero: " +"Wilson Perez";
                                                Gestor.Almacenar_Registro(Rut, texto);
                                                
                                                Console.WriteLine("Productos cancelados correctamente!\n");
                                                
                                            }
                                            else
                                            {

                                            }


                                        }
                                        else
                                        {
                                            
                                        }

                                    }
                                    else if (VorF_stock=="0")
                                    {   
                                        Console.WriteLine("Lo sentimos la cantidad de stock del producto es 0\n");
                                    }
                                    else if (VorF_stock=="2")
                                    {
                                        Console.WriteLine("Ingrese una cantidad menor o igual al stock\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Lo sentimos este producto no existe en nuestro supermercado\n");
                                }



                            }
                            else if (opcion=="2")
                            {

                            }


                        }
                    }
                    else
                    {
                        VorF = Gestor.Validador_Rut(Rut);
                        //No agregar dado que ya esta en una base
                        if (VorF == true)
                        {
                            trabajo = Gestor.GetWorker(Rut);
                            if (trabajo == "Auxiliar" || trabajo == "Jefe" || trabajo == "Guardia" || trabajo == "Supervisor" || trabajo == "Cajero" || trabajo == "Reponedor")
                            {
                                Console.WriteLine("ERROR:Este Rut pertenece a un trabajador del supermercado!\n");
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Este rut pertenece a un cliente ya creado!\n");
                            }
                        }
                    }









                }
                else if (opcion == "2")
                {
                    Console.WriteLine("Bienvenido al menu de administración del Supermercado!\n" + "Presione unas de las siguientes acciones para continuar.\n");
                    Console.WriteLine("Presione 1 para mostrar los clientes.\n");
                    Console.WriteLine("Presione 2 para crear un nuevo empleado.\n");
                    Console.WriteLine("Presione 3 para ver trabajadores.\n");
                    Console.WriteLine("Presione 4 para cambiar puesto de trabajo de empleado.\n");
                    Console.WriteLine("Presione 5 para cambiar sueldo de empleado.\n");
                    //La opción 5 puede cambiar el horario de trabajado de solo un empleado, o de todo los de cierto tipo de trabajo.
                    Console.WriteLine("Presione 6 para cambiar horario de trabajador.\n");
                    Console.WriteLine("Presione 7 para agregar un NUEVO producto.\n");
                    Console.WriteLine("Presione 8 para agregar stock a producto ya existente.\n");
                    Console.WriteLine("Presione 9 para ver la base de datos de los productos.\n");

                    Console.WriteLine("Presione 10 para ver el registro de compras.\n");


                    string opcion_admin;
                    opcion_admin = Console.ReadLine();
                    
                    if (opcion_admin == "1")
                    {

                        Console.WriteLine(Gestor.Mostrar_Listas(opcion_admin));


                    }

                    else if (opcion_admin == "2")
                    {
                        bool VorF;
                        string trabajo;
                        //Falta agregar el caso en el que ya existe este trabajador
                        Console.WriteLine("Ingrese el Nombre del trabajador:\n");
                        Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el Apellido del trabajador:\n");
                        Apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese el Rut del trabajador:\n");
                        Rut = Console.ReadLine();
                        Console.WriteLine("Ingrese la Fecha de nacimiento del trabajador:\n");
                        Fecha_Nacimiento = Console.ReadLine();
                        Console.WriteLine("Ingrese la Nacionalidad del trabajador:\n");
                        Nacionalidad = Console.ReadLine();
                        Console.WriteLine("Ingrese el cargo del trabajador (en singular y primera variable en Mayuscula):\n");
                        Cargo_Trabajador = Console.ReadLine();
                        Console.WriteLine("\n");




                        if (Cargo_Trabajador != "Auxiliar" && Cargo_Trabajador != "Supervisor" && Cargo_Trabajador != "Guardia" && Cargo_Trabajador != "Cajero" && Cargo_Trabajador != "Jefe" && Cargo_Trabajador != "Reponedor")
                        {
                            Console.WriteLine("Error:Ingrese un cargo correcto porfavor!.");
                        }
                        else
                        {
                            if (Cargo_Trabajador == "Cliente")
                            {
                                Console.WriteLine("ERROR: Ingrese un cargo correcto porfavor!.\n");
                            }
                            else
                            {
                                VorF = Gestor.Validador_Rut(Rut);
                                //No agregar dado que ya esta en una base
                                if (VorF == true)
                                {
                                    trabajo = Gestor.GetWorker(Rut);
                                    if (trabajo == "Auxiliar" || trabajo == "Jefe" || trabajo == "Guardia" || trabajo == "Supervisor" || trabajo == "Cajero" || trabajo == "Reponedor")
                                    {
                                        Console.WriteLine("ERROR:Este Rut pertenece a un trabajador del supermercado!\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERROR: Este rut pertenece a un cliente ya creado!\n");
                                    }
                                }
                                else
                                {
                                    Trabajadores trabajadores = new Trabajadores(Rut, Nombre, Apellido, Fecha_Nacimiento, Nacionalidad, Cargo_Trabajador);
                                    Gestor.Almacenar_Datos(trabajadores);
                                    Console.WriteLine("Trabajador agregado a la base de datos!.");
                                }


                            }

                        }


                    }
                    else if (opcion_admin == "3")
                    {
                        Console.WriteLine(Gestor.Mostrar_Listas(opcion_admin));

                    }
                    else if (opcion_admin == "4")
                    {

                        string Trabajo_cambio;
                        bool VorF;
                        bool VorF1;
                        Console.WriteLine("Escriba el nombre del trabajo al cual va cambiar al empleado.\n");
                        Trabajo_cambio = Console.ReadLine();
                        VorF = Gestor.Validador_Trabajo(Trabajo_cambio);
                        if (VorF == true)
                        {

                            Console.WriteLine("Ingrese el Rut del trabajador:\n");
                            Rut = Console.ReadLine();
                            Console.WriteLine("\n");

                            //Identificador persona me da su trabajao en string, si no existe me da un string nulo
                            Tipo_Trabajador = Gestor.GetWorker(Rut);

                            VorF1 = Gestor.Cambiar_Trabajo(Rut, Trabajo_cambio);
                            if (VorF1 == true)
                            {
                                Console.WriteLine("Trabajo cambiado con exito!\n");

                            }
                            else
                            {
                                Console.WriteLine("Error: Trabajador esta registrado mas de una vez por el mismo rut!");
                            }



                        }
                        else
                        {
                            Console.WriteLine("Error:El nombre del trabajo no es valido!.\n");
                        }

                    }
                    else if (opcion_admin == "5")
                    {
                        bool booleano;
                        Console.WriteLine("Ingrese el rut del trabajador:\n");
                        Rut = Console.ReadLine();
                        Console.WriteLine("Ingrese el monto nuevo de salario");
                        Sueldo = Console.ReadLine();

                        booleano = Gestor.Cambiar_Sueldo(Rut, Sueldo);
                        if (booleano == true)
                        {
                            Console.WriteLine("Sueldo cambiado con exito!.\n");
                        }
                        else
                        {
                            Console.WriteLine("Error:Rut ingresado no existente!.\n");
                        }
                    }
                    else if (opcion_admin == "6")
                    {
                        bool booleano;
                        string Horario;
                        Console.WriteLine("Ingrese el rut del trabajador:\n");
                        Rut = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo horario del trabajador");
                        Horario = Console.ReadLine();

                        booleano = Gestor.Cambio_Horario(Rut, Horario);
                        if (booleano == true)
                        {
                            Console.WriteLine("Horario cambiado con exito!.\n");
                        }
                        else
                        {
                            Console.WriteLine("Error:Rut ingresado no existente!.\n");
                        }

                    }
                    // Agregar un nuevo producto
                    else if (opcion_admin == "7")
                    {
                        string Nombre_Producto;
                        string Marca_Producto;
                        string Precio_Producto;
                        int Stock_Producto;
                        bool VorF;

                        Console.WriteLine("Ingrese el nombre del producto:\n");
                        Nombre_Producto = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de la marca:\n");
                        Marca_Producto = Console.ReadLine();
                        Console.WriteLine("Ingrese el precio del producto:\n");
                        Precio_Producto = Console.ReadLine();
                        Console.WriteLine("Ingrese el stock del producto (Ingrese un numero):\n");
                        Stock_Producto = int.Parse(Console.ReadLine());

                        //Verificador nuevo producto

                        VorF = Gestor.Validador_nuevo_Producto(Nombre_Producto, Marca_Producto);

                        if (VorF == true)
                        {
                            Gestor.Agregar_Producto(Nombre_Producto, Marca_Producto, Precio_Producto, Stock_Producto);
                            Console.WriteLine("Producto Agregado con exito!.\n");
                        }
                        else
                        {
                            Console.WriteLine("El producto ingresado ya existe!.\n");
                        }

                    }
                    // Agregar stock a productos ya existentes 
                    else if (opcion_admin == "8")
                    {
                        string Nombre_Producto;
                        string Marca_Producto;
                        int Stock_Producto;
                        bool VorF;

                        Console.WriteLine("Ingrese el nombre del producto:\n");
                        Nombre_Producto = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de la marca:\n");
                        Marca_Producto = Console.ReadLine();
                        Console.WriteLine("Ingrese el Monto que quiere agregar al producto (Ingrese un numero):\n");
                        Stock_Producto = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n");

                        VorF = Gestor.Validador_Producto_existente(Nombre_Producto, Marca_Producto);

                        //Producto ya existe
                        if (VorF == true)
                        {
                            Gestor.Agregar_Stock(Nombre_Producto, Marca_Producto, Stock_Producto);
                            Console.WriteLine("Stock agregado con exito!\n");
                        }
                        else
                        {
                            Console.WriteLine("Este producto no existe en la base de datos de productos!.\n");
                        }


                    }

                    else if (opcion_admin == "9")
                    {
                        Console.WriteLine(Gestor.Mostrar_Productos());
                    }


                    else if(opcion_admin=="10")
                    {
                        Console.WriteLine(Gestor.Mostrar_Registro());
                    }


                }








            }








        }







    }


    class Person
    {
        private string Rut;
        private string Nombre;
        private string Apellido;
        private string Fecha_Nacimiento;
        private string Nacionalidad;

        public Person(string Rut, string Nombre, string Apellido, string fecha_nacimiento, string Nacionalidad)
        {
            this.Rut1 = Rut;
            this.Nombre1 = Nombre;
            this.Apellido1 = Apellido;
            Fecha_Nacimiento1 = fecha_nacimiento;
            this.Nacionalidad1 = Nacionalidad;
        }


        public string Rut1 { get => Rut; private set => Rut = value; }
        public string Nombre1 { get => Nombre; private set => Nombre = value; }
        public string Apellido1 { get => Apellido; private set => Apellido = value; }
        public string Fecha_Nacimiento1 { get => Fecha_Nacimiento; private set => Fecha_Nacimiento = value; }
        public string Nacionalidad1 { get => Nacionalidad; private set => Nacionalidad = value; }
    }

    class Trabajadores : Person
    {
        private string Tipo_Persona;
        private string Sueldo;
        private string Horario_Trabajo;

        public Trabajadores(string Rut, string Nombre, string Apellido, string fecha_nacimiento, string Nacionalidad, string Tipo_Persona) : base(Rut, Nombre, Apellido, fecha_nacimiento, Nacionalidad)
        {
            this.Tipo_Persona1 = Tipo_Persona;
            if (Tipo_Persona == "Jefe")
            {
                Sueldo1 = "800.000";
                Horario_Trabajo1 = "8:30-22:00";
            }
            else if (Tipo_Persona == "Auxiliar")
            {
                Sueldo1 = "400.000";
                Horario_Trabajo1 = "8:30-22:00";

            }
            else if (Tipo_Persona == "Cajero")
            {
                Sueldo1 = "400.000";
                Horario_Trabajo1 = "8:30-22:00";

            }
            else if (Tipo_Persona == "Guardia")
            {
                Sueldo1 = "400.000";
                Horario_Trabajo1 = "8:30-22:00";

            }
            else if (Tipo_Persona == "Supervisor")
            {
                Sueldo = "400.000";
                Horario_Trabajo1 = "8:30-22:00";

            }
            else if (Tipo_Persona == "Reponedor")
            {
                Sueldo = "400.000";
                Horario_Trabajo1 = "8:30-22:00";

            }
        }

        public string Tipo_Persona1 { get => Tipo_Persona; set => Tipo_Persona = value; }
        public string Sueldo1 { get => Sueldo; set => Sueldo = value; }
        public string Horario_Trabajo1 { get => Horario_Trabajo; set => Horario_Trabajo = value; }
    }






    class Supermercado
    {

        private List<Trabajadores> Lista_Clientes = new List<Trabajadores>();
        private List<Trabajadores> Lista_Auxiliares = new List<Trabajadores>();
        private List<Trabajadores> Lista_Jefes = new List<Trabajadores>();
        private List<Trabajadores> Lista_Supervisores = new List<Trabajadores>();
        private List<Trabajadores> Lista_Guardias = new List<Trabajadores>();
        private List<Trabajadores> Lista_Cajeros = new List<Trabajadores>();
        private List<Trabajadores> Lista_Reponedores = new List<Trabajadores>();
        private List<Productos> Lista_Productos = new List<Productos>();
        private Dictionary<string, string> Registro_Compras = new Dictionary<string, string>();


        public Supermercado()
        {

        }


        public bool Validador_Trabajo(string nombre_trabajo)
        {

            // Practicamente es un validador no completo de si esta bien ingresado el trabajo
           
            if (nombre_trabajo == "Auxiliar")
            {
                return true;
            }
            else if (nombre_trabajo == "Supervisore")
            {
                return true;
            }
            else if (nombre_trabajo == "Guardia")
            {
                return true;
            }
            else if (nombre_trabajo == "Cajero")
            {
                return true;
            }
            else if (nombre_trabajo == "Jefe")
            {
                return true;
            }
            else if (nombre_trabajo == "Reponedor")
            {
                return true;
            }
            return false;
        }
        public bool Cambiar_Trabajo(string Rut, string Trabajo_cambio)
        {
            int validador = 0;
            string Tipo_Trabajador;
            Tipo_Trabajador = GetWorker(Rut);
            foreach (Trabajadores objeto in GetList(Tipo_Trabajador))
            {

                if (objeto.Rut1 == Rut)
                {
                    objeto.Tipo_Persona1 = Trabajo_cambio;
                    validador += 1;
                    return true;
                }
            }
            if (validador == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //Metodo que almacena los objetos de la clase Supermercado en la lista correspondiente a su trabajo (Auxiliar, Supervisor, Guardia, Cajero, Jefe y Reponedor)
        public void Almacenar_Datos(Trabajadores dato)
        {
            if (dato.Tipo_Persona1 == "Cliente")
            {
                Lista_Clientes.Add(dato);
            }
            else if (dato.Tipo_Persona1 == "Auxiliar")
            {
                Lista_Auxiliares.Add(dato);
            }
            else if (dato.Tipo_Persona1 == "Supervisor")
            {
                Lista_Supervisores.Add(dato);
            }
            else if (dato.Tipo_Persona1 == "Jefe")
            {
                Lista_Jefes.Add(dato);
            }
            else if (dato.Tipo_Persona1 == "Guardia")
            {
                Lista_Guardias.Add(dato);
            }
            else if (dato.Tipo_Persona1 == "Reponedor")
            {
                Lista_Reponedores.Add(dato);
            }
            else if (dato.Tipo_Persona1 == "Cajero")
            {
                Lista_Cajeros.Add(dato);


            }


        }


        public string Mostrar_Listas(string opcion_admin)
        {
            string texto_clientes = "";
            string texto;

            string texto_completo = "";
            if (opcion_admin == "1")
            {
                foreach (Trabajadores objeto in Lista_Clientes)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1;
                    texto_clientes += texto + "\n";
                }
                return texto_clientes;
            }
            else
            {
                foreach (Trabajadores objeto in Lista_Auxiliares)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1 + " Trabajo: " + objeto.Tipo_Persona1 + ", Sueldo: " + objeto.Sueldo1 + " ,Horario " + objeto.Horario_Trabajo1;
                    texto_completo += texto + "\n";
                }

                foreach (Trabajadores objeto in Lista_Cajeros)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1 + " Trabajo: " + objeto.Tipo_Persona1 + ", Sueldo: " + objeto.Sueldo1 + " ,Horario " + objeto.Horario_Trabajo1;
                    texto_completo += texto + "\n";
                }
                foreach (Trabajadores objeto in Lista_Guardias)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1 + " Trabajo: " + objeto.Tipo_Persona1 + ", Sueldo: " + objeto.Sueldo1 + " ,Horario " + objeto.Horario_Trabajo1;
                    texto_completo += texto + "\n";
                }
                foreach (Trabajadores objeto in Lista_Jefes)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1 + " Trabajo: " + objeto.Tipo_Persona1 + ", Sueldo: " + objeto.Sueldo1 + " ,Horario " + objeto.Horario_Trabajo1;
                    texto_completo += texto + "\n";
                }
                foreach (Trabajadores objeto in Lista_Reponedores)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1 + " Trabajo: " + objeto.Tipo_Persona1 + ", Sueldo: " + objeto.Sueldo1 + " ,Horario " + objeto.Horario_Trabajo1;
                    texto_completo += texto + "\n";
                }
                foreach (Trabajadores objeto in Lista_Supervisores)
                {
                    texto = "Nombre: " + objeto.Nombre1 + ", Apellido: " + objeto.Apellido1 + ", Rut: " + objeto.Rut1 + ", Fecha Nacimiento: " + objeto.Fecha_Nacimiento1 + ", Nacionalidad: " + objeto.Nacionalidad1 + " Trabajo: " + objeto.Tipo_Persona1 + ", Sueldo: " + objeto.Sueldo1 + " ,Horario " + objeto.Horario_Trabajo1;
                    texto_completo += texto + "\n";
                }
                return texto_completo;

            }

        }
        public List<Trabajadores> GetList(string nombre_lista)
        {

            if (nombre_lista == "Cliente")
            {
                return Lista_Clientes;
            }
            else if (nombre_lista == "Auxiliar")
            {
                return Lista_Auxiliares;
            }
            else if (nombre_lista == "Jefe")
            {
                return Lista_Jefes;
            }
            else if (nombre_lista == "Supervisor")
            {
                return Lista_Supervisores;
            }
            else if (nombre_lista == "Cajero")
            {
                return Lista_Cajeros;
            }
            else if (nombre_lista == "Reponedor")
            {
                return Lista_Reponedores;
            }
            else
            {
                List<Trabajadores> Empty = new List<Trabajadores>();
                return Empty;
            }
        }
        // Va a buscar el trabajador del rut
        public string GetWorker(string Rut)
        {
            foreach (Trabajadores objeto in Lista_Clientes)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            foreach (Trabajadores objeto in Lista_Auxiliares)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            foreach (Trabajadores objeto in Lista_Cajeros)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            foreach (Trabajadores objeto in Lista_Guardias)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            foreach (Trabajadores objeto in Lista_Jefes)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            foreach (Trabajadores objeto in Lista_Reponedores)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            foreach (Trabajadores objeto in Lista_Supervisores)
            {
                if (objeto.Rut1 == Rut)
                {
                    return objeto.Tipo_Persona1;
                }
            }
            return "";
        }
        // Devuelve true si es que el cliente es nuevo, o false si no lo es.
        public bool Validar_Clientes_nuevos(string Rut)
        {
            string validacion;
            validacion = GetWorker(Rut);
            if (validacion == "")
            {
                foreach (Trabajadores objeto in Lista_Clientes)
                {
                    if (objeto.Rut1==Rut)
                    {
                        return false;
                    }
                }
                return true;
            }   
            else
            {
                return false;
            }
        }
        // Cambio de sueldo especifico del tipo de trabajo que realiza 

        public bool Cambiar_Sueldo(string Rut, string Sueldo_nuevo)
        {
            string Trabajo;
            Trabajo = GetWorker(Rut);

            foreach (Trabajadores objeto in GetList(Trabajo))
            {
                if (objeto.Rut1 == Rut)
                {
                    objeto.Sueldo1 = Sueldo_nuevo;
                    return true;
                }
            }
            return false;



        }
        //Metodo que da verdadero si es que ya ha sido agregado en alguna base de datos el rut asociado
        public bool Validador_Rut(string Rut)
        {
            string trabajo;
            trabajo = GetWorker(Rut);

            foreach (Trabajadores objeto in GetList(trabajo))
            {
                if (objeto.Rut1 == Rut)
                {

                    return true;
                }
            }
            return false;

        }
        public bool Cambio_Horario(string Rut, string Horario)
        {
            string Trabajo;
            Trabajo = GetWorker(Rut);

            foreach (Trabajadores objeto in GetList(Trabajo))
            {
                if (objeto.Rut1 == Rut)
                {
                    objeto.Horario_Trabajo1 = Horario;
                    return true;
                }
            }
            return false;



        }
        // Verifica si es un nuevo producto (Devuelve true si es un nuevo producto y devuelve false si no lo es)
        public bool Validador_nuevo_Producto(string Nombre, string Marca)
        {
            foreach (Productos objeto in Lista_Productos)
            {
                if (objeto.Nombre_Producto1 == Nombre && objeto.Marca1 == Marca)
                {
                    return false;
                }
            }
            return true;
        }
        //Revisa si los productos existen en la lista , es para ser utilizado en agregar stock!, si es verdad significa que ya existe (devuelve verdadero si ya existe y falso si no)
        public bool Validador_Producto_existente(string Nombre, string Marca)
        {
            foreach (Productos objeto in Lista_Productos)
            {
                if (objeto.Nombre_Producto1 == Nombre && objeto.Marca1 == Marca)
                {
                    return true;
                }
            }
            return false;
        }
        // Metodo para agregar otro nuevo producto, no agregar stock a producto ya existente 
        public void Agregar_Producto(string Nombre, string Marca, string Precio, int stock)
        {
            Productos producto = new Productos(Nombre, Precio, Marca, stock);
            Lista_Productos.Add(producto);

        }
        // Se le agrega stock a los productos ya existentes 
        public void Agregar_Stock(string Nombre, string Marca, int Monto)
        {
            foreach (Productos producto in Lista_Productos)
            {
                if (producto.Nombre_Producto1 == Nombre && producto.Marca1 == Marca)
                {
                    producto.Stock1 += Monto;
                }
            }

        }

        //Metodo para mostrar productos agregados a la base de datos
        public string Mostrar_Productos()
        {
            string texto_productos = "";
            string texto;

            
            foreach (Productos objeto in Lista_Productos)
            {
                texto = "NOMBRE: " + objeto.Nombre_Producto1 + ", MARCA: " + objeto.Marca1 + ", PRECIO: " + objeto.Precio1 + ", STOCK " + objeto.Stock1;
                texto_productos += texto + "\n";
            }
            return texto_productos;
        }
        // Se utiliza para mostrar info al usuario del carro de compras , con su respectiva cantidad de compra
        public string Mostrar_Producto_Especifico(string Nombre, string Marca,int Cantidad)
        {
            string texto_productos = "";
            string texto;


            foreach (Productos objeto in Lista_Productos)

            {   if (objeto.Nombre_Producto1==Nombre && objeto.Marca1==Marca)
                {
                    texto = "NOMBRE: " + objeto.Nombre_Producto1 + ", MARCA: " + objeto.Marca1 + ", PRECIO: " + objeto.Precio1 + ", Cantidad " + Cantidad;
                    texto_productos += texto + "\n";
                }
            }
            return texto_productos;
        }
        // Funcion de compra solo llamar si es una cantidad de compra menor o igual al stock
        public void Comprar_Productos(string Nombre,string Marca,int Cantidad)
        {
            foreach (Productos producto in Lista_Productos)
            {
                if (producto.Nombre_Producto1==Nombre && producto.Marca1==Marca)
                {
                    producto.Stock1 -= Cantidad;
                }
            }
        }
        // Devuelve un string , si es que devuelve 0 significa que el stock llego a 0 , y si devuelve 1 stock >=Cantidad y -1 si es que Nombre producto y marco no existente o si el stock menor q 0
        public string Validador_Stock(string Nombre, string Marca, int Cantidad)
        {
            foreach (Productos producto in Lista_Productos)
            {
                if (producto.Nombre_Producto1== Nombre && producto.Marca1==Marca)
                {
                    if (producto.Stock1==0)
                    {   // Cantidad de stock igual a 0
                        return "0";
                    }
                    
                    else if (producto.Stock1>=Cantidad)
                    {
                        return "1";
                    }
                    else if (producto.Stock1<=Cantidad && producto.Stock1 !=0)
                    {
                        return "2";
                    }
                    
                }
            }

            // No deberia llegar aqui dado que se valida si es que existe antes de llamar al validador.
            return  "";
        }
        public void Almacenar_Registro(string Rut_Cliente, string datos)
        {
            Registro_Compras.Add(Rut_Cliente, datos);
        }
        public string Mostrar_Registro()
        {
            string texto;
            string texto_completo="";
            foreach (KeyValuePair<string, string> Elemento in Registro_Compras)
            {
                string key = Elemento.Key;
                string value = Elemento.Value;
                texto = "Rut Cliente: " + key + " Productos:" + value;
                texto_completo += texto+"\n";
            }
            return texto_completo;
        }
    }
        
    class Productos
    {

        private string Nombre_Producto;
        private string Precio;
        private string Marca;
        private int Stock;

        public Productos(string Nombre_Producto, string Precio, string Marca, int Stock)
        {
            this.Nombre_Producto1 = Nombre_Producto;
            this.Precio1 = Precio;
            this.Marca1 = Marca;
            this.Stock1 = Stock;


        }

        public string Nombre_Producto1 { get => Nombre_Producto; set => Nombre_Producto = value; }
        public string Precio1 { get => Precio; set => Precio = value; }
        public string Marca1 { get => Marca; set => Marca = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
    }


}



 
