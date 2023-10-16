using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.Spreadsheet;
using SIPOTCC.SIPOT;
using SIPOTCC.SIPOT.Campos;
using SIPOTCC.SIPOT.Enumeradores;

namespace SIPOTCC
{
    public class Program
    {
        private static string ObtenerValorCelda(CellValue valor, bool esHora = false)
        {
            if (valor == null)
                return string.Empty;

            try
            {
                string cadena;
                switch (valor.Type)
                {
                    case CellValueType.Text:
                        cadena = valor.TextValue;
                        break;

                    case CellValueType.Boolean:
                        cadena = valor.BooleanValue.ToString().ToLower();
                        break;

                    case CellValueType.Numeric:
                        cadena = valor.NumericValue.ToString(CultureInfo.InvariantCulture);
                        break;

                    case CellValueType.DateTime:
                        cadena = esHora
                            ? valor.DateTimeValue.ToString("HH:mm", CultureInfo.InvariantCulture)
                            : valor.DateTimeValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        break;

                    //case CellValueType.None:
                    //case CellValueType.Error:
                    //case CellValueType.Unknown:
                    default:
                        cadena = string.Empty;
                        break;
                }

                return cadena;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return string.Empty;
            }
        }

        private static void ProcesarTabla(Campo campo, Workbook libro)
        {
            if (!(campo is Tabla) || libro == null)
                return;

            var tabla = (Tabla) campo;
            var nombreHojaTabla = string.Format("Tabla_{0}", tabla.ID);
            if (!libro.Worksheets.Contains(nombreHojaTabla))
            {
                Debug.WriteLine("No existe la hoja \"{0}\" de la tabla \"{1}\"", nombreHojaTabla, campo.Nombre);
                return;
            }

            var hojaTabla = libro.Worksheets[nombreHojaTabla];
            var rangoTabla = hojaTabla.GetDataRange();
            var maximaCantidadColumnas = rangoTabla.RightColumnIndex;

            // Procesar Campos de la Tabla
            for (var columna = 0; columna <= maximaCantidadColumnas; columna++)
            {
                var strIdTipoCampo = ObtenerValorCelda(hojaTabla.Columns[columna][0].Value);
                var strIdCampo = ObtenerValorCelda(hojaTabla.Columns[columna][1].Value);
                var celdaNombreCampo = hojaTabla.Columns[columna][2];

                var campoTabla = Campo.FabricarPorTipo(strIdTipoCampo, true);
                campoTabla.ID = Genericos.ConvertirCadenaAEntero(strIdCampo);
                campoTabla.Nombre = ObtenerValorCelda(celdaNombreCampo.Value);
                campoTabla.Posicion = new Posicion(nombreHojaTabla, celdaNombreCampo.LeftColumnIndex, celdaNombreCampo.TopRowIndex);
                campoTabla.EstaDentroDeUnaTabla = true;

                tabla.Campos.Add(campoTabla);
            }
        }

        private static string ConvertToCsvCell(string value)
        {
            var mustQuote = value.Any(x => x == ',' || x == '\"' || x == '\r' || x == '\n');

            if (!mustQuote)
            {
                return value;
            }

            value = value.Replace("\"", "\"\"");

            return string.Format("\"{0}\"", value);
        }

        private static void Main(string[] args)
        {
            const string nombreHojaFormato = "Reporte de Formatos";
            var stopwatch = Stopwatch.StartNew();

            var argumento1 = string.Empty;
            if (args.Length > 0)
                argumento1 = args[0];

            var directorioActual = Directory.GetCurrentDirectory();
            var archivos = string.IsNullOrWhiteSpace(argumento1)
                ? new[] { Path.Combine(directorioActual, "Formato_Pruebas.xls") }
                : Directory.GetFiles(directorioActual, "*.xls", SearchOption.AllDirectories).OrderBy(f => f).ToArray();

            var reporteCSV = new StringBuilder();
            reporteCSV.Append("NombreCorto,Titulo,Descripcion,CantidadCriterios,CantidadCriteriosMasTipoTabla\n");

            foreach (var nombreLibro in archivos)
            {
                var libro = new Workbook();
                libro.LoadDocument(nombreLibro);
                if (!libro.Worksheets.Contains(nombreHojaFormato))
                {
                    Console.WriteLine(nombreLibro);
                    Console.WriteLine(
                        "No podemos procesar este formato, no existe la hoja \"{0}\" lo que indica que la estructura del formato ha sido alterada.\n",
                        nombreHojaFormato);
                    return;
                }

                var hojaFormato = libro.Worksheets[nombreHojaFormato];
                var rangoFormato = hojaFormato.GetDataRange();
                var maximaCantidadColumnas = rangoFormato.RightColumnIndex;

                var idFormato = Genericos.ConvertirCadenaAEntero(ObtenerValorCelda(hojaFormato.Columns[0][0].Value));
                var nombreFormato = ObtenerValorCelda(hojaFormato.Columns[3][2].Value);
                var tituloFormato = ObtenerValorCelda(hojaFormato.Columns[0][2].Value);
                var descripcionFormato = ObtenerValorCelda(hojaFormato.Columns[6][2].Value);

                var formato = new Formato(idFormato, nombreFormato);

                // Procesar Campos del Formato
                for (var columna = 0; columna <= maximaCantidadColumnas; columna++)
                {
                    var strIdTipoCampo = ObtenerValorCelda(hojaFormato.Columns[columna][3].Value);
                    var strIdCampo = ObtenerValorCelda(hojaFormato.Columns[columna][4].Value);
                    var celdaNombreCampo = hojaFormato.Columns[columna][6];

                    var campo = Campo.FabricarPorTipo(strIdTipoCampo);
                    campo.ID = Genericos.ConvertirCadenaAEntero(strIdCampo);
                    campo.Nombre = ObtenerValorCelda(celdaNombreCampo.Value);
                    campo.Posicion = new Posicion(nombreHojaFormato, celdaNombreCampo.LeftColumnIndex, celdaNombreCampo.TopRowIndex);

                    if (campo is Tabla)
                        ProcesarTabla(campo, libro);

                    formato.Campos.Add(campo);
                }

                var cantidadCriteriosMasTipoTabla = formato.CantidadCampos;
                var camposTipoTabla = formato.Campos.Where(campo => campo.Tipo.Equals(TipoCampo.Tabla)).ToList();
                if (camposTipoTabla.Count > 0)
                {
                    // ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (var campoTabla in camposTipoTabla)
                    {
                        var campo = (Tabla) campoTabla;
                        cantidadCriteriosMasTipoTabla += campo.Campos.Count;
                    }
                }

                reporteCSV.Append(string.Format("{0},{1},{2},{3},{4}\n", ConvertToCsvCell(formato.Nombre), ConvertToCsvCell(tituloFormato),
                    ConvertToCsvCell(descripcionFormato), formato.CantidadCampos, cantidadCriteriosMasTipoTabla));
            }

            File.WriteAllText("reporte.csv", reporteCSV.ToString());

            stopwatch.Stop();
            Console.WriteLine("Tiempo transcurrido de procesamiento: {0}", stopwatch.Elapsed);
            Console.WriteLine("Cantidad Formatos Procesados: {0}", archivos.Length);

            #if DEBUG
                Console.WriteLine("\nPulse cualquier tecla para finalizar");
                Console.ReadLine();
            #endif

        }
    }
}