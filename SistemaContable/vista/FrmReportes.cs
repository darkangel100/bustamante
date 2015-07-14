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
using System.Diagnostics;

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
                p.getPago().LISTAPAGO=p.rptLibros(Utiles.fecha(dtp1ld), Utiles.fecha(dtp2ld),0);
                for (int i = 0; i < p.getPago().LISTAPAGO.Count; i++)
                {
                    dgvld.Rows.Add(1);
                    dgvld.Rows[i].Cells[0].Value = p.getPago().LISTAPAGO[i].FECHA;
                    dgvld.Rows[i].Cells[1].Value = p.getPago().LISTAPAGO[i].IDPAGO;
                    AsientoContableDB ac = new AsientoContableDB();
                    ac.setAsientoContable(ac.cuentasLibros(int.Parse(p.getPago().LISTAPAGO[i].IDPAGO)));
                    dgvld.Rows[i].Cells[2].Value = ac.getAsientoContable().NOMBRE_ASIENTO;
                    dgvld.Rows[i].Cells[3].Value = ac.getAsientoContable().DESCRIPCION;
                    dgvld.Rows[i].Cells[5].Value = p.getPago().LISTAPAGO[i].MONTO;
                    fila++;
                }

                //facturas
                int cont = 0;
                FacturaBD f = new FacturaBD();
                f.getFacturas().LISTAFACTURA = f.libros(Utiles.fecha(dtp1ld), Utiles.fecha(dtp2ld),"");
                for (int i = fila; i < (fila+f.getFacturas().LISTAFACTURA.Count); i++)
                {
                    
                    dgvld.Rows.Add(1);
                    dgvld.Rows[i].Cells[0].Value = f.getFacturas().LISTAFACTURA[cont].FECHA;
                    dgvld.Rows[i].Cells[1].Value = f.getFacturas().LISTAFACTURA[cont].IDFACTURA;
                    AsientoContableDB ac = new AsientoContableDB();
                    ac.setAsientoContable(ac.cuentasLibros(f.getFacturas().LISTAFACTURA[cont].IDFACTURA));
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
            salida += "<h4>Periodo: "+txtPeriodoLd.Text+"</h4>";
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
            Process.Start(Utiles.ObtenerRuta() + "/Panda/LibroDiario.html");
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            FrmEgreso fe = new FrmEgreso();
            FrmProducto fp = new FrmProducto();
            fp.llenaProductos(cboArticuloTk);
            fe.cargarAsientosRtp(cboCuenta);
        }

        private void btnConsultaLM_Click(object sender, EventArgs e)
        {
            dgvlm.Rows.Clear();
            if (dtplm1.Value.Year == dtplm2.Value.Year && dtplm1.Value.Month == dtplm2.Value.Month)
            {
                txtPeriodolm.Text = dtplm1.Value.Month + " del " + dtplm1.Value.Year;
                txtCuentalm.Text = cboCuenta.Text;
                libroMayor();
            }
        }
        public void libroMayor()
        {
            try
            {
                AsientoContableDB acd = new AsientoContableDB();
                FacturaBD f = new FacturaBD();
                if (cboCuenta.Text == "COMPRA DE MERCADERIA" || cboCuenta.Text == "VENTA DE MERCADERIAS")
                {
                    if (cboCuenta.Text == "COMPRA DE MERCADERIA")
                    {
                        double saldo = 0;
                        f.getFacturas().LISTAFACTURA = f.libros(Utiles.fecha(dtplm1), Utiles.fecha(dtplm2),"c");
                        for (int i = 0; i < f.getFacturas().LISTAFACTURA.Count; i++)
                        {
                            dgvlm.Rows.Add(1);
                            dgvlm.Rows[i].Cells[0].Value = f.getFacturas().LISTAFACTURA[i].FECHA;
                            dgvlm.Rows[i].Cells[1].Value = f.getFacturas().LISTAFACTURA[i].IDFACTURA;
                            dgvlm.Rows[i].Cells[3].Value = f.getFacturas().LISTAFACTURA[i].TOTAL;
                            AsientoContableDB ac = new AsientoContableDB();
                            ac.setAsientoContable(ac.cuentasLibros(f.getFacturas().LISTAFACTURA[i].IDFACTURA));
                            dgvlm.Rows[i].Cells[2].Value = ac.getAsientoContable().DESCRIPCION;
                            saldo = saldo + f.getFacturas().LISTAFACTURA[i].TOTAL;
                            dgvlm.Rows[i].Cells[5].Value = saldo;
                        }
                    }
                    if (cboCuenta.Text == "VENTA DE MERCADERIAS")
                    {
                        double saldo = 0;
                        f.getFacturas().LISTAFACTURA = f.libros(Utiles.fecha(dtplm1), Utiles.fecha(dtplm2), "v");
                        for (int i = 0; i < f.getFacturas().LISTAFACTURA.Count; i++)
                        {
                            dgvlm.Rows.Add(1);
                            dgvlm.Rows[i].Cells[0].Value = f.getFacturas().LISTAFACTURA[i].FECHA;
                            dgvlm.Rows[i].Cells[1].Value = f.getFacturas().LISTAFACTURA[i].IDFACTURA;
                            dgvlm.Rows[i].Cells[4].Value = f.getFacturas().LISTAFACTURA[i].TOTAL;
                            AsientoContableDB ac = new AsientoContableDB();
                            ac.setAsientoContable(ac.cuentasLibros(f.getFacturas().LISTAFACTURA[i].IDFACTURA));
                            dgvlm.Rows[i].Cells[2].Value = ac.getAsientoContable().DESCRIPCION;
                            saldo = saldo + f.getFacturas().LISTAFACTURA[i].TOTAL;
                            dgvlm.Rows[i].Cells[5].Value = saldo;
                        }
                    }
                }
                else
                {
                    double saldo = 0;
                    acd.getAsientoContable().LISTAASIENTO = acd.traeasicon(cboCuenta.Text);
                    for (int i = 0; i < acd.getAsientoContable().LISTAASIENTO.Count; i++)
                    {
                        PagoDB p = new PagoDB();
                        p.getPago().LISTAPAGO = p.rptLibros(Utiles.fecha(dtplm1), Utiles.fecha(dtplm2), int.Parse(acd.getAsientoContable().LISTAASIENTO[i].IDASIENTO));
                        if(p.getPago().LISTAPAGO.Count!=0)
                        {
                            dgvlm.Rows.Add(1);
                            dgvlm.Rows[i].Cells[0].Value = p.getPago().LISTAPAGO[0].FECHA;
                            dgvlm.Rows[i].Cells[1].Value = acd.getAsientoContable().LISTAASIENTO[i].IDASIENTO;
                            dgvlm.Rows[i].Cells[2].Value = acd.getAsientoContable().LISTAASIENTO[i].DESCRIPCION;
                            dgvlm.Rows[i].Cells[4].Value = p.getPago().LISTAPAGO[0].MONTO;
                            saldo = saldo + p.getPago().LISTAPAGO[0].MONTO;
                            dgvlm.Rows[i].Cells[5].Value = saldo;
                        }
                    }
                }
            }
            catch 
            {
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string salida = "<html>";
            salida += "<head>";
            salida += "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />";
            salida += "<title>Libro Mayor</title>";
            salida += "</head";
            salida += "<body>";
            salida += "<center><h1>Autoservicio Panda</h1></center>";
            salida += "<center><h2>Libro Mayor</h2></center>";
            salida += "<h4>Periodo: " + txtPeriodolm.Text + "</h4>";
            salida += "<h4>Cuenta: " + cboCuenta.Text + "</h4>";
            salida += "<table border='5'>";
            salida += "<thead><tr><th>Fecha</th><th>Codigo</th><th>Descripcion</th><th>Debe</th><th>Haber</th><th>Saldo</th></tr>";
            for (int i = 0; i < dgvlm.Rows.Count; i++)
            {
                salida += "<tr>";
                salida += "<td>" + dgvlm.Rows[i].Cells[0].Value + "</td>";
                salida += "<td>" + dgvlm.Rows[i].Cells[1].Value + "</td>";
                salida += "<td>" + dgvlm.Rows[i].Cells[2].Value + "</td>";
                salida += "<td>" + dgvlm.Rows[i].Cells[3].Value + "</td>";
                salida += "<td>" + dgvlm.Rows[i].Cells[4].Value + "</td>";
                salida += "<td>" + dgvlm.Rows[i].Cells[5].Value + "</td>";
                salida += "</tr>";
            }
            salida += "</table>";
            salida += "</body>";
            salida += "</html>";
            Utiles.guardarReporte(salida, "LibroMayor");
            Process.Start(Utiles.ObtenerRuta() + "/Panda/LibroMayor.html");
        }

        private void btnConsultarTk_Click(object sender, EventArgs e)
        {
            tarjetaKardex();
        }
        
        public void tarjetaKardex()
        {
            dgvtk.Rows.Clear();
            FacturaBD f = new FacturaBD();
            LoteDB l = new LoteDB();
            AsientoContableDB ac = new AsientoContableDB();
            DetalleFacturaDB dp = new DetalleFacturaDB();
            ProductoDB p = new ProductoDB();
            int cont=0;
            int cant = 0;
            double total = 0;
            try
            {
                txtArticuloTk.Text=cboArticuloTk.Text;
                txtPeriodotk.Text = "Del " + Utiles.fecha(dtptk1) + " al " + Utiles.fecha(dtptk2);
                p.setProducto(p.traeProducto(0,cboArticuloTk.Text,"nombre"));
                txtCodProd.Text = p.getProducto().Id_producto.ToString();
                txtStockGlobal.Text = p.getProducto().Stock_global.ToString();
                l.getLote().LISTALOTE = l.traerLotes(p.getProducto().Id_producto);
                for (int h = 0; h < l.getLote().LISTALOTE.Count;h++ )
                {
                    txtLotes.Text += l.getLote().LISTALOTE[h].CODLOTE;
                }
                    f.getFacturas().LISTAFACTURA = f.libros(Utiles.fecha(dtptk1), Utiles.fecha(dtptk2), "");
                for (int i = 0; i < f.getFacturas().LISTAFACTURA.Count; i++)
                {
                    dp.getDetalleFactura().LISTADETALLE = dp.traedetaid(f.getFacturas().LISTAFACTURA[i].IDFACTURA);
                    for (int j = 0; j < dp.getDetalleFactura().LISTADETALLE.Count;j++ )
                    {
                        if(dp.getDetalleFactura().LISTADETALLE[j].NOMBREPRODUCTO==cboArticuloTk.Text)
                        {
                            dgvtk.Rows.Add(1);
                            dgvtk.Rows[cont].Cells[0].Value = f.getFacturas().LISTAFACTURA[i].FECHA;
                            ac.setAsientoContable(ac.cuentasLibros(f.getFacturas().LISTAFACTURA[i].IDFACTURA));
                            dgvtk.Rows[cont].Cells[1].Value = ac.getAsientoContable().DESCRIPCION;
                            if(f.getFacturas().LISTAFACTURA[i].TIPOFACTURA=="c")
                            {
                                dgvtk.Rows[cont].Cells[2].Value = dp.getDetalleFactura().LISTADETALLE[j].CANTIDAD;
                                cant = cant + int.Parse(dp.getDetalleFactura().LISTADETALLE[j].CANTIDAD);
                                dgvtk.Rows[cont].Cells[3].Value = dp.getDetalleFactura().LISTADETALLE[j].COSTOTOTAL;
                                total = total + double.Parse(dp.getDetalleFactura().LISTADETALLE[j].COSTOTOTAL);
                                dgvtk.Rows[cont].Cells[6].Value = cant;
                                dgvtk.Rows[cont].Cells[7].Value = total;
                            }
                            else
                            {
                                dgvtk.Rows[cont].Cells[4].Value = dp.getDetalleFactura().LISTADETALLE[j].CANTIDAD;
                                cant = cant - int.Parse(dp.getDetalleFactura().LISTADETALLE[j].CANTIDAD);
                                dgvtk.Rows[cont].Cells[5].Value = dp.getDetalleFactura().LISTADETALLE[j].COSTOTOTAL;
                                total = total - double.Parse(dp.getDetalleFactura().LISTADETALLE[j].COSTOTOTAL);
                                dgvtk.Rows[cont].Cells[6].Value = cant;
                                dgvtk.Rows[cont].Cells[7].Value = total;
                            }
                            cont++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, "+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnImprimirtk_Click(object sender, EventArgs e)
        {
            string salida = "<html>";
            salida += "<head>";
            salida += "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />";
            salida += "<title>Libro Mayor</title>";
            salida += "</head";
            salida += "<body>";
            salida += "<center><h2>Autoservicio Panda</h2></center>";
            salida += "<center><h3>Tarjeta Kardex</h3></center>";
            salida += "<h4>Articulo: "+ txtArticuloTk.Text+"</h4>";
            salida += "<h4>Codigo: " + txtCodProd.Text + "</h4>";
            salida += "<h4>Periodo: " + txtPeriodotk.Text + "</h4>";
            salida += "<h4>Lotes: " + txtLotes.Text + "</h4>";
            salida += "<h4>Numero de existencias: " + txtStockGlobal.Text + "</h4>";
            salida+="<table border='2'>";
		    salida+="<tr>";
			salida+="<b><th colspan='2'>Datos</th></b>";
			salida+="<b><th colspan='2'>Entrada</th></b>";
			salida+="<b><th colspan='2'>Salida</th></b>";
			salida+="<b><th colspan='2'>Saldo</th></b>";
		    salida+="</tr>";
		    salida+="<tr>";
			salida+="<b><th>Fecha</th></b>";
			salida+="<b><th>Detalle</th></b>";
			salida+="<b><th>Cantidad</th></b>";
			salida+="<b><th>Costo</th></b>";
			salida+="<b><th>Cantidad</th></b>";
			salida+="<b><th>Costo</th></b>";
			salida+="<b><th>Cantidad</th></b>";
			salida+="<b><th>Costo</th></b>";
            salida += "</tr>";
            for (int i = 0; i < dgvtk.Rows.Count; i++)
            {
                salida += "<tr>";
                salida += "<td>" + dgvtk.Rows[i].Cells[0].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[1].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[2].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[3].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[4].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[5].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[6].Value + "</td>";
                salida += "<td>" + dgvtk.Rows[i].Cells[7].Value + "</td>";
                salida += "</tr>";
            }
            salida += "</table>";
            salida += "</body>";
            salida += "</html>";
            Utiles.guardarReporte(salida, "TarjetaKardex");
            Process.Start(Utiles.ObtenerRuta() + "/Panda/TarjetaKardex.html");
        }
    }
}
