using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaContable.controlador;

namespace SistemaContable.vista
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void btnConsultaLD_Click(object sender, EventArgs e)
        {
            dgvld.Rows.Clear();
            if (dtp1ld.Value.Year == dtp2ld.Value.Year && dtp1ld.Value.Month == dtp2ld.Value.Month)
            {
                txtPeriodoLd.Text = dtp1ld.Value.Month + " del " + dtp1ld.Value.Year;   
                libroDiario();
            }
        }

        public void libroDiario()
        {
            try
            {
                int fila=0;
                PagoDB p = new PagoDB();
                p.getPago().LISTAPAGO=p.rptLibroDiario(Utiles.fecha(dtp1ld), Utiles.fecha(dtp2ld));
                for (int i = 0; i < p.getPago().LISTAPAGO.Count; i++)
                {
                    dgvld.Rows.Add(1);
                    dgvld.Rows[i].Cells[0].Value = p.getPago().LISTAPAGO[i].FECHA;
                    dgvld.Rows[i].Cells[1].Value = p.getPago().LISTAPAGO[i].IDPAGO;
                    AsientoContableDB ac = new AsientoContableDB();
                    ac.setAsientoContable(ac.libroDiario(int.Parse(p.getPago().LISTAPAGO[i].IDPAGO)));
                    dgvld.Rows[i].Cells[2].Value = ac.getAsientoContable().NOMBRE_ASIENTO;
                    dgvld.Rows[i].Cells[3].Value = ac.getAsientoContable().DESCRIPCION;
                    dgvld.Rows[i].Cells[5].Value = p.getPago().LISTAPAGO[i].MONTO;
                    fila++;
                }

                //facturas
                int cont = 0;
                FacturaBD f = new FacturaBD();
                f.getFacturas().LISTAFACTURA = f.libroDiario(Utiles.fecha(dtp1ld), Utiles.fecha(dtp2ld));
                for (int i = fila; i < (fila+f.getFacturas().LISTAFACTURA.Count); i++)
                {
                    
                    dgvld.Rows.Add(1);
                    dgvld.Rows[i].Cells[0].Value = f.getFacturas().LISTAFACTURA[cont].FECHA;
                    dgvld.Rows[i].Cells[1].Value = f.getFacturas().LISTAFACTURA[cont].IDFACTURA;
                    AsientoContableDB ac = new AsientoContableDB();
                    ac.setAsientoContable(ac.libroDiario(f.getFacturas().LISTAFACTURA[cont].IDFACTURA));
                    dgvld.Rows[i].Cells[2].Value = ac.getAsientoContable().NOMBRE_ASIENTO;
                    dgvld.Rows[i].Cells[3].Value = ac.getAsientoContable().DESCRIPCION;

                    if (f.getFacturas().LISTAFACTURA[cont].TIPOFACTURA == "c" || f.getFacturas().LISTAFACTURA[cont].TIPOFACTURA == "C")
                        dgvld.Rows[i].Cells[4].Value = f.getFacturas().LISTAFACTURA[cont].TOTAL;
                    else
                        dgvld.Rows[i].Cells[5].Value = f.getFacturas().LISTAFACTURA[cont].TOTAL;
                    cont++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos, " + ex.Message, "Tienda", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string salida = "<html>";
            salida += "<head>";
            salida+="<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />";
	        salida+="<title>Libro Diario</title>";
            salida += "</head";
            salida += "<body>";
            salida += "<center><h1>Autoservicio Panda</h1></center>";
            salida += "<center><h2>Libro Diario</h2></center>";
            salida += "<h3>Periodo: "+txtPeriodoLd.Text+"</h3>";
            salida += "<table border='5'>";
            salida += "<thead><tr><th>Fecha</th><th>Codigo</th><th>Detalle</th><th>P/R</th><th>Debe</th><th>Haber</th></tr></thead>";
            for (int i = 0; i < dgvld.Rows.Count; i++)
            {
                salida += "<tr>";
                salida += "<td>" + dgvld.Rows[i].Cells[0].Value + "</td>";
                salida += "<td>" + dgvld.Rows[i].Cells[1].Value + "</td>";
                salida += "<td>" + dgvld.Rows[i].Cells[2].Value + "</td>";
                salida += "<td>" + dgvld.Rows[i].Cells[3].Value + "</td>";
                salida += "<td>" + dgvld.Rows[i].Cells[4].Value + "</td>";
                salida += "<td>" + dgvld.Rows[i].Cells[5].Value + "</td>";
                salida += "</tr>";
            }
            salida += "</table>";
            salida += "</body>";
            salida += "</html>";
            Utiles.guardarReporte(salida,"LibroDiario");
        }
    }
}
